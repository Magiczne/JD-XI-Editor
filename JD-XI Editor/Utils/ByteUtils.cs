namespace JD_XI_Editor.Utils
{
    internal static class ByteUtils
    {
        public enum Offset
        {
            None = 0,
            EffectOffset = 0x8000
        }

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

        public static byte[] NumberTo4Packets(bool val, Offset offset = Offset.EffectOffset)
        {
            return NumberTo4Packets(val ? 0x01 : 0x00, offset);
        }
    }
}