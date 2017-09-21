using System.ComponentModel;

namespace JD_XI_Editor.Models.Enums
{
    internal enum Category : byte
    {
        [Description("Not assigned")]
        NotAssigned = 0x00,

        [Description("Keyboard")]
        Keyboard = 0x09,

        [Description("Bass")]
        Bass = 0x21,

        [Description("Lead")]
        Lead = 0x34,

        [Description("Brass")]
        Brass = 0x35,

        [Description("Strings/Pad")]
        StringAndPad = 0x36,

        [Description("FX/Other")]
        FxAndOther = 0x39,

        [Description("Seq")]
        Sequence = 0x40
    }
}