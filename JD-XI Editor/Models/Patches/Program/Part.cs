using System.Collections.Generic;
using Caliburn.Micro;
using JD_XI_Editor.Utils;

// ReSharper disable InvertIf

namespace JD_XI_Editor.Models.Patches.Program
{
    internal class Part : PropertyChangedBase, IPatch
    {
        /// <inheritdoc />
        public Part()
        {
            Reset();
        }

        /// <inheritdoc />
        public void Reset()
        {
            ReceiveChannel = true;
            ReceivePitchBend = true;
            ReceivePolyphonicKeyPressure = true;
            ReceiveChannelPressure = true;
            ReceiveModulation = true;
            ReceiveVolume = true;
            ReceivePanorama = true;
            ReceiveExpression = true;
            ReceiveHold1 = true;
        }

        /// <inheritdoc />
        public byte[] GetBytes()
        {
            var bytes = new List<byte>
            {
                ByteUtils.BooleanToByte(ReceiveChannel),
                ByteUtils.BooleanToByte(ReceivePitchBend),
                ByteUtils.BooleanToByte(ReceivePolyphonicKeyPressure),
                ByteUtils.BooleanToByte(ReceiveChannelPressure),
                ByteUtils.BooleanToByte(ReceiveModulation),
                ByteUtils.BooleanToByte(ReceiveVolume),
                ByteUtils.BooleanToByte(ReceivePanorama),
                ByteUtils.BooleanToByte(ReceiveExpression),
                ByteUtils.BooleanToByte(ReceiveHold1),
            };

            bytes.AddRange(ByteUtils.RepeatReserve(5));

            return bytes.ToArray();
        }

        #region Fields

        /// <summary>
        ///     Receive Channel
        /// </summary>
        private bool _receiveChannel;

        /// <summary>
        ///     Receive Pitch Bend
        /// </summary>
        private bool _receivePitchBend;

        /// <summary>
        ///     Receive Polyphonic Key Pressure
        /// </summary>
        private bool _receivePolyphonicKeyPressure;

        /// <summary>
        ///     Receive Channel Pressure
        /// </summary>
        private bool _receiveChannelPressure;

        /// <summary>
        ///     Receive Modulation
        /// </summary>
        private bool _receiveModulation;

        /// <summary>
        ///     Receive Volume
        /// </summary>
        private bool _receiveVolume;

        /// <summary>
        ///     Receive Pan
        /// </summary>
        private bool _receivePanorama;

        /// <summary>
        ///     Receive Expression
        /// </summary>
        private bool _receiveExpression;

        /// <summary>
        ///     Receive Hold-1
        /// </summary>
        private bool _receiveHold1;

        #endregion

        #region Properties

        /// <summary>
        ///     Receive Channel
        /// </summary>
        public bool ReceiveChannel
        {
            get => _receiveChannel;
            set
            {
                if (value != _receiveChannel)
                {
                    _receiveChannel = value;
                    NotifyOfPropertyChange(nameof(ReceiveChannel));
                }
            }
        }

        /// <summary>
        ///     Receive Pitch Bend
        /// </summary>
        public bool ReceivePitchBend
        {
            get => _receivePitchBend;
            set
            {
                if (value != _receivePitchBend)
                {
                    _receivePitchBend = value;
                    NotifyOfPropertyChange(nameof(ReceivePitchBend));
                }
            }
        }

        /// <summary>
        ///     Receive Polyphonic Key Pressure
        /// </summary>
        public bool ReceivePolyphonicKeyPressure
        {
            get => _receivePolyphonicKeyPressure;
            set
            {
                if (value != _receivePolyphonicKeyPressure)
                {
                    _receivePolyphonicKeyPressure = value;
                    NotifyOfPropertyChange(nameof(ReceivePolyphonicKeyPressure));
                }
            }
        }

        /// <summary>
        ///     Receive Channel Pressure
        /// </summary>
        public bool ReceiveChannelPressure
        {
            get => _receiveChannelPressure;
            set
            {
                if (value != _receiveChannelPressure)
                {
                    _receiveChannelPressure = value;
                    NotifyOfPropertyChange(nameof(ReceiveChannelPressure));
                }
            }
        }

        /// <summary>
        ///     Receive Modulation
        /// </summary>
        public bool ReceiveModulation
        {
            get => _receiveModulation;
            set
            {
                if (value != _receiveModulation)
                {
                    _receiveModulation = value;
                    NotifyOfPropertyChange(nameof(ReceiveModulation));
                }
            }
        }

        /// <summary>
        ///     Receive Volume
        /// </summary>
        public bool ReceiveVolume
        {
            get => _receiveVolume;
            set
            {
                if (value != _receiveVolume)
                {
                    _receiveVolume = value;
                    NotifyOfPropertyChange(nameof(ReceiveVolume));
                }
            }
        }

        /// <summary>
        ///     Receive Pan
        /// </summary>
        public bool ReceivePanorama
        {
            get => _receivePanorama;
            set
            {
                if (value != _receivePanorama)
                {
                    _receivePanorama = value;
                    NotifyOfPropertyChange(nameof(ReceivePanorama));
                }
            }
        }

        /// <summary>
        ///     Receive Expression
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