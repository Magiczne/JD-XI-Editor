using System;
using Caliburn.Micro;
using JD_XI_Editor.Exceptions;
using JD_XI_Editor.Models.Enums.DrumKit;

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
        public void CopyFrom(IPatchPart part)
        {
            if (part is VelocityControl vc)
            {
                Control = vc.Control;
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

            Control = (WmtVelocityControl) data[0];
        }

        /// <inheritdoc />
        public byte[] GetBytes()
        {
            return new[]
            {
                (byte) Control
            };
        }

        #region Properties

        /// <inheritdoc />
        public int DumpLength { get; } = 1;

        /// <summary>
        ///     Velocity control
        /// </summary>
        public WmtVelocityControl Control { get; set; }

        #endregion
    }
}