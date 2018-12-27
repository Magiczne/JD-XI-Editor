using System;
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
        private static readonly byte[] AddressOffset = {0x19, 0x42, 0x00, 0x00};

        /// <summary>
        ///     SysEx message length
        /// </summary>
        private static readonly byte[] DumpRequest = {0x00, 0x00, 0x00, 0x40};

        /// <summary>
        ///     Expected Dump Length
        /// </summary>
        private const int ExpectedDumpLength = 64;

        #endregion

        #region Events

        /// <inheritdoc />
        public event EventHandler<PatchDumpReceivedEventArgs> DataDumpReceived;

        /// <inheritdoc />
        public event EventHandler<TimeoutException> OperationTimedOut;

        #endregion

        /// <inheritdoc />
        public void Dump(IPatch analogPatch, int deviceId)
        {
            using (var output = new OutputDevice(deviceId))
            {
                output.Send(SysExUtils.GetMessage(AddressOffset, analogPatch.GetBytes()));
            }
        }

        /// <inheritdoc />
        public void Read(int inputDeviceId, int outputDeviceId)
        {
            var device = new InputDevice(inputDeviceId);
            var timer = new Timer(1500);

            // Setup event handler for receiving SysEx messages
            device.SysExMessageReceived += (sender, args) =>
            {
                timer.Stop();
                timer.Dispose();

                device.StopRecording();
                device.Dispose();

                var actualLength = args.Message.Length - SysExUtils.DumpPaddingSize;

                if (actualLength != ExpectedDumpLength)
                {
                    throw new InvalidDumpSizeException(ExpectedDumpLength, actualLength);
                }

                DataDumpReceived?.Invoke(this, new AnalogPatchDumpReceivedEventArgs(new Patch(args.Message)));
            };

            timer.Elapsed += (sender, args) =>
            {
                timer.Stop();
                timer.Dispose();

                device.StopRecording();
                device.Dispose();

                OperationTimedOut?.Invoke(this, new TimeoutException("Read data operation timed out"));
            };
    
            // Start recording input from device
            device.StartRecording();

            // Request data dump from device
            using (var output = new OutputDevice(outputDeviceId))
            {
                output.Send(SysExUtils.GetRequestDumpMessage(AddressOffset, DumpRequest));
                timer.Start();
            }
        }
    }
}