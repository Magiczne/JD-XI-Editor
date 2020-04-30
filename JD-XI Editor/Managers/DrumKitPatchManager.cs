using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using JD_XI_Editor.Managers.Abstract;
using JD_XI_Editor.Managers.Events;
using JD_XI_Editor.Models.Enums.DrumKit;
using JD_XI_Editor.Models.Patches;
using JD_XI_Editor.Models.Patches.DrumKit;
using JD_XI_Editor.Models.Patches.DrumKit.Partial;
using JD_XI_Editor.Utils;
using JD_XI_Editor.Utils.Enums;
using Sanford.Multimedia.Midi;
using Timer = System.Timers.Timer;

namespace JD_XI_Editor.Managers
{
    internal class DrumKitPatchManager : IDrumKitPatchManager
    {
        #region Fields

        /// <summary>
        ///     Common address offset
        /// </summary>
        private readonly byte[] _commonAddressOffset = {0x19, 0x70, 0x00, 0x00};

        /// <summary>
        ///     Common dump request
        /// </summary>
        private readonly byte[] _commonDumpRequest = {0x00, 0x00, 0x00, 0x12};

        /// <summary>
        ///     Partial dump request
        /// </summary>
        private readonly byte[] _partialDumpRequest = {0x00, 0x00, 0x01, 0x43};

        /// <summary>
        ///     Expected common dump length
        /// </summary>
        private const int ExpectedCommonDumpLength = 18;

        /// <summary>
        ///     Expected partial dump length
        /// </summary>
        private const int ExpectedPartialDumpLength = 195;

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
        private readonly Dictionary<DrumKey, SysExMessage> _partialsDump = new Dictionary<DrumKey, SysExMessage>();

        #endregion

        #region Events

        /// <inheritdoc />
        public event EventHandler<PatchDumpReceivedEventArgs> DataDumpReceived;

        /// <inheritdoc />
        public event EventHandler<TimeoutException> OperationTimedOut;

        #endregion

        #region Methods

        public DrumKitPatchManager()
        {
            _timer.Elapsed += OnTimerElapsed;
        }

        /// <summary>
        ///     Partial address offset
        /// </summary>
        private static byte[] PartialAddressOffset(DrumKey key)
        {
            return new byte[] {0x19, 0x70, (byte) key, 0x00};
        }

        #endregion

        #region Callbacks

        /// <summary>
        ///     Callback called when data dump is received from device
        /// </summary>
        private void OnSysExMessageReceived(object sender, SysExMessageEventArgs e)
        {
            switch (e.Message.Length)
            {
                case ExpectedCommonDumpLength + SysExUtils.DumpPaddingSize:
                    _commonDump = e.Message;
                    break;

                case ExpectedPartialDumpLength + SysExUtils.DumpPaddingSize:
                {
                    // At 11 byte we have partial identifier, so we check value at that byte
                    var key = (DrumKey) e.Message[10];

                    _partialsDump[key] = e.Message;
                    break;
                }
            }

            _dumpCount++;

            if (_dumpCount == 39)
            {
                _timer.Stop();

                _device.StopRecording();
                _device.Dispose();

                DataDumpReceived?.Invoke(this, new DrumKitPatchDumpReceivedEventArgs(
                    new Patch(_commonDump, _partialsDump)    
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
            var drumPatch = (Patch) patch;

            using (var output = new OutputDevice(deviceId))
            {
                output.Send(SysExUtils.GetMessage(_commonAddressOffset, drumPatch.Common.GetBytes()));

                foreach (var partial in drumPatch.Partials)
                {
                    var bytes = partial.Value.GetBytes();
                    output.Send(SysExUtils.GetMessage(PartialAddressOffset(partial.Key), partial.Value.GetBytes()));
                    return;
                }
            }
        }

        /// <inheritdoc />
        public void Read(int inputDeviceId, int outputDeviceId)
        {
            // Reset dump count counter
            _dumpCount = 0;

            // Initialize input device
            _device = new InputDevice(inputDeviceId);

            // Clear previous sysex dumps
            _commonDump = null;
            _partialsDump.Clear();

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
                    output.Send(SysExUtils.GetRequestDumpMessage(_commonAddressOffset, _commonDumpRequest));

                    Thread.Sleep(50);

                    foreach (var vdPair in EnumHelper.GetAllValuesAndDescriptions(typeof(DrumKey)))
                    {
                        var key = (DrumKey) vdPair.Value;

                        output.Send(SysExUtils.GetRequestDumpMessage(PartialAddressOffset(key), _partialDumpRequest));

                        Thread.Sleep(50);
                    }
                }
            });
        }

        #endregion

        #region IDrumKitPatchManager

        /// <inheritdoc />
        public void DumpCommon(Common common, int deviceId)
        {
            using (var output = new OutputDevice(deviceId))
            {
                output.Send(SysExUtils.GetMessage(_commonAddressOffset, common.GetBytes()));
            }
        }

        /// <inheritdoc />
        public void DumpPartial(Partial partial, int deviceId)
        {
            using (var output = new OutputDevice(deviceId))
            {
                output.Send(SysExUtils.GetMessage(PartialAddressOffset(partial.Key), partial.GetBytes()));
            }
        }

        #endregion
    }
}