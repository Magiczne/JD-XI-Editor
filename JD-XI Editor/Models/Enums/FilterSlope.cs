using System.ComponentModel;

namespace JD_XI_Editor.Models.Enums
{
    internal enum FilterSlope : byte
    {
        [Description("-12 dB")]
        NegativeTwelve = 0x00,

        [Description("-24 dB")]
        NegativeTwentyFour = 0x01
    }
}