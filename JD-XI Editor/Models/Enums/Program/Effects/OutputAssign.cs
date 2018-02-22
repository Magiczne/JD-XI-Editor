using System.ComponentModel;

namespace JD_XI_Editor.Models.Enums.Program.Effects
{
    internal enum OutputAssign : byte
    {
        [Description("Direct")] Direct = 0x0,
        [Description("Effect 2")] Effect2 = 0x1
    }
}