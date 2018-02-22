using System.ComponentModel;

namespace JD_XI_Editor.Models.Enums.Program.Effects.Compressor
{
    internal enum Attack : byte
    {
        [Description("0.05 ms")] ZeroPoint05 = 0x00,
        [Description("0.06 ms")] ZeroPoint06 = 0x01,
        [Description("0.07 ms")] ZeroPoint07,
        [Description("0.08 ms")] ZeroPoint08,
        [Description("0.09 ms")] ZeroPoint09,
        [Description("0.1 ms")] ZeroPoint1,
        [Description("0.2 ms")] ZeroPoint2,
        [Description("0.3 ms")] ZeroPoint3,
        [Description("0.4 ms")] ZeroPoint4,
        [Description("0.5 ms")] ZeroPoint5,
        [Description("0.6 ms")] ZeroPoint6,
        [Description("0.7 ms")] ZeroPoint7,
        [Description("0.8 ms")] ZeroPoint8,
        [Description("0.9 ms")] ZeroPoint9,
        [Description("1 ms")] One,
        [Description("2 ms")] Two,
        [Description("3 ms")] Three,
        [Description("4 ms")] Four,
        [Description("5 ms")] Five,
        [Description("6 ms")] Six,
        [Description("7 ms")] Seven,
        [Description("8 ms")] Eight,
        [Description("9 ms")] Nine,
        [Description("10 ms")] Ten,
        [Description("15 ms")] Fifteen,
        [Description("20 ms")] Twenty,
        [Description("25 ms")] TwentyFive,
        [Description("30 ms")] Thirty,
        [Description("35 ms")] ThirtyFive,
        [Description("40 ms")] Forty,
        [Description("45 ms")] FortyFive,
        [Description("50 ms")] Fifty
    }
}