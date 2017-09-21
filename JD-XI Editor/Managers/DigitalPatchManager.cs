using System.Collections.Generic;
using JD_XI_Editor.Models.Patches;
using JD_XI_Editor.Models.Patches.Digital;
using JD_XI_Editor.Utils;
using Sanford.Multimedia.Midi;

namespace JD_XI_Editor.Managers
{
    internal class DigitalPatchManager : IPatchManager
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
            {"Modifiers", new byte[] {0x19, 0x01, 0x50, 0x00}},
        };

        /// <summary>
        ///     Get sysex data for common
        /// </summary>
        public byte[] GetCommonSysexData(Common common)
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
        public byte[] GetPartialSysexData(Partial partial, short partialNumber)
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
        public byte[] GetModifiersSysexData(Modifiers modifiers)
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

        /// <inheritdoc />
        public void Dump(IPatch patch, int deviceId)
        {
            var digitalPatch = (Patch) patch;

            var commonData = GetCommonSysexData(digitalPatch.Common);
            var partial1Data = GetPartialSysexData(digitalPatch.PartialOne, 1);
            var partial2Data = GetPartialSysexData(digitalPatch.PartialOne, 2);
            var partial3Data = GetPartialSysexData(digitalPatch.PartialOne, 3);
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
    }
}