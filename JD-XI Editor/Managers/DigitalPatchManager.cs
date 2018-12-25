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
            throw new NotImplementedException();
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