using System.ComponentModel;

namespace JD_XI_Editor.Models.Enums.Digital
{
    internal enum UnisonSize : byte
    {
        [Description("2")] Two = 0x0,
        [Description("4")] Four = 0x1,
        [Description("6")] Six,
        [Description("8")] Eight
    }
}