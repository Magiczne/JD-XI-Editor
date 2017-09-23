using System.ComponentModel;

namespace JD_XI_Editor.Models.Enums.DrumKit
{
    internal enum EnvelopeMode
    {
        [Description("No sustain")] NoSustain = 0x00,
        [Description("Sustain")] Sustain = 0x01
    }
}