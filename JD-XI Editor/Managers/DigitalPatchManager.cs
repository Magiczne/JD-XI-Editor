using System;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using JD_XI_Editor.Exceptions;
using JD_XI_Editor.Managers.Abstract;
using JD_XI_Editor.Managers.Enums;
using JD_XI_Editor.Managers.Events;
using JD_XI_Editor.Models.Patches;
using JD_XI_Editor.Models.Patches.Digital;
using JD_XI_Editor.Utils;
using Sanford.Multimedia.Midi;
using Timer = System.Timers.Timer;

namespace JD_XI_Editor.Managers
{
    internal class DigitalPatchManager : IDigitalPatchManager
    {
        #region Fields

        /// <summary>
        ///     Digital synth number
        /// </summary>
        private readonly DigitalSynth _synthNumber;

        /// <summary>
        ///     Common SysEx message length
        /// </summary>
        private readonly byte[] _commonDumpRequest = {0x00, 0x00, 0x00, 0x40};

        /// <summary>
        ///     Partial SysEx message length
        /// </summary>
        private readonly byte[] _partialDumpRequest = {0x00, 0x00, 0x00, 0x3D};

        /// <summary>
        ///     Modifiers SysEx message length
        /// </summary>
        private readonly byte[] _modifiersDumpRequest = {0x00, 0x00, 0x00, 0x25};

        /// <summary>
        ///     Expected Common Dump Length
        /// </summary>
        private const int ExpectedCommonDumpLength = 64;

        /// <summary>
        ///     Expected Partial Dump Length
        /// </summary>
        private const int ExpectedPartialDumpLength = 61;

        /// <summary>
        ///     Expected Modifiers Dump Length
        /// </summary>
        private const int ExpectedModifiersDumpLength = 37;

        /// <summary>
        ///     Timer used to determine timeouts when reading data from device
        /// </summary>
        private readonly Timer _timer = new Timer(4000);

        /// <summary>
        ///     Device instance
        /// </summary>
        private InputDevice _device;

        /// <summary>
        ///     Count of dump messages received
        /// </summary>
        private int _dumpCount;

        /// <summary>
        ///     SysEx dump from common
        /// </summary>
        private SysExMessage _commonDump;

        /// <summary>
        ///     SysEx dump from partials
        /// </summary>
        private readonly SysExMessage[] _partialsDump = {null, null, null};

        /// <summary>
        ///     SysEx dump from modifiers
        /// </summary>
        private SysExMessage _modifiersDump;

        #endregion

        #region Events

        /// <inheritdoc />
        public event EventHandler<PatchDumpReceivedEventArgs> DataDumpReceived;

        /// <inheritdoc />
        public event EventHandler<TimeoutException> OperationTimedOut;

        #endregion

        #region Methods

        /// <inheritdoc />
        public DigitalPatchManager(DigitalSynth synthNumber)
        {
            _synthNumber = synthNumber;
            _timer.Elapsed += OnTimerElapsed;
        }

        /// <summary>
        ///     Partial address offset
        /// </summary>
        private byte[] PartialAddressOffset(DigitalPartial partial)
        {
            return new byte[] {0x19, (byte) _synthNumber, (byte) partial, 0x00};
        }

        /// <summary>
        ///     Common address offset
        /// </summary>
        private byte[] CommonAddressOffset => new byte[] {0x19, (byte) _synthNumber, 0x00, 0x00};

        /// <summary>
        ///     Modifiers address offset
        /// </summary>
        private byte[] ModifiersAddressOffset => new byte[] {0x19, (byte) _synthNumber, 0x50, 0x00};

        #endregion

        #region Callbacks

        /// <summary>
        ///     Callback called when data dump is received from device
        /// </summary>
        private void OnSysExMessageReceived(object sender, SysExMessageEventArgs e)
        {
            if (e.Message.Length == ExpectedCommonDumpLength + SysExUtils.DumpPaddingSize)
            {
                _commonDump = e.Message;
            }
            else if (e.Message.Length == ExpectedPartialDumpLength + SysExUtils.DumpPaddingSize)
            {
                // At 11 byte we have partial number, so we check value at that byte
                var partial = (DigitalPartial) e.Message[10];

                switch (partial)
                {
                    case DigitalPartial.First:
                        _partialsDump[0] = e.Message;
                        break;

                    case DigitalPartial.Second:
                        _partialsDump[1] = e.Message;

                        break;
                    case DigitalPartial.Third:
                        _partialsDump[2] = e.Message;
                        break;

                    default:
                        throw new ArgumentOutOfRangeException(nameof(partial), partial, null);
                }
            }
            else if (e.Message.Length == ExpectedModifiersDumpLength + SysExUtils.DumpPaddingSize)
            {
                _modifiersDump = e.Message;
            }
            else
            {
                throw new InvalidDumpSizeException();
            }

            _dumpCount++;

            if (_dumpCount == 5)
            {
                _timer.Stop();

                _device.StopRecording();
                _device.Dispose();

                DataDumpReceived?.Invoke(this, new DigitalPatchDumpReceivedEventArgs(
                    new Patch(_commonDump, _partialsDump, _modifiersDump)
                ));
            }
        }

        /// <summary>
        ///     Callback called when timer waiting for data dump from device elapses
        /// </summary>
        private void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            _timer.Stop();

            if (!_device.IsDisposed)
            {
                _device.StopRecording();
                _device.Dispose();
            }

            OperationTimedOut?.Invoke(this, new TimeoutException("Read data operation timed out"));
        }

        #endregion

        #region IPatchManager

        /// <inheritdoc />
        public void Dump(IPatch patch, int deviceId)
        {
            var digitalPatch = (Patch) patch;

            using (var output = new OutputDevice(deviceId))
            {
                output.Send(SysExUtils.GetMessage(CommonAddressOffset, digitalPatch.Common.GetBytes()));

                output.Send(SysExUtils.GetMessage(PartialAddressOffset(DigitalPartial.First),
                    digitalPatch.PartialOne.GetBytes()));
                output.Send(SysExUtils.GetMessage(PartialAddressOffset(DigitalPartial.Second),
                    digitalPatch.PartialTwo.GetBytes()));
                output.Send(SysExUtils.GetMessage(PartialAddressOffset(DigitalPartial.Third),
                    digitalPatch.PartialThree.GetBytes()));

                output.Send(SysExUtils.GetMessage(ModifiersAddressOffset, digitalPatch.Modifiers.GetBytes()));
            }
        }

        /// <inheritdoc />
        public void Read(int inputDeviceId, int outputDeviceId)
        {
            // Reset dump count counter
            _dumpCount = 0;

            // Initialize input device
            _device = new InputDevice(inputDeviceId);

            // Setup event handler for receiving SysEx messages
            _device.SysExMessageReceived += OnSysExMessageReceived;

            // Start recording input from device
            _device.StartRecording();

            // Start timer before running task, so we have timer on the same thread
            // as the callbacks for timer and input device
            _timer.Start();

            // Request data dump from device on separate thread
            Task.Run(() =>
            {
                // Need to make 50ms delay between requests to ensure
                // that device will not hung up

                using (var output = new OutputDevice(outputDeviceId))
                {
                    output.Send(SysExUtils.GetRequestDumpMessage(CommonAddressOffset, _commonDumpRequest));
                    Thread.Sleep(50);

                    output.Send(SysExUtils.GetRequestDumpMessage(PartialAddressOffset(DigitalPartial.First),
                        _partialDumpRequest));
                    Thread.Sleep(50);

                    output.Send(SysExUtils.GetRequestDumpMessage(PartialAddressOffset(DigitalPartial.Second),
                        _partialDumpRequest));
                    Thread.Sleep(50);

                    output.Send(SysExUtils.GetRequestDumpMessage(PartialAddressOffset(DigitalPartial.Third),
                        _partialDumpRequest));
                    Thread.Sleep(50);

                    output.Send(SysExUtils.GetRequestDumpMessage(ModifiersAddressOffset, _modifiersDumpRequest));
                    Thread.Sleep(50);
                }
            });
        }

        #endregion

        #region IDigitalPatchManager

        /// <inheritdoc />
        public void DumpCommon(Common common, int deviceId)
        {
            using (var output = new OutputDevice(deviceId))
            {
                output.Send(SysExUtils.GetMessage(CommonAddressOffset, common.GetBytes()));
            }
        }

        /// <inheritdoc />
        public void DumpPartial(Partial partial, DigitalPartial partialNumber, int deviceId)
        {
            using (var output = new OutputDevice(deviceId))
            {
                output.Send(SysExUtils.GetMessage(PartialAddressOffset(partialNumber), partial.GetBytes()));
            }
        }

        /// <inheritdoc />
        public void DumpModifiers(Modifiers modifiers, int deviceId)
        {
            using (var output = new OutputDevice(deviceId))
            {
                output.Send(SysExUtils.GetMessage(ModifiersAddressOffset, modifiers.GetBytes()));
            }
        }

        #endregion
    }
}