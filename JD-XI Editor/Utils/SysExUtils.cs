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
            0x12            // Magic number for sending data to device
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
            0x11            // Magic number for requesting dump from device
        };

        /// <summary>
        ///     Calculates the checksum for the event data
        /// </summary>
        /// <param name="addressOffset">Address offset</param>
        /// <param name="data">Data bytes</param>
        /// <returns>Checksum byte</returns>
        public static byte CalculateChecksum(byte[] addressOffset, byte[] data)
        {
            var sum = addressOffset.Aggregate(0, (current, b) => current + b);
            sum = data.Aggregate(sum, (current, b) => current + b);

            var remainder = sum / 128;
            var checksum = 128 - remainder;

            return (byte) checksum;
        }

        /// <summary>
        ///     Get sysex data for patch data and offset
        /// </summary>
        public static byte[] GetSysexData(byte[] addressOffset, byte[] patchData)
        {
            var bytes = new List<byte>();

            bytes.AddRange(Header);
            bytes.AddRange(addressOffset);
            bytes.AddRange(patchData);
            bytes.Add(CalculateChecksum(addressOffset, patchData));
            bytes.Add(0xF7);

            return bytes.ToArray();
        }

        /// <summary>
        ///     Get sysex data for specified patch
        /// </summary>
        public static byte[] GetRequestDumpData(byte[] addressOffset, byte[] expectedLength)
        {
            var bytes = new List<byte>();

            bytes.AddRange(RequestHeader);

            bytes.AddRange(addressOffset);
            bytes.AddRange(expectedLength);
            bytes.Add(CalculateChecksum(addressOffset, expectedLength));

            bytes.Add(0xF7);

            return bytes.ToArray();
        }

        /// <summary>
        ///     Get sysex message for specified patch data
        /// </summary>
        public static SysExMessage GetMessage(byte[] addressOffset, byte[] patchData)
        {
            return new SysExMessage(GetSysexData(addressOffset, patchData));
        }

        /// <summary>
        ///     Get sysex message for requesting data dump from device
        /// </summary>
        public static SysExMessage GetRequestDumpMessage(byte[] addressOffset, byte[] expectedLength)
        {
            return new SysExMessage(GetRequestDumpData(addressOffset, expectedLength));
        }
    }
}