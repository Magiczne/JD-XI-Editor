using System;
using System.Collections.Generic;
using System.Linq;
using BitConverter = System.BitConverter;

namespace JD_XI_Editor.Utils
{
    public static class ByteUtils
    {
        #region MyRegion

        /// <summary>
        ///     Parse boolean to byte value
        /// </summary>
        public static byte BooleanToByte(bool value)
        {
            return (byte) (value ? 0x1 : 0x0);
        }
        
        /// <summary>
        ///     Parse byte to boolean
        /// </summary>
        public static bool ByteToBoolean(byte value)
        {
            return value > 0x00;
        }

        /// <summary>
        ///     Generate reserve block
        /// </summary>
        public static IEnumerable<byte> RepeatReserve(int count, byte value = 0x00)
        {
            return Enumerable.Repeat(value, count);
        }

        #endregion

        #region 4 Packet numbers 

        /// <summary>
        ///     Offset for the
        /// </summary>
        public enum Offset
        {
            None = 0,
            EffectOffset = 0x8000
        }

        /// <summary>
        ///     Convert midi number packet consisting of four bytes to number
        /// </summary>
        public static int NumberFrom4MidiPackets(byte[] packets, Offset offset = Offset.EffectOffset)
        {
            if (packets.Length != 4)
            {
                throw new ArgumentException("Packet should have 4 bytes of length");
            }

            return (packets[0] << 12 | packets[1] << 8 | packets[2] << 4 | packets[3]) - (int) offset;
        }

        /// <summary>
        ///     Convert midi number packet consisting of four bytes to boolean
        /// </summary>
        public static bool BooleanFrom4MidiPackets(byte[] packets, Offset offset = Offset.EffectOffset)
        {
            return NumberFrom4MidiPackets(packets, offset) > 0;
        }

        /// <summary>
        ///     Split number to 4 packets
        /// </summary>
        public static byte[] NumberTo4MidiPackets(int val, Offset offset = Offset.EffectOffset)
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
        public static byte[] BooleanTo4MidiPackets(bool val, Offset offset = Offset.EffectOffset)
        {
            return NumberTo4MidiPackets(BooleanToByte(val), offset);
        }

        /// <summary>
        ///     Generate 4 packets reserve
        /// </summary>
        public static byte[] Repeat4MidiPacketsReserve(int count, Offset offset = Offset.EffectOffset)
        {
            var bytes = new List<byte>();
            var value = NumberTo4MidiPackets((int) offset);

            for (var i = 0; i < count; i++)
            {
                bytes.AddRange(value);
            }

            return bytes.ToArray();
        }

        #endregion

        #region BitConverter Utils

        /// <summary>
        ///     Wrapper for <see cref="BitConverter.ToInt32">BitConverter.ToInt32</see>
        ///     To automatically check for system endianness.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        public static int ToInt32(byte[] value, int startIndex = 0)
        {
            return BitConverter.IsLittleEndian
                ? BitConverter.ToInt32(value.Reverse().ToArray(), 0)
                : BitConverter.ToInt32(value, 0);
        }

        #endregion
    }
}