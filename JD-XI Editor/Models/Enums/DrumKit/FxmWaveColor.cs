using System.ComponentModel;

namespace JD_XI_Editor.Models.Enums.DrumKit
{
    internal enum FxmWaveColor : byte
    {
        [Description("1")] One = 0x0,
        [Description("2")] Two = 0x1,
        [Description("3")] Three,
        [Description("4")] Four
    }
}