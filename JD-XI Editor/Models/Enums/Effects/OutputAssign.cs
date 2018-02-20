using System.ComponentModel;

namespace JD_XI_Editor.Models.Enums.Effects
{
    internal enum OutputAssign : byte
    {
        [Description("Direct")] Direct = 0x00,
        [Description("Effect 2")] Effect2 = 0x01
    }
}