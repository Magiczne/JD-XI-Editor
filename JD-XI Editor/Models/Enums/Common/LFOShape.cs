using System.ComponentModel;

namespace JD_XI_Editor.Models.Enums.Common
{
    internal enum LfoShape : byte
    {
        [Description("Triangle")] Triangle = 0x0,
        [Description("Sine")] Sine = 0x1,
        [Description("Sawtooth")] Saw,
        [Description("Square")] Square,
        [Description("Sample & Hold")] SampleAndHold,
        [Description("Random")] Random
    }
}