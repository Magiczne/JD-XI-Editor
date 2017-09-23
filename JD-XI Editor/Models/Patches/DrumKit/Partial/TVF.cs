using Caliburn.Micro;
using JD_XI_Editor.Models.Enums.DrumKit;

// ReSharper disable InvertIf

namespace JD_XI_Editor.Models.Patches.DrumKit.Partial
{
    internal class Tvf : PropertyChangedBase, IPatchPart
    {
        public Tvf()
        {
            Envelope = new Envelope();
            Reset();

            Envelope.PropertyChanged += (sender, args) => NotifyOfPropertyChange(nameof(Envelope));
        }

        /// <inheritdoc />
        public void Reset()
        {
            Type = FilterType.LowPassFilter;
            Cutoff = 127;
            CutoffVelocityCurve = VelocityCurve.One;
            CutoffVelocitySensitivity = 0;
            Resonance = 0;
            ResonanceVelocitySensitivity = 0;

            Envelope.Depth = 0;
            Envelope.VelocityCurve = VelocityCurve.One;
            Envelope.VelocitySensitivity = 0;
            Envelope.Time1VelocitySensitivity = 0;
            Envelope.Time4VelocitySensitivity = 0;

            Envelope.Time1 = 0;
            Envelope.Time2 = 10;
            Envelope.Time3 = 10;
            Envelope.Time4 = 64;

            Envelope.Level0 = 0;
            Envelope.Level1 = 127;
            Envelope.Level2 = 127;
            Envelope.Level3 = 127;
            Envelope.Level4 = 0;
        }

        /// <inheritdoc />
        public byte[] GetBytes()
        {
            return new[]
            {
                (byte) Type,
                (byte) Cutoff,
                (byte) CutoffVelocityCurve,
                (byte) (CutoffVelocitySensitivity + 64),
                (byte) Resonance,
                (byte) (ResonanceVelocitySensitivity + 64),

                (byte) (Envelope.Depth + 64),
                (byte) Envelope.VelocityCurve,
                (byte) (Envelope.VelocitySensitivity + 64),
                (byte) (Envelope.Time1VelocitySensitivity + 64),
                (byte) (Envelope.Time4VelocitySensitivity + 64),

                (byte) Envelope.Time1,
                (byte) Envelope.Time2,
                (byte) Envelope.Time3,
                (byte) Envelope.Time4,

                (byte) Envelope.Level0,
                (byte) Envelope.Level1,
                (byte) Envelope.Level2,
                (byte) Envelope.Level3,
                (byte) Envelope.Level4
            };
        }

        #region Fields

        /// <summary>
        ///     Type
        /// </summary>
        private FilterType _type;

        /// <summary>
        ///     Cutoff
        /// </summary>
        private int _cutoff;

        /// <summary>
        ///     Cutoff velocity curve
        /// </summary>
        private VelocityCurve _cutoffVelocityCurve;

        /// <summary>
        ///     Cutoff velocity sensitivity
        /// </summary>
        private int _cutoffVelocitySensitivity;

        /// <summary>
        ///     Resonance
        /// </summary>
        private int _resonance;

        /// <summary>
        ///     Resonance velocity sensitivity
        /// </summary>
        private int _resonanceVelocitySensitivity;

        /// <summary>
        ///     Envelope
        /// </summary>
        private Envelope _envelope;

        #endregion

        #region Properties

        /// <summary>
        ///     Type
        /// </summary>
        public FilterType Type
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
        ///     Cutoff velocity curve
        /// </summary>
        public VelocityCurve CutoffVelocityCurve
        {
            get => _cutoffVelocityCurve;
            set
            {
                if (value != _cutoffVelocityCurve)
                {
                    _cutoffVelocityCurve = value;
                    NotifyOfPropertyChange(nameof(CutoffVelocityCurve));
                }
            }
        }

        /// <summary>
        ///     Cutoff velocity sensitivity
        /// </summary>
        public int CutoffVelocitySensitivity
        {
            get => _cutoffVelocitySensitivity;
            set
            {
                if (value != _cutoffVelocitySensitivity)
                {
                    _cutoffVelocitySensitivity = value;
                    NotifyOfPropertyChange(nameof(CutoffVelocitySensitivity));
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
        ///     Resonance velocity sensitivity
        /// </summary>
        public int ResonanceVelocitySensitivity
        {
            get => _resonanceVelocitySensitivity;
            set
            {
                if (value != _resonanceVelocitySensitivity)
                {
                    _resonanceVelocitySensitivity = value;
                    NotifyOfPropertyChange(nameof(ResonanceVelocitySensitivity));
                }
            }
        }

        /// <summary>
        ///     Envelope
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

        #endregion
    }
}