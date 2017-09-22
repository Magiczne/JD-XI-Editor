using System.ComponentModel;

namespace JD_XI_Editor.Models.Enums.Digital
{
    internal enum EnvelopeLoopMode : byte
    {
        [Description("Off")] Off = 0x00,
        [Description("Free run")] FreeRun = 0x01,
        [Description("Tempo sync")] TempoSync = 0x02
    }
}