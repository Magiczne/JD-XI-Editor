using System.Collections.Generic;
using System.Linq;
using Sanford.Multimedia.Midi;

namespace JD_XI_Editor.Utils
{
    internal static class SysExUtils
    {
        /// <summary>
        ///     Producer ID (Roland)
        /// </summary>
        private const byte ProducerId = 0x41;

        /// <summary>
        ///     Model ID (JD-XI)
        /// </summary>
        private static readonly byte[] ModelId = {0x00, 0x00, 0x00, 0x0E};

        /// <summary>
        ///     Header for dumping data to device
        /// </summary>
        public static IEnumerable<byte> Header => new byte[]
        {
            0xF0,
            ProducerId,
            0x10,
            ModelId[0],
            ModelId[1],
            ModelId[2],
            ModelId[3],
            0x12
        };

        /// <summary>
        ///     Header for requesting data from device
        /// </summary>
        public static IEnumerable<byte> RequestHeader => new byte[]
        {
            0xF0,
            ProducerId,
            0x10,
            ModelId[0],
            ModelId[1],
            ModelId[2],
            ModelId[3],
            0x11
        };

        /// <summary>
        ///     Calculates the checksum for the event data
        /// </summary>
        /// <param name="patchData">Patch data bytes</param>
        /// <param name="addressOffset">Address offset bytes</param>
        /// <returns>Checksum byte</returns>
        public static byte CalculateChecksum(byte[] patchData, byte[] addressOffset)
        {
            var sum = addressOffset.Aggregate(0, (current, b) => current + b);
            sum = patchData.Aggregate(sum, (current, b) => current + b);

            var remainder = sum / 128;
            var checksum = 128 - remainder;

            return (byte) checksum;
        }

        /// <summary>
        ///     Get sysex data for patch data and offset
        /// </summary>
        public static byte[] GetSysexData(byte[] patchData, byte[] addressOffset)
        {
            var bytes = new List<byte>();

            bytes.AddRange(Header);
            bytes.AddRange(addressOffset);
            bytes.AddRange(patchData);
            bytes.Add(CalculateChecksum(patchData, addressOffset));
            bytes.Add(0xF7);

            return bytes.ToArray();
        }

        /// <summary>
        ///     Get sysex message for specified data
        /// </summary>
        public static SysExMessage GetMessage(byte[] patchData, byte[] addressOffset)
        {
            return new SysExMessage(GetSysexData(patchData, addressOffset));
        }
    }
}