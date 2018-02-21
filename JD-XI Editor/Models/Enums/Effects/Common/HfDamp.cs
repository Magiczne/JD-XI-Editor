using System.ComponentModel;

namespace JD_XI_Editor.Models.Enums.Effects.Common
{
    internal enum HfDamp : byte
    {
        [Description("200 Hz")] Damp200 = 0x0,
        [Description("250 Hz")] Damp250 = 0x1,
        [Description("315 Hz")] Damp315,
        [Description("400 Hz")] Damp400,
        [Description("500 Hz")] Damp500,
        [Description("630 Hz")] Damp630,
        [Description("800 Hz")] Damp800,
        [Description("1000 Hz")] Damp1000,
        [Description("1250 Hz")] Damp1250,
        [Description("1600 Hz")] Damp1600,
        [Description("2000 Hz")] Damp2000,
        [Description("2500 Hz")] Damp2500,
        [Description("3150 Hz")] Damp3150,
        [Description("4000 Hz")] Damp4000,
        [Description("5000 Hz")] Damp5000,
        [Description("6300 Hz")] Damp6300,
        [Description("8000 Hz")] Damp8000,
        [Description("Bypass")] Bypass
    }
}