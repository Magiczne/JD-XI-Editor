using System;
using Caliburn.Micro;
using JD_XI_Editor.Exceptions;
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
        public void CopyFrom(IPatchPart part)
        {
            if (part is Expression exp)
            {
                PitchBendRange = exp.PitchBendRange;
                ReceiveExpression = exp.ReceiveExpression;
                ReceiveHold1 = exp.ReceiveHold1;
            }
            else
            {
                throw new NotSupportedException("Copying from that type is not supported");
            }
        }

        /// <inheritdoc />
        public void CopyFrom(byte[] data)
        {
            if (data.Length != DumpLength)
            {
                throw new InvalidDumpSizeException(DumpLength, data.Length);
            }

            PitchBendRange = data[0];
            ReceiveExpression = ByteUtils.ByteToBoolean(data[1]);
            ReceiveHold1 = ByteUtils.ByteToBoolean(data[2]);
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

        /// <inheritdoc />
        public int DumpLength { get; } = 4;

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