using Caliburn.Micro;
using JD_XI_Editor.Utils;

// ReSharper disable InvertIf

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

        #region Fields

        /// <summary>
        ///     Pitch bend range
        /// </summary>
        private int _pitchBendRange;

        /// <summary>
        ///     Receive expression
        /// </summary>
        private bool _receiveExpression;

        /// <summary>
        ///     Receive Hold-1
        /// </summary>
        private bool _receiveHold1;

        #endregion

        #region Properties

        /// <summary>
        ///     Pitch bend range
        /// </summary>
        public int PitchBendRange
        {
            get => _pitchBendRange;
            set
            {
                if (value != _pitchBendRange)
                {
                    _pitchBendRange = value;
                    NotifyOfPropertyChange(nameof(PitchBendRange));
                }
            }
        }

        /// <summary>
        ///     Receive expression
        /// </summary>
        public bool ReceiveExpression
        {
            get => _receiveExpression;
            set
            {
                if (value != _receiveExpression)
                {
                    _receiveExpression = value;
                    NotifyOfPropertyChange(nameof(ReceiveExpression));
                }
            }
        }

        /// <summary>
        ///     Receive Hold-1
        /// </summary>
        public bool ReceiveHold1
        {
            get => _receiveHold1;
            set
            {
                if (value != _receiveHold1)
                {
                    _receiveHold1 = value;
                    NotifyOfPropertyChange(nameof(ReceiveHold1));
                }
            }
        }

        #endregion
    }
}