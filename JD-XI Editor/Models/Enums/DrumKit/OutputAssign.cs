using System.ComponentModel;

namespace JD_XI_Editor.Models.Enums.DrumKit
{
    internal enum OutputAssign : byte
    {
        [Description("FX 1")] EffectOne = 0x0,
        [Description("FX 2")] EffectTwo = 0x1,
        [Description("Delay")] Delay,
        [Description("Reverb")] Reverb,
        [Description("Direct")] Direct
    }
}