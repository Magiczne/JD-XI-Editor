using System.ComponentModel;

namespace JD_XI_Editor.Models.Enums.Effects.Compressor
{
    internal enum Ratio : byte
    {
        //TODO: Values
        [Description("1:1")] OneToOne,
        [Description("2:1")] TwoToOne,
        [Description("3:1")] ThreeToOne,
        [Description("4:1")] FourToOne,
        [Description("5:1")] FiveToOne,
        [Description("6:1")] SixToOne,
        [Description("7:1")] SevenToOne,
        [Description("8:1")] EightToOne,
        [Description("9:1")] NineToOne,
        [Description("10:1")] TenToOne,
        [Description("20:1")] TwentyToOne,
        [Description("30:1")] ThirtyToOne,
        [Description("40:1")] FortyToOne,
        [Description("50:1")] FiftyToOne,
        [Description("60:1")] SixtyToOne,
        [Description("70:1")] SeventyToOne,
        [Description("80:1")] EightyToOne,
        [Description("90:1")] NinetyToOne,
        [Description("100:1")] HundredToOne,
        [Description("∞:1")] InfinityToOne
    }
}