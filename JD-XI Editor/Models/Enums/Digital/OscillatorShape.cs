using System.ComponentModel;

namespace JD_XI_Editor.Models.Enums.Digital
{
    internal enum OscillatorShape : byte
    {
        [Description("Sawtooth")] Saw = 0x0,
        [Description("Square")] Square = 0x1,
        [Description("Pulse wave square")] PulseWaveSquare,
        [Description("Triangle")] Triangle,
        [Description("Sine")] Sine,
        [Description("Noise")] Noise,
        [Description("Super-Saw")] SuperSaw,
        [Description("PCM")] Pcm
    }
}