using System.ComponentModel;

namespace JD_XI_Editor.Models.Enums.Effects
{
    internal enum EffectType : byte
    {
        [Description("Thru")] Thru,

        [Description("Distortion")] Distortion,
        [Description("Fuzz")] Fuzz,
        [Description("Compressor")] Compressor,
        [Description("Bit Crusher")] BitCrusher,

        [Description("Flanger")] Flanger,
        [Description("Phaser")] Phaser,
        [Description("Ring Modulation")] RingMod,
        [Description("Slicer")] Slicer
    }
}
