using System.ComponentModel;

namespace JD_XI_Editor.Models.Enums.DrumKit
{
    internal enum MuteGroup : byte
    {
        [Description("Off")] Off = 0x00,
        [Description("1")] One = 0x01,
        [Description("2")] Two,
        [Description("3")] Three,
        [Description("4")] Four,
        [Description("5")] Five,
        [Description("6")] Six,
        [Description("7")] Seven,
        [Description("8")] Eight,
        [Description("9")] Nine,
        [Description("10")] Ten,
        [Description("11")] Eleven,
        [Description("12")] Twelve,
        [Description("13")] Thirteen,
        [Description("14")] Fourteen,
        [Description("15")] Fifteen,
        [Description("16")] Sixteen,
        [Description("17")] Seventeen,
        [Description("18")] Eighteen,
        [Description("19")] Nineteen,
        [Description("20")] Twenty,
        [Description("21")] TwentyOne,
        [Description("22")] TwentyTwo,
        [Description("23")] TwentyThree,
        [Description("24")] TwentyFour,
        [Description("25")] TwentyFive,
        [Description("26")] TwentySix,
        [Description("27")] TwentySeve,
        [Description("28")] TwentyEight,
        [Description("29")] TwentyNine,
        [Description("30")] Thirty,
        [Description("31")] ThirtyOne
    }
}