using System.ComponentModel;

namespace JD_XI_Editor.Models.Enums.Program
{
    internal enum ZoneOctaveShift : byte
    {
        [Description("-3")] MinusThree = 61,
        [Description("-2")] MinusTwo = 62,
        [Description("-1")] MinusOne,
        [Description("0")] Zero,
        [Description("+1")] PlusOne,
        [Description("+2")] PlusTwo,
        [Description("+3")] PlusThree
    }
}