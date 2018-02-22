using System.ComponentModel;

namespace JD_XI_Editor.Models.Enums.Program.VocalEffect
{
    internal enum OutputAssign : byte
    {
        [Description("Effect 1")] Effect1 = 0x0,
        [Description("Effect 2")] Effect2 = 0x1,
        [Description("Delay")] Delay,
        [Description("Reverb")] Reverb,
        [Description("Direct")] Direct
    }
}