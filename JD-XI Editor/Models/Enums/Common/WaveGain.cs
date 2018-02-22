using System.ComponentModel;

namespace JD_XI_Editor.Models.Enums.Common
{
    internal enum WaveGain : byte
    {
        [Description("-6")] NegativeSix = 0x0, 
        [Description("0")] Zero = 0x1,
        [Description("6")] PositiveSix,
        [Description("12")] PositiveTwelve
    }
}