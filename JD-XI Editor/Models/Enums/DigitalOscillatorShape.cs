using System.ComponentModel;

namespace JD_XI_Editor.Models.Enums
{
    public enum DigitalOscillatorShape : byte
    {
        [Description("Sawtooth")]
        Saw = 0x00,

        [Description("Square")]
        Square = 0x02,

        [Description("Pulse wave square")]
        PulseWaveSquare = 0x03,

        [Description("Triangle")]
        Triangle = 0x04,

        [Description("Sine")]
        Sine = 0x05,

        [Description("Noise")]
        Noise = 0x06,

        [Description("Super-Saw")]
        SuperSaw = 0x06,

        [Description("PCM")]
        Pcm = 0x07
    }
}