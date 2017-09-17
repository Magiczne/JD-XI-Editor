using System.ComponentModel;

namespace JD_XI_Editor.Models.Enums
{
    internal enum AnalogOscillatorShape
    {
        [Description("Sawtooth")]
        Saw,

        [Description("Triangle")]
        Triangle,

        [Description("Square")]
        Square
    }
}