using System.ComponentModel;

namespace JD_XI_Editor.Models.Enums.DrumKit
{
    internal enum VelocityCurve : byte
    {
        [Description("Fixed")] Fixed = 0x00,
        [Description("1")] One = 0x01,
        [Description("2")] Two,
        [Description("3")] Three,
        [Description("4")] Four,
        [Description("5")] Five,
        [Description("6")] Six,
        [Description("7")] Seven,
    }
}