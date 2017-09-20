using System.ComponentModel;

namespace JD_XI_Editor.Models.Enums
{
    internal enum AnalogOscillatorShape
    {
        [Description("Sawtooth")]
        Saw = 0x00,

        [Description("Triangle")]
        Triangle = 0x01,

        [Description("Square")]
        Square = 0x02
    }
}