using System.ComponentModel;

namespace JD_XI_Editor.Models.Enums.Program.Effects
{
    internal enum Effect1Type : byte
    {
        [Description("Thru")] Thru = 0x00,

        [Description("Distortion")] Distortion = 0x01,
        [Description("Fuzz")] Fuzz = 0x02,
        [Description("Compressor")] Compressor = 0x03,
        [Description("Bit Crusher")] BitCrusher = 0x04
    }
}
