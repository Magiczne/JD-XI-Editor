using System.ComponentModel;

namespace JD_XI_Editor.Models.Enums.Analog
{
    internal enum OscillatorShape : byte
    {
        [Description("Sawtooth")] Saw = 0x00,
        [Description("Triangle")] Triangle = 0x01,
        [Description("Square")] Square = 0x02
    }
}