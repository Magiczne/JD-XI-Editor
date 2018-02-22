using System.ComponentModel;

namespace JD_XI_Editor.Models.Enums.Digital
{
    internal enum EnvelopeLoopMode : byte
    {
        [Description("Off")] Off = 0x0,
        [Description("Free run")] FreeRun = 0x1,
        [Description("Tempo sync")] TempoSync
    }
}