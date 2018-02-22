using System.ComponentModel;

namespace JD_XI_Editor.Models.Enums.Program.Effects.Fuzz
{
    internal enum Type : byte
    {
        [Description("0")] Zero = 0x00,
        [Description("1")] One = 0x01,
        [Description("2")] Two,
        [Description("3")] Three,
        [Description("4")] Four,
        [Description("5")] Five
    }
}