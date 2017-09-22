using System.ComponentModel;

namespace JD_XI_Editor.Models.Enums
{
    internal enum DigitalOscillatorShape : byte
    {
        [Description("Sawtooth")]
        Saw = 0x00,

        [Description("Square")]
        Square = 0x01,

        [Description("Pulse wave square")]
        PulseWaveSquare = 0x02,

        [Description("Triangle")]
        Triangle = 0x03,

        [Description("Sine")]
        Sine = 0x04,

        [Description("Noise")]
        Noise = 0x05,

        [Description("Super-Saw")]
        SuperSaw = 0x06,

        [Description("PCM")]
        Pcm = 0x07
    }
}