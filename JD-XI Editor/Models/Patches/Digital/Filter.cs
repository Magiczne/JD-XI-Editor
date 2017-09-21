using Caliburn.Micro;
using JD_XI_Editor.Models.Enums;
// ReSharper disable InvertIf

namespace JD_XI_Editor.Models.Patches.Digital
{
    internal class Filter : PropertyChangedBase
    {
        /// <inheritdoc />
        /// <summary>
        ///     Creates new instance of Filter
        /// </summary>
        public Filter()
        {
            Type = DigitalFilterType.LowPassFilter;
            Slope = FilterSlope.NegativeTwentyFour;
            Cutoff = 127;
            CutoffKeyfollow = 0;
            EnvelopeVelocitySensitivity = 0;
            Resonance = 0;
            Envelope = new Adsr(0, 36, 0, 0);
            EnvelopeDepth = 0;

            Envelope.PropertyChanged += (sender, args) => NotifyOfPropertyChange(nameof(Envelope));
        }

        /// <summary>
        ///     Reset data to initial patch
        /// </summary>
        public void Reset()
        {
            Type = DigitalFilterType.LowPassFilter;
            Slope = FilterSlope.NegativeTwentyFour;
            Cutoff = 127;
            CutoffKeyfollow = 0;
            EnvelopeVelocitySensitivity = 0;
            Resonance = 0;
            Envelope.Set(0, 36, 0, 0);
            EnvelopeDepth = 0;
        }

        /// <summary>
        ///     Get bytes
        /// </summary>
        /// <returns></returns>
        public byte[] GetBytes()
        {
            return new[]
            {
                (byte) Type,
                (byte) Slope,
                (byte) Cutoff,
                (byte) (CutoffKeyfollow / 10 + 64),
                (byte) (EnvelopeVelocitySensitivity + 64),
                (byte) Resonance,
                (byte) Envelope.Attack,
                (byte) Envelope.Decay,
                (byte) Envelope.Sustain,
                (byte) Envelope.Release,
                (byte) (EnvelopeDepth + 64)
            };
        }

        #region Fields

        /// <summary>
        ///     Filter type
        /// </summary>
        private DigitalFilterType _type;

        /// <summary>
        ///     Filter slope
        /// </summary>
        private FilterSlope _filterSlope;

        /// <summary>
        ///     Cutoff
        /// </summary>
        private int _cutoff;

        /// <summary>
        ///     Cutoff keyfollow
        /// </summary>
        private int _cutoffKeyfollow;

        /// <summary>
        ///     Envelope velocity sensitivity
        /// </summary>
        private int _envelopeVelocitySensitivity;

        /// <summary>
        ///     Resonance
        /// </summary>
        private int _resonance;

        /// <summary>
        ///     Envelope
        /// </summary>
        private Adsr _envelope;

        /// <summary>
        ///     Envelope depth
        /// </summary>
        private int _envelopeDepth;

        #endregion

        #region Properties

        /// <summary>
        ///     Filter type
        /// </summary>
        public DigitalFilterType Type
        {
            get => _type;
            set
            {
                if (value != _type)
                {
                    _type = value;
                    NotifyOfPropertyChange(nameof(Type));
                }
            }
        }

        /// <summary>
        ///     Filter slope
        /// </summary>
        public FilterSlope Slope
        {
            get => _filterSlope;
            set
            {
                if (value != _filterSlope)
                {
                    _filterSlope = value;
                    NotifyOfPropertyChange(nameof(Slope));
                }
            }
        }

        /// <summary>
        /// Cutoff
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
        /// Cutoff keyfollow
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
        /// Envelope velocity sensitivity
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

        /// <summary>
        /// Resonance
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
        /// Envelope
        /// </summary>
        public Adsr Envelope
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
        /// Envelope depth
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

        #endregion
    }
}