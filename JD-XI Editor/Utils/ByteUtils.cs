using System.Collections.Generic;

namespace JD_XI_Editor.Utils
{
    internal static class ByteUtils
    {
        /// <summary>
        ///     Offset for the
        /// </summary>
        public enum Offset
        {
            None = 0,
            EffectOffset = 0x8000
        }

        /// <summary>
        ///     Split number to 4 packets
        /// </summary>
        public static byte[] NumberTo4Packets(int val, Offset offset = Offset.EffectOffset)
        {
            var value = val + (int) offset;

            return new[]
            {
                (byte) ((value >> 12) & 0xF),
                (byte) ((value >> 8) & 0xF),
                (byte) ((value >> 4) & 0xF),
                (byte) (value & 0xF)
            };
        }

        /// <summary>
        ///     Parse boolean to 4 packets
        /// </summary>
        public static byte[] NumberTo4Packets(bool val, Offset offset = Offset.EffectOffset)
        {
            return NumberTo4Packets(val ? 0x1 : 0x0, offset);
        }

        /// <summary>
        ///     Generate 4 packets reserve
        /// </summary>
        public static byte[] Repeat4PacketsReserve(int count, Offset offset = Offset.EffectOffset)
        {
            var bytes = new List<byte>();
            var value = NumberTo4Packets((int) offset);

            for (var i = 0; i < count; i++)
            {
                bytes.AddRange(value);
            }

            return bytes.ToArray();
        }
    }
}