using Caliburn.Micro;
using JD_XI_Editor.Models.Enums;
// ReSharper disable InvertIf

namespace JD_XI_Editor.Models.Patches.Digital
{
    public class Oscillator : PropertyChangedBase, IPatchPart
    {
        /// <inheritdoc />
        /// <summary>
        ///     Creates new instance of Oscillator
        /// </summary>
        public Oscillator()
        {
            Reset();
        }
        
        /// <inheritdoc />
        public void Reset()
        {
            Shape = DigitalOscillatorShape.Saw;
            WaveVariation = WaveVariation.A;
            Pitch = 0;
            Detune = 0;
            PulseWidth = 0;
            PulseWidthModDepth = 0;
            Attack = 0;
            Decay = 0;
            EnvelopeDepth = 0;
        }

        /// <inheritdoc />
        public byte[] GetBytes()
        {
            return new[]
            {
                (byte) Shape,
                (byte) WaveVariation,
                (byte) 0x00,    //Reserve
                (byte) (Pitch + 64),
                (byte) (Detune + 64),
                (byte) PulseWidthModDepth,
                (byte) PulseWidth,
                (byte) Attack,
                (byte) Decay,
                (byte) (EnvelopeDepth + 64)
            };
        }

        #region Fields

        /// <summary>
        ///     Shape
        /// </summary>
        private DigitalOscillatorShape _shape;

        /// <summary>
        ///     Wave variation
        /// </summary>
        private WaveVariation _waveVariation;

        /// <summary>
        ///     Pitch
        /// </summary>
        private int _pitch;

        /// <summary>
        ///     Detune
        /// </summary>
        private int _detune;

        /// <summary>
        ///     Pulse width
        /// </summary>
        private int _pulseWidth;

        /// <summary>
        ///     Pulse width modulation depth
        /// </summary>
        private int _pulseWidthModDepth;

        /// <summary>
        ///     Attack
        /// </summary>
        private int _attack;

        /// <summary>
        ///     Decay
        /// </summary>
        private int _decay;

        /// <summary>
        ///     Envelope depth
        /// </summary>
        private int _envelopeDepth;

        #endregion

        #region Properties

        /// <summary>
        ///     Shape
        /// </summary>
        public DigitalOscillatorShape Shape
        {
            get => _shape;
            set
            {
                if (value != _shape)
                {
                    _shape = value;
                    NotifyOfPropertyChange(nameof(Shape));
                }
            }
        }

        /// <summary>
        ///     Wave variation
        /// </summary>
        public WaveVariation WaveVariation
        {
            get => _waveVariation;
            set
            {
                if (value != _waveVariation)
                {
                    _waveVariation = value;
                    NotifyOfPropertyChange(nameof(WaveVariation));
                }
            }
        }

        /// <summary>
        /// Pitch
        /// </summary>
        public int Pitch
        {
            get => _pitch;
            set
            {
                if (value != _pitch)
                {
                    _pitch = value;
                    NotifyOfPropertyChange(nameof(Pitch));
                }
            }
        }

        /// <summary>
        /// Detune
        /// </summary>
        public int Detune
        {
            get => _detune;
            set
            {
                if (value != _detune)
                {
                    _detune = value;
                    NotifyOfPropertyChange(nameof(Detune));
                }
            }
        }

        /// <summary>
        /// Pulse width
        /// </summary>
        public int PulseWidth
        {
            get => _pulseWidth;
            set
            {
                if (value != _pulseWidth)
                {
                    _pulseWidth = value;
                    NotifyOfPropertyChange(nameof(PulseWidth));
                }
            }
        }

        /// <summary>
        /// Pulse width modulation depth
        /// </summary>
        public int PulseWidthModDepth
        {
            get => _pulseWidthModDepth;
            set
            {
                if (value != _pulseWidthModDepth)
                {
                    _pulseWidthModDepth = value;
                    NotifyOfPropertyChange(nameof(PulseWidthModDepth));
                }
            }
        }

        /// <summary>
        /// Attack
        /// </summary>
        public int Attack
        {
            get => _attack;
            set
            {
                if (value != _attack)
                {
                    _attack = value;
                    NotifyOfPropertyChange(nameof(Attack));
                }
            }
        }

        /// <summary>
        /// Decay
        /// </summary>
        public int Decay
        {
            get => _decay;
            set
            {
                if (value != _decay)
                {
                    _decay = value;
                    NotifyOfPropertyChange(nameof(Decay));
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