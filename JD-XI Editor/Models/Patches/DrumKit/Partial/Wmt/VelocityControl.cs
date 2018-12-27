using System;
using Caliburn.Micro;
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

        /// TODO: Set
        /// <inheritdoc />
        public int DumpLength { get; }

        /// <summary>
        ///     Velocity control
        /// </summary>
        public WmtVelocityControl Control { get; set; }

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
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public byte[] GetBytes()
        {
            return new[]
            {
                (byte) Control
            };
        }
    }
}