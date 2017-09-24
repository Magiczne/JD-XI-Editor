using System.Collections.Generic;
using JD_XI_Editor.Models.Patches;
using JD_XI_Editor.Models.Patches.Digital;
using JD_XI_Editor.Utils;
using Sanford.Multimedia.Midi;

namespace JD_XI_Editor.Managers
{
    internal class DigitalPatchManager : IDigitalPatchManager
    {
        /// <summary>
        ///     Address offsets
        /// </summary>
        private static readonly Dictionary<string, byte[]> AddressOffsets = new Dictionary<string, byte[]>
        {
            {"Common", new byte[] {0x19, 0x01, 0x00, 0x00}},
            {"Partial1", new byte[] {0x19, 0x01, 0x20, 0x00}},
            {"Partial2", new byte[] {0x19, 0x01, 0x21, 0x00}},
            {"Partial3", new byte[] {0x19, 0x01, 0x22, 0x00}},
            {"Modifiers", new byte[] {0x19, 0x01, 0x50, 0x00}}
        };

        /// <summary>
        ///     Get sysex data for common
        /// </summary>
        private static byte[] GetCommonSysexData(Common common)
        {
            var patchBytes = common.GetBytes();

            var bytes = new List<byte>();
            bytes.AddRange(SysExUtils.Header);
            bytes.AddRange(AddressOffsets["Common"]);
            bytes.AddRange(patchBytes);
            bytes.Add(SysExUtils.CalculateChecksum(patchBytes, AddressOffsets["Common"]));
            bytes.Add(0xF7);
            return bytes.ToArray();
        }

        /// <summary>
        ///     Get sysex data for partial
        /// </summary>
        private static byte[] GetPartialSysexData(Partial partial, short partialNumber)
        {
            var patchBytes = partial.GetBytes();
            var key = $"Partial{partialNumber}";

            var bytes = new List<byte>();
            bytes.AddRange(SysExUtils.Header);
            bytes.AddRange(AddressOffsets[key]);
            bytes.AddRange(patchBytes);
            bytes.Add(SysExUtils.CalculateChecksum(patchBytes, AddressOffsets[key]));
            bytes.Add(0xF7);
            return bytes.ToArray();
        }

        /// <summary>
        ///     Get sysex data for modifiers
        /// </summary>
        private static byte[] GetModifiersSysexData(Modifiers modifiers)
        {
            var patchBytes = modifiers.GetBytes();

            var bytes = new List<byte>();
            bytes.AddRange(SysExUtils.Header);
            bytes.AddRange(AddressOffsets["Modifiers"]);
            bytes.AddRange(patchBytes);
            bytes.Add(SysExUtils.CalculateChecksum(patchBytes, AddressOffsets["Modifiers"]));
            bytes.Add(0xF7);
            return bytes.ToArray();
        }

        #region IDigitalPatchManager

        /// <inheritdoc />
        public void Dump(IPatch patch, int deviceId)
        {
            var digitalPatch = (Patch)patch;

            var commonData = GetCommonSysexData(digitalPatch.Common);
            var partial1Data = GetPartialSysexData(digitalPatch.PartialOne, 1);
            var partial2Data = GetPartialSysexData(digitalPatch.PartialTwo, 2);
            var partial3Data = GetPartialSysexData(digitalPatch.PartialThree, 3);
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
        public void DumpCommon(IPatch patch, int deviceId)
        {
            var digitalPatch = (Patch)patch;
            var data = GetCommonSysexData(digitalPatch.Common);

            using (var output = new OutputDevice(deviceId))
            {
                output.Send(new SysExMessage(data));
            }
        }

        /// <inheritdoc />
        public void DumpPartialOne(IPatch patch, int deviceId)
        {
            var digitalPatch = (Patch)patch;
            var data = GetPartialSysexData(digitalPatch.PartialOne, 1);

            using (var output = new OutputDevice(deviceId))
            {
                output.Send(new SysExMessage(data));
            }
        }

        /// <inheritdoc />
        public void DumpPartialTwo(IPatch patch, int deviceId)
        {
            var digitalPatch = (Patch)patch;
            var data = GetPartialSysexData(digitalPatch.PartialTwo, 2);

            using (var output = new OutputDevice(deviceId))
            {
                output.Send(new SysExMessage(data));
            }
        }

        /// <inheritdoc />
        public void DumpPartialThree(IPatch patch, int deviceId)
        {
            var digitalPatch = (Patch)patch;
            var data = GetPartialSysexData(digitalPatch.PartialThree, 3);

            using (var output = new OutputDevice(deviceId))
            {
                output.Send(new SysExMessage(data));
            }
        }

        /// <inheritdoc />
        public void DumpModifiers(IPatch patch, int deviceId)
        {
            var digitalPatch = (Patch)patch;
            var data = GetModifiersSysexData(digitalPatch.Modifiers);

            using (var output = new OutputDevice(deviceId))
            {
                output.Send(new SysExMessage(data));
            }
        }

        #endregion
    }
}