using System.ComponentModel;

namespace JD_XI_Editor.Models.Enums.Program.Effects.Reverb
{
    internal enum Type : byte
    {
        [Description("Room 1")] Room1 = 0x0,
        [Description("Room 2")] Room2 = 0x1,
        [Description("Stage 1")] Stage1,
        [Description("Stage 2")] Stage2,
        [Description("Hall 1")] Hall1,
        [Description("Hall 2")] Hall2
    }
}