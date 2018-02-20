namespace JD_XI_Editor.Utils
{
    internal static class ByteUtils
    {
        public enum Offset
        {
            None = 0x00,
            EffectOffset = 0x8000
        }

        public static byte[] NumberTo4Packets(int val, Offset offset = Offset.EffectOffset)
        {
            var value = val + (int) offset;

            return new[]
            {
                (byte) ((value >> 24) & 0xFF),
                (byte) ((value >> 16) & 0xFF),
                (byte) ((value >> 8) & 0xFF),
                (byte) (value & 0xFF)
            };
        }

        public static byte[] NumberTo4Packets(bool val, Offset offset = Offset.EffectOffset)
        {
            return NumberTo4Packets(val ? 0x01 : 0x00, offset);
        }
    }
}