using System.ComponentModel;

namespace JD_XI_Editor.Models.Enums.DrumKit
{
    internal enum FilterType : byte
    {
        [Description("Off")] Off = 0x00,
        [Description("Low Pass Filter")] LowPassFilter = 0x01,
        [Description("Band Pass Filter")] BandPassFilter = 0x02,
        [Description("High Pass Filter")] HighPassFilter = 0x03,
        [Description("Peaking Filter")] PeakingFilter = 0x04,
        [Description("Low Pass Filter 2")] LowPassFilter2 = 0x05,
        [Description("Low Pass Filter 3")] LowPassFilter3 = 0x06
    }
}