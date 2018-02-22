using System.ComponentModel;

namespace JD_XI_Editor.Models.Enums.Program.Effects
{
    internal enum Effect2Type : byte
    {
        [Description("Thru")] Thru = 0x00,

        [Description("Flanger")] Flanger = 0x05,
        [Description("Phaser")] Phaser = 0x06,
        [Description("Ring Modulation")] RingMod = 0x07,
        [Description("Slicer")] Slicer = 0x08
    }
}
