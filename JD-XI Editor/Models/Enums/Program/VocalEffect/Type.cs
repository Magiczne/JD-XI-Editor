using System.ComponentModel;

namespace JD_XI_Editor.Models.Enums.Program.VocalEffect
{
    internal enum Type : byte
    {
        [Description("Off")] Off = 0x0,
        [Description("Vocoder")] Vocoder = 0x1,
        [Description("Auto Pitch")] AutoPitch
    }
}