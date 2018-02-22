using Caliburn.Micro;
using JD_XI_Editor.Utils;

// ReSharper disable InvertIf

namespace JD_XI_Editor.Models.Patches.Analog
{
    internal class Filter : PropertyChangedBase, IPatchPart
    {
        /// <inheritdoc />
        /// <summary>
        ///     Creates new instance of Filter
        /// </summary>
        public Filter()
        {
            On = true;
            Cutoff = 127;
            Resonance = 0;
            CutoffKeyfollow = 0;
            Envelope = new Adsr(0, 0, 127, 0);
            EnvelopeDepth = 0;
            EnvelopeVelocitySensitivity = 0;

            Envelope.PropertyChanged += (sender, args) => NotifyOfPropertyChange(nameof(Envelope));
        }

        /// <inheritdoc />
        public void Reset()
        {
            On = true;
            Cutoff = 127;
            Resonance = 0;
            CutoffKeyfollow = 0;
            Envelope.Set(0, 0, 127, 0);
            EnvelopeDepth = 0;
            EnvelopeVelocitySensitivity = 0;
        }

        /// <inheritdoc />
        public byte[] GetBytes()
        {
            return new[]
            {
                ByteUtils.BooleanToByte(On),
                (byte) Cutoff,
                (byte) (CutoffKeyfollow / 10 + 64),
                (byte) Resonance,
                (byte) (EnvelopeVelocitySensitivity + 64),
                (byte) Envelope.Attack,
                (byte) Envelope.Decay,
                (byte) Envelope.Sustain,
                (byte) Envelope.Release,
                (byte) (EnvelopeDepth + 64)
            };
        }

        #region Fields

        /// <summary>
        ///     Is filter on
        /// </summary>
        private bool _on;

        /// <summary>
        ///     Cutoff
        /// </summary>
        private int _cutoff;

        /// <summary>
        ///     Resonance
        /// </summary>
        private int _resonance;

        /// <summary>
        ///     Cutoff keyfollow
        /// </summary>
        private int _cutoffKeyfollow;

        /// <summary>
        ///     Envelope depth
        /// </summary>
        private int _envelopeDepth;

        /// <summary>
        ///     Envelope velocity sensitivity
        /// </summary>
        private int _envelopeVelocitySensitivity;

        #endregion

        #region Properties

        /// <summary>
        ///     Is filter on
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
        ///     Cutoff
        /// </summary>
        public int Cutoff
        {
            get => _cutoff;
            set
            {
                if (value != _cutoff)
                {
                    _cutoff = value;
                    NotifyOfPropertyChange(nameof(Cutoff));
                }
            }
        }

        /// <summary>
        ///     Resonance
        /// </summary>
        public int Resonance
        {
            get => _resonance;
            set
            {
                if (value != _resonance)
                {
                    _resonance = value;
                    NotifyOfPropertyChange(nameof(Resonance));
                }
            }
        }

        /// <summary>
        ///     Cutoff keyfollow
        /// </summary>
        public int CutoffKeyfollow
        {
            get => _cutoffKeyfollow;
            set
            {
                if (value != _cutoffKeyfollow)
                {
                    _cutoffKeyfollow = value;
                    NotifyOfPropertyChange(nameof(CutoffKeyfollow));
                }
            }
        }

        /// <summary>
        ///     Envelope
        /// </summary>
        public Adsr Envelope { get; }

        /// <summary>
        ///     Envelope depth
        /// </summary>
        public int EnvelopeDepth
        {
            get => _envelopeDepth;
            set
            {
                if (value != _envelopeDepth)
                {
                    _envelopeDepth = value;
                    NotifyOfPropertyChange(nameof(EnvelopeDepth));
                }
            }
        }

        /// <summary>
        ///     Envelope velocity sensitivity
        /// </summary>
        public int EnvelopeVelocitySensitivity
        {
            get => _envelopeVelocitySensitivity;
            set
            {
                if (value != _envelopeVelocitySensitivity)
                {
                    _envelopeVelocitySensitivity = value;
                    NotifyOfPropertyChange(nameof(EnvelopeVelocitySensitivity));
                }
            }
        }

        #endregion
    }
}