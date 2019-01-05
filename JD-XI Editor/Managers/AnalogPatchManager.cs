using System;
using System.Threading.Tasks;
using System.Timers;
using JD_XI_Editor.Exceptions;
using JD_XI_Editor.Managers.Abstract;
using JD_XI_Editor.Managers.Events;
using JD_XI_Editor.Models.Patches;
using JD_XI_Editor.Models.Patches.Analog;
using JD_XI_Editor.Utils;
using Sanford.Multimedia.Midi;

namespace JD_XI_Editor.Managers
{
    internal class AnalogPatchManager : IPatchManager
    {
        #region Fields

        /// <summary>
        ///     Address offset
        /// </summary>
        private readonly byte[] _addressOffset = {0x19, 0x42, 0x00, 0x00};

        /// <summary>
        ///     SysEx message length
        /// </summary>
        private readonly byte[] _dumpRequest = {0x00, 0x00, 0x00, 0x40};

        /// <summary>
        ///     Expected Dump Length
        /// </summary>
        private const int ExpectedDumpLength = 64;

        /// <summary>
        ///     Timer used to determine timeouts when reading data from device
        /// </summary>
        private readonly Timer _timer = new Timer(4000);

        /// <summary>
        ///     Device instance
        /// </summary>
        private InputDevice _device;

        #endregion

        #region Events

        /// <inheritdoc />
        public event EventHandler<PatchDumpReceivedEventArgs> DataDumpReceived;

        /// <inheritdoc />
        public event EventHandler<TimeoutException> OperationTimedOut;

        #endregion

        #region Methods

        /// <summary>
        ///     Create new instance of AnalogPatchManager
        /// </summary>
        public AnalogPatchManager()
        {
            _timer.Elapsed += OnTimerElapsed;
        }

        #endregion

        #region Callbacks

        /// <summary>
        ///     Callback called when data dump is received from device
        /// </summary>
        private void OnSysExMessageReceived(object sender, SysExMessageEventArgs e)
        {
            _timer.Stop();

            _device.StopRecording();
            _device.Dispose();

            var actualLength = e.Message.Length - SysExUtils.DumpPaddingSize;

            if (actualLength != ExpectedDumpLength)
            {
                throw new InvalidDumpSizeException(ExpectedDumpLength, actualLength);
            }

            DataDumpReceived?.Invoke(this, new AnalogPatchDumpReceivedEventArgs(new Patch(e.Message)));
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
        public void Dump(IPatch analogPatch, int deviceId)
        {
            using (var output = new OutputDevice(deviceId))
            {
                output.Send(SysExUtils.GetMessage(_addressOffset, analogPatch.GetBytes()));
            }
        }

        /// <inheritdoc />
        public void Read(int inputDeviceId, int outputDeviceId)
        {
            _device = new InputDevice(inputDeviceId);

            // Setup event handler for receiving SysEx messages
            _device.SysExMessageReceived += OnSysExMessageReceived;
    
            // Start recording input from device
            _device.StartRecording();

            // Request data dump from device on separate thread
            Task.Run(() =>
            {
                using (var output = new OutputDevice(outputDeviceId))
                {
                    output.Send(SysExUtils.GetRequestDumpMessage(_addressOffset, _dumpRequest));

                    _timer.Start();
                }
            });
        }

        #endregion
    }
}