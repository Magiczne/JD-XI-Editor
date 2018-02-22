using System.Collections.Generic;
using JD_XI_Editor.Managers.Enums;
using JD_XI_Editor.Models.Patches;
using JD_XI_Editor.Models.Patches.Digital;
using JD_XI_Editor.Utils;
using Sanford.Multimedia.Midi;

namespace JD_XI_Editor.Managers
{
    internal class DigitalPatchManager : IDigitalPatchManager
    {
        public DigitalPatchManager(DigitalSynth synthNumber)
        {
            _synthNumber = synthNumber;
        }

        #region Fields

        /// <summary>
        ///     Digital synth number
        /// </summary>
        private readonly DigitalSynth _synthNumber;

        /// <summary>
        ///     Common address offset
        /// </summary>
        private IEnumerable<byte> CommonAddressOffset => new byte[] {0x19, (byte) _synthNumber, 0x00, 0x00};

        /// <summary>
        ///     Partial address offset
        /// </summary>
        private byte[] PartialAddressOffset(DigitalPartial partial) => new byte[] { 0x19, (byte)_synthNumber, (byte)partial, 0x00 };

        /// <summary>
        ///     Modifiers address offset
        /// </summary>
        private IEnumerable<byte> ModifiersAddressOffset => new byte[] { 0x19, (byte) _synthNumber, 0x50, 0x00 };

        #endregion

        #region Methods

        /// <summary>
        ///     Get sysex data for common
        /// </summary>
        private byte[] GetCommonSysexData(IPatchPart common)
        {
            var patchBytes = common.GetBytes();

            var bytes = new List<byte>();
            bytes.AddRange(SysExUtils.Header);
            bytes.AddRange(CommonAddressOffset);
            bytes.AddRange(patchBytes);
            bytes.Add(SysExUtils.CalculateChecksum(patchBytes, CommonAddressOffset));
            bytes.Add(0xF7);
            return bytes.ToArray();
        }

        /// <summary>
        ///     Get sysex data for partial
        /// </summary>
        private byte[] GetPartialSysexData(IPatchPart partial, DigitalPartial partialNumber)
        {
            var patchBytes = partial.GetBytes();
            var offset = PartialAddressOffset(partialNumber);

            var bytes = new List<byte>();
            bytes.AddRange(SysExUtils.Header);
            bytes.AddRange(offset);
            bytes.AddRange(patchBytes);
            bytes.Add(SysExUtils.CalculateChecksum(patchBytes, offset));
            bytes.Add(0xF7);
            return bytes.ToArray();
        }

        /// <summary>
        ///     Get sysex data for modifiers
        /// </summary>
        private byte[] GetModifiersSysexData(IPatchPart modifiers)
        {
            var patchBytes = modifiers.GetBytes();

            var bytes = new List<byte>();
            bytes.AddRange(SysExUtils.Header);
            bytes.AddRange(ModifiersAddressOffset);
            bytes.AddRange(patchBytes);
            bytes.Add(SysExUtils.CalculateChecksum(patchBytes, ModifiersAddressOffset));
            bytes.Add(0xF7);
            return bytes.ToArray();
        }

        #endregion

        #region IDigitalPatchManager

        /// <inheritdoc />
        public void Dump(IPatch patch, int deviceId)
        {
            var digitalPatch = (Patch)patch;

            var commonData = GetCommonSysexData(digitalPatch.Common);
            var partial1Data = GetPartialSysexData(digitalPatch.PartialOne, DigitalPartial.First);
            var partial2Data = GetPartialSysexData(digitalPatch.PartialTwo, DigitalPartial.Second);
            var partial3Data = GetPartialSysexData(digitalPatch.PartialThree, DigitalPartial.Third);
            var modifiersData = GetModifiersSysexData(digitalPatch.Modifiers);

            using (var output = new OutputDevice(deviceId))
            {
                output.Send(new SysExMessage(commonData));
                output.Send(new SysExMessage(partial1Data));
                output.Send(new SysExMessage(partial2Data));
                output.Send(new SysExMessage(partial3Data));
                output.Send(new SysExMessage(modifiersData));
            }
        }

        /// <inheritdoc />
        public void DumpCommon(Common common, int deviceId)
        {
            var data = GetCommonSysexData(common);

            using (var output = new OutputDevice(deviceId))
            {
                output.Send(new SysExMessage(data));
            }
        }

        /// <inheritdoc />
        public void DumpPartial(Partial partial, DigitalPartial partialNumber, int deviceId)
        {
            var data = GetPartialSysexData(partial, partialNumber);

            using (var output = new OutputDevice(deviceId))
            {
                output.Send(new SysExMessage(data));
            }
        }

        /// <inheritdoc />
        public void DumpModifiers(Modifiers modifiers, int deviceId)
        {
            var data = GetModifiersSysexData(modifiers);

            using (var output = new OutputDevice(deviceId))
            {
                output.Send(new SysExMessage(data));
            }
        }

        #endregion
    }
}