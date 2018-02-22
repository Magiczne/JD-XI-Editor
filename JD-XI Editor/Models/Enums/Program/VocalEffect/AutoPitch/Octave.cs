using System.ComponentModel;

namespace JD_XI_Editor.Models.Enums.Program.VocalEffect.AutoPitch
{
    internal enum Octave : byte
    {
        [Description("-1")] MinusOne = 0x0,
        [Description("0")] Zero = 0x1,
        [Description("+1")] PlusOne
    }
}