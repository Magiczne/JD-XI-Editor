using System.ComponentModel;

namespace JD_XI_Editor.Models.Enums.DrumKit
{
    internal enum FilterType : byte
    {
        [Description("Off")] Off = 0x0,
        [Description("Low Pass Filter")] LowPassFilter = 0x1,
        [Description("Band Pass Filter")] BandPassFilter,
        [Description("High Pass Filter")] HighPassFilter,
        [Description("Peaking Filter")] PeakingFilter,
        [Description("Low Pass Filter 2")] LowPassFilter2,
        [Description("Low Pass Filter 3")] LowPassFilter3
    }
}