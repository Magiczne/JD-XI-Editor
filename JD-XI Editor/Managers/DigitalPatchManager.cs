using System;
using System.Timers;
using JD_XI_Editor.Managers.Abstract;
using JD_XI_Editor.Managers.Enums;
using JD_XI_Editor.Managers.Events;
using JD_XI_Editor.Models.Patches;
using JD_XI_Editor.Models.Patches.Digital;
using JD_XI_Editor.Utils;
using Sanford.Multimedia.Midi;

namespace JD_XI_Editor.Managers
{
    internal class DigitalPatchManager : IDigitalPatchManager
    {
        /// <summary>
        ///     Digital synth number
        /// </summary>
        private readonly DigitalSynth _synthNumber;        

        /// <summary>
        ///     Common address offset
        /// </summary>
        private byte[] CommonAddressOffset => new byte[] {0x19, (byte) _synthNumber, 0x00, 0x00};

        /// <summary>
        ///     Common SysEx message length
        /// </summary>
        private static byte[] CommonDumpRequest => new byte[] {0x00, 0x00, 0x00, 0x40};
        
        /// <summary>
        ///     Partial SysEx message length
        /// </summary>
        private static byte[] PartialDumpRequest => new byte[] {0x00, 0x00, 0x00, 0x3D};

        /// <summary>
        ///     Modifiers address offset
        /// </summary>
        private byte[] ModifiersAddressOffset => new byte[] {0x19, (byte) _synthNumber, 0x50, 0x00};

        /// <summary>
        ///     Modifiers SysEx message length
        /// </summary>
        private static byte[] ModifiersDumpRequest => new byte[] {0x00, 0x00, 0x00, 0x25};

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

        /// <inheritdoc />
        public event EventHandler<PatchDumpReceivedEventArgs> DataDumpReceived;

        public DigitalPatchManager(DigitalSynth synthNumber)
        {
            _synthNumber = synthNumber;
        }

        /// <inheritdoc />
        public void Dump(IPatch patch, int deviceId)
        {
            var digitalPatch = (Patch) patch;

            using (var output = new OutputDevice(deviceId))
            {
                output.Send(SysExUtils.GetMessage(CommonAddressOffset, digitalPatch.Common.GetBytes()));

                output.Send(SysExUtils.GetMessage(PartialAddressOffset(DigitalPartial.First), digitalPatch.PartialOne.GetBytes()));
                output.Send(SysExUtils.GetMessage(PartialAddressOffset(DigitalPartial.Second), digitalPatch.PartialTwo.GetBytes()));
                output.Send(SysExUtils.GetMessage(PartialAddressOffset(DigitalPartial.Third), digitalPatch.PartialThree.GetBytes()));

                output.Send(SysExUtils.GetMessage(ModifiersAddressOffset, digitalPatch.Modifiers.GetBytes()));
            }
        }

        /// <inheritdoc />
        public void Read(int inputDeviceId, int outputDeviceId)
        {
            var device = new InputDevice(inputDeviceId);
            var timer = new Timer(5000);

            const int commonDumpLength = ExpectedCommonDumpLength + SysExUtils.DumpPaddingSize;
            const int partialDumpLength = ExpectedPartialDumpLength + SysExUtils.DumpPaddingSize;
            const int modsDumpLength = ExpectedModifiersDumpLength + SysExUtils.DumpPaddingSize;

            SysExMessage common = null;
            var partials = new SysExMessage[] {null, null, null};
            SysExMessage modifiers = null;

            var dumpCount = 0;

            device.SysExMessageReceived += (sender, args) =>
            {
                if (args.Message.Length == commonDumpLength)
                {
                    common = args.Message;
                }
                else if (args.Message.Length == partialDumpLength)
                {
                    // At 11 byte we have partial number, so we check value at that byte
                    var partial = (DigitalPartial) args.Message[10];

                    switch (partial)
                    {
                        case DigitalPartial.First:
                            partials[0] = args.Message;
                            break;

                        case DigitalPartial.Second:
                            partials[1] = args.Message;

                            break;
                        case DigitalPartial.Third:
                            partials[2] = args.Message;
                            break;

                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
                else if (args.Message.Length == modsDumpLength)
                {
                    modifiers = args.Message;
                }

                dumpCount++;

                if (dumpCount == 5)
                {
                    timer.Stop();
                    timer.Dispose();

                    device.StopRecording();
                    device.Dispose();

                    DataDumpReceived?.Invoke(this, new DigitalPatchDumpReceivedEventArgs(new Patch(common, partials, modifiers)));
                }
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
                output.Send(SysExUtils.GetRequestDumpMessage(CommonAddressOffset, CommonDumpRequest));
                output.Send(SysExUtils.GetRequestDumpMessage(PartialAddressOffset(DigitalPartial.First), PartialDumpRequest));
                output.Send(SysExUtils.GetRequestDumpMessage(PartialAddressOffset(DigitalPartial.Second), PartialDumpRequest));
                output.Send(SysExUtils.GetRequestDumpMessage(PartialAddressOffset(DigitalPartial.Third), PartialDumpRequest));
                output.Send(SysExUtils.GetRequestDumpMessage(ModifiersAddressOffset, ModifiersDumpRequest));

                timer.Start();
            }
        }

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

        /// <summary>
        ///     Partial address offset
        /// </summary>
        private byte[] PartialAddressOffset(DigitalPartial partial)
        {
            return new byte[] {0x19, (byte) _synthNumber, (byte) partial, 0x00};
        }
    }
}