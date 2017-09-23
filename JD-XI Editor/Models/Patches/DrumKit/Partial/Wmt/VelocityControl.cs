using System;
using Caliburn.Micro;
using JD_XI_Editor.Models.Enums.DrumKit;

// ReSharper disable InvertIf

namespace JD_XI_Editor.Models.Patches.DrumKit.Partial.Wmt
{
    internal class VelocityControl : PropertyChangedBase, IPatchPart
    {
        /// <inheritdoc />
        public VelocityControl()
        {
            Reset();
        }

        /// <inheritdoc />
        public void Reset()
        {
            Control = WmtVelocityControl.On;
        }

        /// <inheritdoc />
        public byte[] GetBytes()
        {
            return new[]
            {
                (byte) Control
            };
        }

        #region Fields

        /// <summary>
        ///     Velocity control
        /// </summary>
        private WmtVelocityControl _control;

        #endregion

        #region Properties

        /// <summary>
        ///     Velocity control
        /// </summary>
        public WmtVelocityControl Control
        {
            get => _control;
            set
            {
                if (value != _control)
                {
                    _control = value;
                    NotifyOfPropertyChange(nameof(Control));
                }
            }
        }

        #endregion
    }
}