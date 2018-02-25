using System.Collections.Generic;
using Caliburn.Micro;
using JD_XI_Editor.Models.Enums.Sys;
using JD_XI_Editor.Utils;

// ReSharper disable InvertIf

namespace JD_XI_Editor.Models.Patches.Sys
{
    internal class Controller : PropertyChangedBase, IPatch
    {
        public void Reset()
        {
            TransmitProgramChange = true;
            TransmitBankSelect = true;

            KeyboardVelocity = 0;
            VelocityCurve = VelocityCurve.Light;
            VelocityCurveOffset = 9;
        }

        public byte[] GetBytes()
        {
            var bytes = new List<byte>
            {
                ByteUtils.BooleanToByte(TransmitProgramChange),
                ByteUtils.BooleanToByte(TransmitBankSelect),
                (byte) KeyboardVelocity,
                (byte) VelocityCurve,
                (byte) (VelocityCurveOffset + 64)
            };

            bytes.AddRange(ByteUtils.RepeatReserve(12));

            return bytes.ToArray();
        }

        #region Fields

        /// <summary>
        ///     Transmit Program Change
        /// </summary>
        private bool _transmitProgramChange;

        /// <summary>
        ///     Transmit Bank Select
        /// </summary>
        private bool _transmitBankSelect;

        /// <summary>
        ///     Keyboard Velocity
        /// </summary>
        private int _keyboardVelocity;

        /// <summary>
        ///     Keyboard Velocity Curve
        /// </summary>
        private VelocityCurve _velocityCurve;

        /// <summary>
        ///     Keyboard Velocity Curve Offset
        /// </summary>
        private int _velocityCurveOffset;

        #endregion

        #region Properties

        /// <summary>
        ///     Transmit Program Change
        /// </summary>
        public bool TransmitProgramChange
        {
            get => _transmitProgramChange;
            set
            {
                if (value != _transmitProgramChange)
                {
                    _transmitProgramChange = value;
                    NotifyOfPropertyChange(nameof(TransmitProgramChange));
                }
            }
        }

        /// <summary>
        ///     Transmit Bank Select
        /// </summary>
        public bool TransmitBankSelect
        {
            get => _transmitBankSelect;
            set
            {
                if (value != _transmitBankSelect)
                {
                    _transmitBankSelect = value;
                    NotifyOfPropertyChange(nameof(TransmitBankSelect));
                }
            }
        }

        /// <summary>
        ///     Keyboard Velocity
        /// </summary>
        public int KeyboardVelocity
        {
            get => _keyboardVelocity;
            set
            {
                if (value != _keyboardVelocity)
                {
                    _keyboardVelocity = value;
                    NotifyOfPropertyChange(nameof(KeyboardVelocity));
                }
            }
        }

        /// <summary>
        ///     Keyboard Velocity Curve
        /// </summary>
        public VelocityCurve VelocityCurve
        {
            get => _velocityCurve;
            set
            {
                if (value != _velocityCurve)
                {
                    _velocityCurve = value;
                    NotifyOfPropertyChange(nameof(VelocityCurve));
                }
            }
        }

        /// <summary>
        ///     Keyboard Velocity Curve Offset
        /// </summary>
        public int VelocityCurveOffset
        {
            get => _velocityCurveOffset;
            set
            {
                if (value != _velocityCurveOffset)
                {
                    _velocityCurveOffset = value;
                    NotifyOfPropertyChange(nameof(VelocityCurveOffset));
                }
            }
        }

        #endregion
    }
}