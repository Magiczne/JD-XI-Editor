using System.ComponentModel;

namespace JD_XI_Editor.Models.Enums.Sys
{
    internal enum ProgramControlChannel : byte
    {
        [Description("Channel 1")] Channel1 = 0x0,
        [Description("Channel 2")] Channel2 = 0x1,
        [Description("Channel 3")] Channel3,
        [Description("Channel 4")] Channel4,
        [Description("Channel 5")] Channel5,
        [Description("Channel 6")] Channel6,
        [Description("Channel 7")] Channel7,
        [Description("Channel 8")] Channel8,
        [Description("Channel 9")] Channel9,
        [Description("Channel 10")] Channel10,
        [Description("Channel 11")] Channel11,
        [Description("Channel 12")] Channel12,
        [Description("Channel 13")] Channel13,
        [Description("Channel 14")] Channel14,
        [Description("Channel 15")] Channel15,
        [Description("Channel 16")] Channel16,
        [Description("Off")] Off
    }
}