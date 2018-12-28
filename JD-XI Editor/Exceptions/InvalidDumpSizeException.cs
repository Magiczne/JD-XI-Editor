using System;

namespace JD_XI_Editor.Exceptions
{
    public class InvalidDumpSizeException : Exception
    {
        /// <inheritdoc />
        public override string Message { get; } = "Length of dump received from device is invalid";

        /// <summary>
        ///     Expected length of the dump
        /// </summary>
        public int ExpectedLength { get; }

        /// <summary>
        ///     Actual length of the dump
        /// </summary>
        public int ActualLength { get; }

        public InvalidDumpSizeException()
        {

        }

        public InvalidDumpSizeException(int expected, int actual)
        {
            ExpectedLength = expected;
            ActualLength = actual;
        }
    }
}