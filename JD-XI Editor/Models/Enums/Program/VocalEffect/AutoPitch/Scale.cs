using System.ComponentModel;

namespace JD_XI_Editor.Models.Enums.Program.VocalEffect.AutoPitch
{
    internal enum Scale : byte
    {
        [Description("Chromatic")] Chromatic = 0x0,
        [Description("Major(Minor)")] MajorMinor = 0x1
    }
}