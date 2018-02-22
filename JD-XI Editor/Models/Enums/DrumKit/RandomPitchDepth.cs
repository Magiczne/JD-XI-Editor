using System.ComponentModel;

namespace JD_XI_Editor.Models.Enums.DrumKit
{
    internal enum RandomPitchDepth : byte
    {
        [Description("0")] Zero = 0x0,
        [Description("1")] One = 0x1,
        [Description("2")] Two,
        [Description("3")] Three,
        [Description("4")] Four,
        [Description("5")] Five,
        [Description("6")] Six,
        [Description("7")] Seven,
        [Description("8")] Eight,
        [Description("9")] Nine,
        [Description("10")] Ten,
        [Description("20")] Twenty,
        [Description("30")] Thirty,
        [Description("40")] Forty,
        [Description("50")] Fifty,
        [Description("60")] Sixty,
        [Description("70")] Seventy,
        [Description("80")] Eighty,
        [Description("90")] Ninety,
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
        [Description("1100")] OneThousandOneHundred,
        [Description("1200")] OneThousandTwoHundred
    }
}