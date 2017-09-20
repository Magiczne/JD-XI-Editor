using System.Collections.Generic;
using JD_XI_Editor.Models.Patches.Analog;
using JD_XI_Editor.Utils;

namespace JD_XI_Editor.Managers
{
    internal class AnalogPatchManager
    {
        /// <summary>
        ///     Address offset
        /// </summary>
        private static readonly byte[] AddressOffset = {0x19, 0x42, 0x00, 0x00};

        /// <summary>
        ///     Get sysex event data
        /// </summary>
        /// <param name="patch">Analog patch</param>
        /// <returns>Bytes of the sysex event</returns>
        public byte[] GetPatchMidiData(AnalogPatch patch)
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
    }
}