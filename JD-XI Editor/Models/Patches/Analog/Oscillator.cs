using Caliburn.Micro;
using JD_XI_Editor.Models.Enums;

// ReSharper disable InvertIf

namespace JD_XI_Editor.Models.Patches.Analog
{
    internal class Oscillator : PropertyChangedBase
    {
        #region Fields 

        /// <summary>
        /// Shape
        /// </summary>
        private AnalogOscillatorShape _shape;

        /// <summary>
        /// Pulse width
        /// </summary>
        private int _pulseWidth;

        /// <summary>
        /// Pulse width modulation depth
        /// </summary>
        private int _pulseWidthModDepth;

        /// <summary>
        /// Sub oscillator
        /// </summary>
        private SubOscillatorStatus _subOsc;

        /// <summary>
        /// Pitch
        /// </summary>
        private int _pitch;

        /// <summary>
        /// Detune
        /// </summary>
        private int _detune;

        /// <summary>
        /// Attack
        /// </summary>
        private int _attack;

        /// <summary>
        /// Decay
        /// </summary>
        private int _decay;

        /// <summary>
        /// Envelope depth
        /// </summary>
        private int _envelopeDepth;

        /// <summary>
        /// Envelope velocity sensitivity
        /// </summary>
        private int _envelopeVelocitySensitivity;

        #endregion

        #region Properties

        /// <summary>
        /// Shape
        /// </summary>
        public AnalogOscillatorShape Shape
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
        /// Sub oscillator
        /// </summary>
        public SubOscillatorStatus SubOsc
        {
            get => _subOsc;
            set
            {
                if (value != _subOsc)
                {
                    _subOsc = value;
                    NotifyOfPropertyChange(nameof(SubOsc));
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

        #endregion

        /// <inheritdoc />
        /// <summary>
        /// Creates new instance of Oscillator
        /// </summary>
        public Oscillator()
        {
            Shape = AnalogOscillatorShape.Saw;
            PulseWidth = 0;
            PulseWidthModDepth = 0;
            SubOsc = SubOscillatorStatus.Off;
            Pitch = 0;
            Detune = 0;
            Attack = 0;
            Decay = 0;
            EnvelopeDepth = 0;
            EnvelopeVelocitySensitivity = 0;
        }

        /// <summary>
        /// Reset data to initial patch
        /// </summary>
        public void Reset()
        {
            Shape = AnalogOscillatorShape.Saw;
            PulseWidth = 0;
            PulseWidthModDepth = 0;
            SubOsc = SubOscillatorStatus.Off;
            Pitch = 0;
            Detune = 0;
            Attack = 0;
            Decay = 0;
            EnvelopeDepth = 0;
            EnvelopeVelocitySensitivity = 0;
        }

        /// <summary>
        /// Get bytes
        /// </summary>
        /// <returns></returns>
        public byte[] GetBytes()
        {
            return new[]
            {
                (byte) Shape,
                (byte) (Pitch + 64),
                (byte) (Detune + 64),
                (byte) PulseWidth,
                (byte) PulseWidthModDepth,
                (byte) (EnvelopeVelocitySensitivity + 64),
                (byte) Attack,
                (byte) Decay,
                (byte) (EnvelopeDepth + 64),
                (byte) SubOsc,
            };
        }
    }
}