using System.ComponentModel;

namespace JD_XI_Editor.Models.Enums
{
    public enum FilterSlope
    {
        [Description("-12 dB")]
        NegativeTwelve = 0x00,

        [Description("-24 dB")]
        NegativeTwentyFour = 0x01
    }
}