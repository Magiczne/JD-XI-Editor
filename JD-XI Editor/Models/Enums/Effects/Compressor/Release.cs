using System.ComponentModel;

namespace JD_XI_Editor.Models.Enums.Effects.Compressor
{
    internal enum Release : byte
    {
        [Description("0.05")] ZeroPoint05 = 0x00,
        [Description("0.07")] ZeroPoint07 = 0x01,
        [Description("0.1")] ZeroPoint1,
        [Description("0.5")] ZeroPoint5,
        [Description("1")] One,
        [Description("5")] Five,
        [Description("10")] Ten,
        [Description("17")] Seventeen,
        [Description("25")] TwentyFive,
        [Description("50")] Fifty,
        [Description("75")] SeventyFive,
        [Description("100")] OneHundred,
        [Description("200")] TwoHundred,
        [Description("300")] ThreeHundred,
        [Description("400")] FourHundred,
        [Description("500")] FiveHundred,
        [Description("600")] SixHundred,
        [Description("700")] SevenHundred,
        [Description("800")] EightHundred,
        [Description("900")] NineHundred,
        [Description("1000")] OneThousand,
        [Description("1200")] OneThousandTwoHundred,
        [Description("1500")] OneThousandFiveHundred,
        [Description("2000")] TwoThousand
    }
}