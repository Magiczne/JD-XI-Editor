using System.Collections.Generic;
using Caliburn.Micro;
using JD_XI_Editor.Models.Enums.Sys;
using JD_XI_Editor.Utils;

namespace JD_XI_Editor.Models.Patches.Sys
{
    internal class Controller : PropertyChangedBase, IPatch
    {
        /// <inheritdoc />
        public Controller()
        {
            Reset();
        }

        /// <inheritdoc />
        public void Reset()
        {
            TransmitProgramChange = true;
            TransmitBankSelect = true;

            KeyboardVelocity = 0;
            VelocityCurve = VelocityCurve.Light;
            VelocityCurveOffset = 9;
        }

        /// <inheritdoc />
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

        #region Properties

        /// <summary>
        ///     Transmit Program Change
        /// </summary>
        public bool TransmitProgramChange { get; set; }

        /// <summary>
        ///     Transmit Bank Select
        /// </summary>
        public bool TransmitBankSelect { get; set; }

        /// <summary>
        ///     Keyboard Velocity
        /// </summary>
        public int KeyboardVelocity { get; set; }

        /// <summary>
        ///     Keyboard Velocity Curve
        /// </summary>
        public VelocityCurve VelocityCurve { get; set; }

        /// <summary>
        ///     Keyboard Velocity Curve Offset
        /// </summary>
        public int VelocityCurveOffset { get; set; }

        #endregion
    }
}