using System.ComponentModel;

namespace JD_XI_Editor.Models.Enums.Program.VocalEffect.AutoPitch
{
    internal enum Type : byte
    {
        [Description("Soft")] Soft = 0x0,
        [Description("Hard")] Hard = 0x1,
        [Description("Electric 1")] Electric1,
        [Description("Electric 2")] Electric2
    }
}