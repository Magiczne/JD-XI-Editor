using System.ComponentModel;

namespace JD_XI_Editor.Models.Enums.Effects.Compressor
{
    internal enum Release : byte
    {
        [Description("0.05 ms")] ZeroPoint05 = 0x00,
        [Description("0.07 ms")] ZeroPoint07 = 0x01,
        [Description("0.1 ms")] ZeroPoint1,
        [Description("0.5 ms")] ZeroPoint5,
        [Description("1 ms")] One,
        [Description("5 ms")] Five,
        [Description("10 ms")] Ten,
        [Description("17 ms")] Seventeen,
        [Description("25 ms")] TwentyFive,
        [Description("50 ms")] Fifty,
        [Description("75 ms")] SeventyFive,
        [Description("100 ms")] OneHundred,
        [Description("200 ms")] TwoHundred,
        [Description("300 ms")] ThreeHundred,
        [Description("400 ms")] FourHundred,
        [Description("500 ms")] FiveHundred,
        [Description("600 ms")] SixHundred,
        [Description("700 ms")] SevenHundred,
        [Description("800 ms")] EightHundred,
        [Description("900 ms")] NineHundred,
        [Description("1 s")] OneThousand,
        [Description("1,2 s")] OneThousandTwoHundred,
        [Description("1,5 s")] OneThousandFiveHundred,
        [Description("2 s")] TwoThousand
    }
}