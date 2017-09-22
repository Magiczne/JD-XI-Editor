using System.ComponentModel;

namespace JD_XI_Editor.Models.Enums.Digital
{
    internal enum UnisonSize : byte
    {
        [Description("2")] Two = 0x00,
        [Description("4")] Four = 0x01,
        [Description("6")] Six = 0x02,
        [Description("8")] Eight = 0x03
    }
}