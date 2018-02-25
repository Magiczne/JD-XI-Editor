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
        public byte[] GetBytes()
        {
            return new[]
            {
                (byte) Control
            };
        }
    }
}