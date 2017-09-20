using System.ComponentModel;

namespace JD_XI_Editor.Models.Enums
{
    internal enum SubOscillatorStatus
    {
        [Description("Off")]
        Off = 0x00,

        [Description("Octave -1")]
        Octave = 0x01,

        [Description("Octave -2")]
        TwoOctaves = 0x02
    }
}