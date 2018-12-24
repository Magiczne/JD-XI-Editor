using System;
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

        public DigitalPatchManager(DigitalSynth synthNumber)
        {
            _synthNumber = synthNumber;
        }

        /// <summary>
        ///     Common address offset
        /// </summary>
        private byte[] CommonAddressOffset => new byte[] {0x19, (byte) _synthNumber, 0x00, 0x00};

        /// <summary>
        ///     Common SysEx message length
        /// </summary>
        private byte[] CommonSysExMessageLength => new byte[] {0x00, 0x00, 0x00, 0x40};
        
        /// <summary>
        ///     Partial SysEx message length
        /// </summary>
        private byte[] PartialSysExMessageLength => new byte[] {0x00, 0x00, 0x00, 0x3D};

        /// <summary>
        ///     Modifiers address offset
        /// </summary>
        private byte[] ModifiersAddressOffset => new byte[] {0x19, (byte) _synthNumber, 0x50, 0x00};

        /// <summary>
        ///     Modifiers SysEx message length
        /// </summary>
        private byte[] ModifiersSysExMessageLength => new byte[] {0x00, 0x00, 0x00, 0x25};

        /// <inheritdoc />
        public event EventHandler<PatchDumpReceivedEventArgs> DataDumpReceived;

        /// <inheritdoc />
        public void Dump(IPatch patch, int deviceId)
        {
            var digitalPatch = (Patch) patch;

            using (var output = new OutputDevice(deviceId))
            {
                output.Send(SysExUtils.GetMessage(digitalPatch.Common.GetBytes(), CommonAddressOffset));

                output.Send(SysExUtils.GetMessage(digitalPatch.PartialOne.GetBytes(),
                    PartialAddressOffset(DigitalPartial.First)));
                output.Send(SysExUtils.GetMessage(digitalPatch.PartialTwo.GetBytes(),
                    PartialAddressOffset(DigitalPartial.Second)));
                output.Send(SysExUtils.GetMessage(digitalPatch.PartialThree.GetBytes(),
                    PartialAddressOffset(DigitalPartial.Third)));

                output.Send(SysExUtils.GetMessage(digitalPatch.Modifiers.GetBytes(), ModifiersAddressOffset));
            }
        }

        /// <inheritdoc />
        public void Read(int inputDeviceId, int outputDeviceId)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public void DumpCommon(Common common, int deviceId)
        {
            using (var output = new OutputDevice(deviceId))
            {
                output.Send(SysExUtils.GetMessage(common.GetBytes(), CommonAddressOffset));
            }
        }

        /// <inheritdoc />
        public void DumpPartial(Partial partial, DigitalPartial partialNumber, int deviceId)
        {
            using (var output = new OutputDevice(deviceId))
            {
                output.Send(SysExUtils.GetMessage(partial.GetBytes(), PartialAddressOffset(partialNumber)));
            }
        }

        /// <inheritdoc />
        public void DumpModifiers(Modifiers modifiers, int deviceId)
        {
            using (var output = new OutputDevice(deviceId))
            {
                output.Send(SysExUtils.GetMessage(modifiers.GetBytes(), ModifiersAddressOffset));
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