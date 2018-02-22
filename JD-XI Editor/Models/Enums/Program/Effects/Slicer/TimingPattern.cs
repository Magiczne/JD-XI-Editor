using System.ComponentModel;

namespace JD_XI_Editor.Models.Enums.Program.Effects.Slicer
{
    internal enum TimingPattern : byte
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
        [Description("11")] Eleven,
        [Description("12")] Twelve,
        [Description("13")] Thirteen,
        [Description("14")] Fourteen,
        [Description("15")] Fifteen
    }
}