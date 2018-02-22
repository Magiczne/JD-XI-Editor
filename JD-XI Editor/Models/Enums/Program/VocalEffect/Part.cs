using System.ComponentModel;

namespace JD_XI_Editor.Models.Enums.Program.VocalEffect
{
    internal enum Part : byte
    {
        [Description("Digital Synth 1")] DigitalSynth1 = 0x0,
        [Description("Digital Synth 2")] DigitalSynth2 = 0x1
    }
}