using System.ComponentModel;

namespace JD_XI_Editor.Models.Enums.DrumKit
{
    internal enum DrumKey : byte
    {
        [Description("BD1")] Bd1 = 0x2E,
        [Description("RIM")] Rim = 0x30,
        [Description("BD2")] Bd2 = 0x32,
        [Description("CLAP")] Clap = 0x34,
        [Description("BD3")] Bd3 = 0x36,
        [Description("SD1")] Sd1 = 0x38,
        [Description("CHH")] Chh = 0x3A,
        [Description("SD2")] Sd2 = 0x3C,
        [Description("PHH")] Phh = 0x3E,
        [Description("SD3")] Sd3 = 0x40,
        [Description("OHH")] Ohh = 0x42,
        [Description("SD4")] Sd4 = 0x44,
        [Description("TOM1")] Tom1 = 0x46,
        [Description("PRC1")] Prc1 = 0x48,
        [Description("TOM2")] Tom2 = 0x4A,
        [Description("PRC2")] Prc2 = 0x4C,
        [Description("TOM3")] Tom3 = 0x4E,
        [Description("PRC3")] Prc3 = 0x50,
        [Description("CYM1")] Cym1 = 0x52,
        [Description("PRC4")] Prc4 = 0x54,
        [Description("CYM2")] Cym2 = 0x56,
        [Description("PRC5")] Prc5 = 0x58,
        [Description("CYM3")] Cym3 = 0x5A,
        [Description("HIT")] Hit = 0x5C,
        [Description("OTH1")] Oth1 = 0x5E,
        [Description("OTH2")] Oth2 = 0x60,
        [Description("D4")] D4 = 0x62,
        [Description("D#4")] DSharp4 = 0x64,
        [Description("E4")] E4 = 0x66,
        [Description("F4")] F4 = 0x68,
        [Description("F#4")] FSharp4 = 0x6A,
        [Description("G4")] G4 = 0x6C,
        [Description("G#4")] GSharp4 = 0x6E,
        [Description("A4")] A4 = 0x70,
        [Description("A#4")] ASharp4 = 0x72,
        [Description("B4")] B4 = 0x74,
        [Description("C5")] C5 = 0x76,
        [Description("C#5")] CSharp5 = 0x78
    }
}