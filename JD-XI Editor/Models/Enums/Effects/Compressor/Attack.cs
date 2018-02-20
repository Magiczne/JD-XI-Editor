using System.ComponentModel;

namespace JD_XI_Editor.Models.Enums.Effects.Compressor
{
    internal enum Attack : byte
    {
        //TODO: Values
        [Description("0.05")] ZeroPoint05,
        [Description("0.06")] ZeroPoint06,
        [Description("0.07")] ZeroPoint07,
        [Description("0.08")] ZeroPoint08,
        [Description("0.09")] ZeroPoint09,
        [Description("0.1")] ZeroPoint1,
        [Description("0.2")] ZeroPoint2,
        [Description("0.3")] ZeroPoint3,
        [Description("0.4")] ZeroPoint4,
        [Description("0.5")] ZeroPoint5,
        [Description("0.6")] ZeroPoint6,
        [Description("0.7")] ZeroPoint7,
        [Description("0.8")] ZeroPoint8,
        [Description("0.9")] ZeroPoint9,
        [Description("1")] One,
        [Description("2")] Two,
        [Description("3")] Three,
        [Description("4")] Four,
        [Description("5")] Five,
        [Description("6")] Six,
        [Description("7")] Seven,
        [Description("8")] Eight,
        [Description("9")] Nine,
        [Description("10")] Ten,
        [Description("15")] Fifteen,
        [Description("20")] Twenty,
        [Description("25")] TwentyFive,
        [Description("30")] Thirty,
        [Description("35")] ThirtyFive,
        [Description("40")] Forty,
        [Description("45")] FortyFive,
        [Description("50")] Fifty
    }
}