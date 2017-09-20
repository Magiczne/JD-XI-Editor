    using System.ComponentModel;

namespace JD_XI_Editor.Models.Enums
{
    internal enum LfoShape : byte
    {
        [Description("Triangle")]
        Triangle = 0x00,

        [Description("Sine")]
        Sine = 0x01,

        [Description("Sawtooth")]
        Saw,

        [Description("Square")]
        Square,

        [Description("Sample & Hold")]
        SampleAndHold,

        [Description("Random")]
        Random
    }
}