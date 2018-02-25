using System.Collections.Generic;
using Caliburn.Micro;
using JD_XI_Editor.Utils;
using PropertyChanged;

namespace JD_XI_Editor.Models.Patches.Program.VocalEffect
{
    internal class VocalEffect : PropertyChangedBase, IPatchPart
    {
        /// <inheritdoc />
        /// <summary>
        ///     Creates new instance of VocalEffect
        /// </summary>
        public VocalEffect()
        {
            Common = new Common();
            AutoPitch = new AutoPitch();
            Vocoder = new Vocoder();

            Common.PropertyChanged += (sender, args) => NotifyOfPropertyChange(nameof(Common));
            AutoPitch.PropertyChanged += (sender, args) => NotifyOfPropertyChange(nameof(AutoPitch));
            Vocoder.PropertyChanged += (sender, args) => NotifyOfPropertyChange(nameof(Vocoder));
        }

        /// <inheritdoc />
        public void Reset()
        {
            Common.Reset();
            AutoPitch.Reset();
            Vocoder.Reset();
        }

        /// <inheritdoc />
        public byte[] GetBytes()
        {
            var bytes = new List<byte>();

            bytes.AddRange(Common.GetBytes());
            bytes.AddRange(AutoPitch.GetBytes());
            bytes.AddRange(Vocoder.GetBytes());
            bytes.AddRange(ByteUtils.RepeatReserve(3));

            return bytes.ToArray();
        }

        #region Properties

        /// <summary>
        ///     Common
        /// </summary>
        [DoNotNotify]
        public Common Common { get; }

        /// <summary>
        ///     Auto Pitch
        /// </summary>
        [DoNotNotify]
        public AutoPitch AutoPitch { get; }

        /// <summary>
        ///     Vocoder
        /// </summary>
        [DoNotNotify]
        public Vocoder Vocoder { get; }

        #endregion
    }
}