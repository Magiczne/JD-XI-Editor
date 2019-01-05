using System;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using JD_XI_Editor.Managers.Abstract;
using JD_XI_Editor.Managers.Events;
using JD_XI_Editor.Models.Patches;
using JD_XI_Editor.Models.Patches.Program;
using JD_XI_Editor.Utils;
using Sanford.Multimedia.Midi;
using Timer = System.Timers.Timer;

namespace JD_XI_Editor.Managers
{
    internal class ProgramCommonAndVocalEffectsManager : IProgramCommonAndVocalEffectsManager
    {
        #region Methods

        /// <inheritdoc />
        public ProgramCommonAndVocalEffectsManager()
        {
            _timer.Elapsed += OnTimerElapsed;
        }

        #endregion

        #region Fields

        /// <summary>
        ///     Program common offset address
        /// </summary>
        private readonly byte[] _commonOffset = {0x18, 0x00, 0x00, 0x00};

        /// <summary>
        ///     Auto Note offset address
        /// </summary>
        private readonly byte[] _autoNoteOffset = {0x18, 0x00, 0x00, 0x1E};

        /// <summary>
        ///     VFX offset address
        /// </summary>
        private readonly byte[] _vfxEffectsOffset = {0x18, 0x00, 0x01, 0x00};

        /// <summary>
        ///     Common dump request
        /// </summary>
        private readonly byte[] _commonDumpRequest = {0x00, 0x00, 0x00, 0x1F};

        /// <summary>
        ///     VFX dump request
        /// </summary>
        private readonly byte[] _vfxDumpRequest = {0x00, 0x00, 0x00, 0x18};

        /// <summary>
        ///     Expected common dump length
        /// </summary>
        private const int ExpectedCommonDumpLength = 31;

        /// <summary>
        ///     Expected VFX dump length
        /// </summary>
        private const int ExpectedVfxDumpLength = 24;

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
        ///     Common sysex dump
        /// </summary>
        private SysExMessage _commonDump;

        /// <summary>
        ///     VFX sysex dump
        /// </summary>
        private SysExMessage _vfxDump;

        #endregion

        #region Events

        /// <inheritdoc />
        public event EventHandler<PatchDumpReceivedEventArgs> DataDumpReceived;

        /// <inheritdoc />
        public event EventHandler<TimeoutException> OperationTimedOut;

        #endregion

        #region Callbacks

        /// <summary>
        ///     Callback called when data dump is received from device
        /// </summary>
        private void OnSysExMessageReceived(object sender, SysExMessageEventArgs e)
        {
            if (e.Message.Length == ExpectedCommonDumpLength + SysExUtils.DumpPaddingSize)
                _commonDump = e.Message;
            else if (e.Message.Length == ExpectedVfxDumpLength + SysExUtils.DumpPaddingSize) _vfxDump = e.Message;

            _dumpCount++;

            if (_dumpCount == 2)
            {
                _timer.Stop();

                _device.StopRecording();
                _device.Dispose();

                DataDumpReceived?.Invoke(this,
                    new CommonAndVocalFxDumpReceivedEventArgs(new CommonAndVocalEffectPatch(_commonDump, _vfxDump)));
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
            var vfxPatch = (CommonAndVocalEffectPatch) patch;

            using (var output = new OutputDevice(deviceId))
            {
                output.Send(SysExUtils.GetMessage(_commonOffset, vfxPatch.Common.GetBytes()));
                output.Send(SysExUtils.GetMessage(_vfxEffectsOffset, vfxPatch.VocalEffect.GetBytes()));
                output.Send(SysExUtils.GetMessage(_autoNoteOffset,
                    new[] {ByteUtils.BooleanToByte(vfxPatch.Common.AutoNote)}));
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
                    output.Send(SysExUtils.GetRequestDumpMessage(_commonOffset, _commonDumpRequest));

                    Thread.Sleep(50);  

                    output.Send(SysExUtils.GetRequestDumpMessage(_vfxEffectsOffset, _vfxDumpRequest));
                }
            });
        }

        #endregion

        #region IProgramCommonAndVocalEffectManager

        /// <inheritdoc />
        public void DumpCommon(IPatchPart common, int deviceId)
        {
            using (var output = new OutputDevice(deviceId))
            {
                output.Send(SysExUtils.GetMessage(_commonOffset, common.GetBytes()));
            }
        }

        /// <inheritdoc />
        public void DumpVocalEffects(IPatchPart vocalFx, int deviceId)
        {
            using (var output = new OutputDevice(deviceId))
            {
                output.Send(SysExUtils.GetMessage(_vfxEffectsOffset, vocalFx.GetBytes()));
            }
        }

        /// <inheritdoc />
        public void SetAutoNote(bool value, int deviceId)
        {
            using (var output = new OutputDevice(deviceId))
            {
                output.Send(SysExUtils.GetMessage(_autoNoteOffset, new[] {ByteUtils.BooleanToByte(value)}));
            }
        }

        #endregion
    }
}