using System.ComponentModel;

namespace JD_XI_Editor.Models.Enums
{
    internal enum LfoShape
    {
        [Description("Triangle")]
        Triangle,

        [Description("Sine")]
        Sine,

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