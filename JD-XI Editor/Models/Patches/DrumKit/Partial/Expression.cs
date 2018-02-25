using Caliburn.Micro;
using JD_XI_Editor.Utils;

namespace JD_XI_Editor.Models.Patches.DrumKit.Partial
{
    internal class Expression : PropertyChangedBase, IPatchPart
    {
        /// <inheritdoc />
        public Expression()
        {
            Reset();
        }

        /// <inheritdoc />
        public void Reset()
        {
            PitchBendRange = 2;
            ReceiveExpression = true;
            ReceiveHold1 = true;
        }

        /// <inheritdoc />
        public byte[] GetBytes()
        {
            return new byte[]
            {
                (byte) PitchBendRange,
                ByteUtils.BooleanToByte(ReceiveExpression),
                ByteUtils.BooleanToByte(ReceiveHold1),
                0x00 //Reserve
            };
        }

        #region Properties

        /// <summary>
        ///     Pitch bend range
        /// </summary>
        public int PitchBendRange { get; set; }

        /// <summary>
        ///     Receive expression
        /// </summary>
        public bool ReceiveExpression { get; set; }

        /// <summary>
        ///     Receive Hold-1
        /// </summary>
        public bool ReceiveHold1 { get; set; }

        #endregion
    }
}