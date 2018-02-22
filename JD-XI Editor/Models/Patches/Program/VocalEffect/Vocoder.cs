using System;
using Caliburn.Micro;
using JD_XI_Editor.Models.Enums.Program.VocalEffect.Vocoder;
using JD_XI_Editor.Utils;

// ReSharper disable InvertIf

namespace JD_XI_Editor.Models.Patches.Program.VocalEffect
{
    internal class Vocoder : PropertyChangedBase, IPatchPart
    {
        /// <inheritdoc />
        /// <summary>
        ///     Creates new instance of Vocoder
        /// </summary>
        public Vocoder()
        {
            Reset();
        }

        /// <inheritdoc />
        public void Reset()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public byte[] GetBytes()
        {
            return new byte[]
            {
                ByteUtils.BooleanToByte(On),
                (byte) Envelope,
                (byte) UnknowParameter,
                (byte) MicrophoneSensitivity,
                (byte) SynthLevel,
                (byte) MicrophoneMixLevel,
                (byte) MicrophoneHpf,
                0x00 // Reserve
            };
        }

        #region Fields

        /// <summary>
        ///     Vocoder Switch
        /// </summary>
        private bool _on;

        /// <summary>
        ///     Vocoder Envelope
        /// </summary>
        private Envelope _envelope;

        /// <summary>
        ///     TODO: WHAT
        ///     Unknow parameter (maybe vocoder tone number)
        /// </summary>
        private int _unknownParam;

        /// <summary>
        ///     Vocoder Mic Sensitivity
        /// </summary>
        private int _microphoneSensitivity;

        /// <summary>
        ///     Vocoder Synth Level
        /// </summary>
        private int _synthLevel;

        /// <summary>
        ///     Vocoder Mic Mix Level
        /// </summary>
        private int _microphoneMixLevel;

        /// <summary>
        ///     Vocoder Microphone HPF
        /// </summary>
        private HighPassFilter _microphoneHpf;

        #endregion

        #region Properties

        /// <summary>
        ///     Vocoder Switch
        /// </summary>
        public bool On
        {
            get => _on;
            set
            {
                if (value != _on)
                {
                    _on = value;
                    NotifyOfPropertyChange(nameof(On));
                }
            }
        }

        /// <summary>
        ///     Vocoder Envelope
        /// </summary>
        public Envelope Envelope
        {
            get => _envelope;
            set
            {
                if (value != _envelope)
                {
                    _envelope = value;
                    NotifyOfPropertyChange(nameof(Envelope));
                }
            }
        }

        /// <summary>
        ///     Unknow Parameter
        /// </summary>
        public int UnknowParameter
        {
            get => _unknownParam;
            set
            {
                if (value != _unknownParam)
                {
                    _unknownParam = value;
                    NotifyOfPropertyChange(nameof(UnknowParameter));
                }
            }
        }

        /// <summary>
        ///     Vocoder Mic Sensitivity
        /// </summary>
        public int MicrophoneSensitivity
        {
            get => _microphoneSensitivity;
            set
            {
                if (value != _microphoneSensitivity)
                {
                    _microphoneSensitivity = value;
                    NotifyOfPropertyChange(nameof(MicrophoneSensitivity));
                }
            }
        }

        /// <summary>
        ///     Vocoder Synth Level
        /// </summary>
        public int SynthLevel
        {
            get => _synthLevel;
            set
            {
                if (value != _synthLevel)
                {
                    _synthLevel = value;
                    NotifyOfPropertyChange(nameof(SynthLevel));
                }
            }
        }

        /// <summary>
        ///     Vocoder Mic Mix Level
        /// </summary>
        public int MicrophoneMixLevel
        {
            get => _microphoneMixLevel;
            set
            {
                if (value != _microphoneMixLevel)
                {
                    _microphoneMixLevel = value;
                    NotifyOfPropertyChange(nameof(MicrophoneMixLevel));
                }
            }
        }

        /// <summary>
        ///     Vocoder Microphone HPF
        /// </summary>
        public HighPassFilter MicrophoneHpf
        {
            get => _microphoneHpf;
            set
            {
                if (value != _microphoneHpf)
                {
                    _microphoneHpf = value;
                    NotifyOfPropertyChange(nameof(MicrophoneHpf));
                }
            }
        }

        #endregion
    }
}