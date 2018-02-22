using System;

namespace JD_XI_Editor.Exceptions
{
    public class PatchNotConvertibleIntoBytes : Exception
    {
        public override string Message { get; } = "Patch cannot be converted into bytes array";
    }
}