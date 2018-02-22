using System.ComponentModel;

namespace JD_XI_Editor.Models.Enums.Program.VocalEffect.AutoPitch
{
    internal enum Note : byte
    {
        [Description("C")] C = 0x0,
        [Description("C#")] CSharp = 0x1,
        [Description("D")] D,
        [Description("D#")] DSharp,
        [Description("E")] E,
        [Description("F")] F,
        [Description("F#")] FSharp,
        [Description("G")] G,
        [Description("G#")] GSharp,
        [Description("A")] A,
        [Description("A#")] ASharp,
        [Description("B")] B
    }
}