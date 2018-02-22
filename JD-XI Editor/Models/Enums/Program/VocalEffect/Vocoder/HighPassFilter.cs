using System.ComponentModel;

namespace JD_XI_Editor.Models.Enums.Program.VocalEffect.Vocoder
{
    internal enum HighPassFilter : byte
    {
        [Description("Bypass")] Bypass = 0x00,
        [Description("1000 Hz")] Hpf1000 = 0x01,
        [Description("1250 Hz")] Hpf1250,
        [Description("1600 Hz")] Hpf1600,
        [Description("2000 Hz")] Hpf2000,
        [Description("2500 Hz")] Hpf2500,
        [Description("3150 Hz")] Hpf3150,
        [Description("4000 Hz")] Hpf4000,
        [Description("5000 Hz")] Hpf5000,
        [Description("6300 Hz")] Hpf6300,
        [Description("8000 Hz")] Hpf8000,
        [Description("10000 Hz")] Hpf10000,
        [Description("12500 Hz")] Hpf12500,
        [Description("16000 Hz")] Hpf16000
    }
}