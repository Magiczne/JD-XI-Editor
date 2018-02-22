using System.ComponentModel;

namespace JD_XI_Editor.Models.Enums.Digital
{
    internal enum FilterSlope : byte
    {
        [Description("-12 dB")] NegativeTwelve = 0x0,
        [Description("-24 dB")] NegativeTwentyFour = 0x1
    }
}