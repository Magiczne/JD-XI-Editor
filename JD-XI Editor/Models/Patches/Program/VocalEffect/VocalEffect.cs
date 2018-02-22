using System;
using Caliburn.Micro;

// ReSharper disable InvertIf

namespace JD_XI_Editor.Models.Patches.Program.VocalEffect
{
    internal class VocalEffect : PropertyChangedBase, IPatch
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
            throw new NotImplementedException();
        }

        #region Fields

        /// <summary>
        ///     Common
        /// </summary>
        private Common _common;

        /// <summary>
        ///     Auto Pitch
        /// </summary>
        private AutoPitch _autoPitch;
        
        /// <summary>
        ///     Vocoder
        /// </summary>
        private Vocoder _vocoder;

        #endregion

        #region Properties

        /// <summary>
        ///     Common
        /// </summary>
        public Common Common
        {
            get => _common;
            set
            {
                if (value != _common)
                {
                    _common = value;
                    NotifyOfPropertyChange(nameof(Common));
                }
            }
        }

        /// <summary>
        ///     Auto Pitch
        /// </summary>
        public AutoPitch AutoPitch
        {
            get => _autoPitch;
            set
            {
                if (value != _autoPitch)
                {
                    _autoPitch = value;
                    NotifyOfPropertyChange(nameof(AutoPitch));
                }
            }
        }

        /// <summary>
        ///     Vocoder
        /// </summary>
        public Vocoder Vocoder
        {
            get => _vocoder;
            set
            {
                if (value != _vocoder)
                {
                    _vocoder = value;
                    NotifyOfPropertyChange(nameof(Vocoder));
                }
            }
        }

        #endregion
    }
}