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
        /// <summary>
        ///     Address offset
        /// </summary>
        private static readonly byte[] AddressOffset = {0x19, 0x42, 0x00, 0x00};

        /// <summary>
        ///     SysEx message length
        /// </summary>
        private static readonly byte[] SysExMessageLength = {0x00, 0x00, 0x00, 0x40};

        /// <inheritdoc />
        public event EventHandler<PatchDumpReceivedEventArgs> DataDumpReceived;

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

                var expectedLength = ByteUtils.ToInt32(SysExMessageLength);
                var actualLength = args.Message.Length - SysExUtils.DumpPaddingSize;

                if (actualLength != expectedLength)
                {
                    throw new InvalidDumpSizeException(expectedLength, actualLength);
                }

                DataDumpReceived?.Invoke(this, new AnalogPatchDumpReceivedEventArgs(new Patch(args.Message)));
            };

            timer.Elapsed += (sender, args) =>
            {
                timer.Stop();
                timer.Dispose();

                device.StopRecording();
                device.Dispose();

                throw new TimeoutException("Read data operation timeout");
            };
    
            // Start recording input from device
            device.StartRecording();

            // Request data dump from device
            using (var output = new OutputDevice(outputDeviceId))
            {
                output.Send(SysExUtils.GetRequestDumpMessage(AddressOffset, SysExMessageLength));
                timer.Start();
            }
        }
    }
}