using System.Collections.Generic;
using JD_XI_Editor.Managers.Abstract;
using JD_XI_Editor.Models.Patches;
using JD_XI_Editor.Utils;
using Sanford.Multimedia.Midi;

namespace JD_XI_Editor.Managers
{
    internal class ProgramCommonManager : IProgramCommonManager
    {
        /// <summary>
        ///     Program Common offset address
        /// </summary>
        private static readonly byte[] AddressOffset = { 0x18, 0x00, 0x00, 0x00 };

        /// <summary>
        ///     Get sysex data
        /// </summary>
        private static byte[] GetSysexData(IPatch patch)
        {
            var patchBytes = patch.GetBytes();

            var bytes = new List<byte>();
            bytes.AddRange(SysExUtils.Header);
            bytes.AddRange(AddressOffset);
            bytes.AddRange(patchBytes);
            bytes.Add(SysExUtils.CalculateChecksum(patchBytes, AddressOffset));
            bytes.Add(0xF7);

            return bytes.ToArray();
        }

        /// <inheritdoc />
        public void Dump(IPatch patch, int deviceId)
        {
            var data = GetSysexData(patch);

            using (var output = new OutputDevice(deviceId))
            {
                output.Send(new SysExMessage(data));
            }
        }
    }
}