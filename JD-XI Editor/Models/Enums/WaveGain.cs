using System.ComponentModel;

namespace JD_XI_Editor.Models.Enums
{
    internal enum WaveGain : byte
    {
        [Description("-6")]
        NegativeSix = 0x00,

        [Description("0")]
        Zero = 0x01,

        [Description("6")]
        PositiveSix = 0x02,

        [Description("12")]
        PositiveTvelwe = 0x03
    }
}