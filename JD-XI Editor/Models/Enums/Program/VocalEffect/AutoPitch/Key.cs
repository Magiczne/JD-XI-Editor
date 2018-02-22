using System.ComponentModel;

namespace JD_XI_Editor.Models.Enums.Program.VocalEffect.AutoPitch
{
    internal enum Key : byte
    {
        [Description("C")] C = 0x00,
        [Description("D♭")] DFlat = 0x01,
        [Description("D")] D,
        [Description("E♭")] EFlat,
        [Description("E")] E,
        [Description("F")] F,
        [Description("F#")] FSharp,
        [Description("G")] G,
        [Description("A♭")] AFlat,
        [Description("A")] A,
        [Description("B♭")] BFlat,
        [Description("Cm")] Cm,
        [Description("C#m")] CmSharp,
        [Description("Dm")] Dm,
        [Description("D#m")] DmSharp,
        [Description("Em")] Em,
        [Description("Fm")] Fm,
        [Description("F#m")] FmSharp,
        [Description("Gm")] Gm,
        [Description("G#m")] GmSharp,
        [Description("Am")] Am,
        [Description("B♭m")] BmFlat,
        [Description("Bm")] Bm
    }
}