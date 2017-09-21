using Caliburn.Micro;

// ReSharper disable InvertIf

namespace JD_XI_Editor.Models.Patches.Digital
{
    internal class Amplifier : PropertyChangedBase
    {
        /// <inheritdoc />
        /// <summary>
        ///     Creates new instance of Amplifier
        /// </summary>
        public Amplifier()
        {
            Level = 100;
            LevelVelSensitivity = 19;
            Envelope = new Adsr(0, 0, 127, 0);
            Panorama = 0;

            Envelope.PropertyChanged += (sender, args) => NotifyOfPropertyChange(nameof(Envelope));
        }

        /// <summary>
        ///     Reset data to initial patch
        /// </summary>
        public void Reset()
        {
            Level = 100;
            LevelVelSensitivity = 19;
            Envelope.Set(0, 0, 127, 0);
            Panorama = 0;
        }

        /// <summary>
        ///     Get bytes
        /// </summary>
        /// <returns></returns>
        public byte[] GetBytes()
        {
            return new[]
            {
                (byte) Level,
                (byte) (LevelVelSensitivity + 64),
                (byte) Envelope.Attack,
                (byte) Envelope.Decay,
                (byte) Envelope.Sustain,
                (byte) Envelope.Release,
                (byte) (Panorama + 64)
            };
        }

        #region Fields

        /// <summary>
        ///     Level
        /// </summary>
        private int _level;

        /// <summary>
        ///     Level velocity sensitivity
        /// </summary>
        private int _levelVelSensitivity;

        /// <summary>
        ///     Envelope
        /// </summary>
        private Adsr _envelope;

        /// <summary>
        ///     Panorama
        /// </summary>
        private int _panorama;

        #endregion

        #region Properties

        /// <summary>
        ///     Level
        /// </summary>
        public int Level
        {
            get => _level;
            set
            {
                if (value != _level)
                {
                    _level = value;
                    NotifyOfPropertyChange(nameof(Level));
                }
            }
        }

        /// <summary>
        ///     Level velocity sensitivity
        /// </summary>
        public int LevelVelSensitivity
        {
            get => _levelVelSensitivity;
            set
            {
                if (value != _levelVelSensitivity)
                {
                    _levelVelSensitivity = value;
                    NotifyOfPropertyChange(nameof(LevelVelSensitivity));
                }
            }
        }

        /// <summary>
        ///     Envelope
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
        ///     Panorama
        /// </summary>
        public int Panorama
        {
            get => _panorama;
            set
            {
                if (value != _panorama)
                {
                    _panorama = value;
                    NotifyOfPropertyChange(nameof(Panorama));
                }
            }
        }

        #endregion
    }
}