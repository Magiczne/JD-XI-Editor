using System.ComponentModel;

namespace JD_XI_Editor.Models.Enums.Digital
{
    internal enum FilterType : byte
    {
        [Description("Off")] Off = 0x00,
        [Description("Low Pass Filter")] LowPassFilter = 0x01,
        [Description("High Pass Filter")] HighPassFilter = 0x02,
        [Description("Band Pass Filter")] BandPassFilter = 0x03,
        [Description("Peaking Filter")] PeakingFilter = 0x04,
        [Description("Low Pass Filter 2")] LowPassFilter2 = 0x05,
        [Description("Low Pass Filter 3")] LowPassFilter3 = 0x06,
        [Description("Low Pass Filter 4")] LowPassFilter4 = 0x07
    }
}