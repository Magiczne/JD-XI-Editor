using System.ComponentModel;

namespace JD_XI_Editor.Models.Enums
{
    internal enum SubOscillatorStatus
    {
        [Description("Off")]
        Off,

        [Description("Octave -1")]
        Octave,

        [Description("Octave -2")]
        TwoOctaves
    }
}