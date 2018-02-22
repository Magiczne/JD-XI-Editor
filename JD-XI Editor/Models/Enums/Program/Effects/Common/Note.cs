using System.ComponentModel;

namespace JD_XI_Editor.Models.Enums.Program.Effects.Common
{
    internal enum Note : byte
    {
        [Description("1/96")] OneNinetySixth = 0x0,
        [Description("1/64")] OneSixtyFourth = 0x1,
        [Description("1/48")] OneFortyEight,
        [Description("1/32")] OneThirtySecond,
        [Description("1/24")] OneTwentyFourth,
        [Description("3/64")] ThreeSixtyFourths,
        [Description("1/16")] OneSixteenth,
        [Description("1/12")] OneTwelfth,
        [Description("3/32")] ThreeThirtySeconds,
        [Description("1/8")] OneEight,
        [Description("1/6")] OneSixth,
        [Description("3/16")] ThreeSixteenths,
        [Description("1/4")] OneFourth,
        [Description("1/3")] OneThird,
        [Description("3/8")] ThreeEights,
        [Description("1/2")] OneHalf,
        [Description("2/3")] TwoThirds,
        [Description("3/4")] ThreeFourths,
        [Description("1")] One,
        [Description("4/3")] FourThirds,
        [Description("3/2")] ThreeHalfs,
        [Description("2")] Two
    }
}