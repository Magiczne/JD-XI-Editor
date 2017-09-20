using System.Collections.Generic;
using System.Linq;

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
        ///     SysExHeader
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
        ///     Calculates the checksum for the event data
        /// </summary>
        /// <param name="patchData">Patch data bytes</param>
        /// <param name="addressOffset">Address offset bytes</param>
        /// <returns>Checksum byte</returns>
        public static byte CalculateChecksum(IEnumerable<byte> patchData, IEnumerable<byte> addressOffset)
        {
            var sum = addressOffset.Aggregate(0, (current, b) => current + b);
            sum = patchData.Aggregate(sum, (current, b) => current + b);

            var remainder = sum / 128;
            var checksum = 128 - remainder;

            return (byte) checksum;
        }
    }
}