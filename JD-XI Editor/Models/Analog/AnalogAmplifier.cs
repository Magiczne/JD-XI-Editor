using Caliburn.Micro;
// ReSharper disable InvertIf

namespace JD_XI_Editor.Models.Analog
{
    internal class AnalogAmplifier : PropertyChangedBase
    {
        #region Fields

        /// <summary>
        /// Level
        /// </summary>
        private int _level;

        /// <summary>
        /// Level keyfollow
        /// </summary>
        private int _levelKeyfollow;

        /// <summary>
        /// Level velocity sensitivity
        /// </summary>
        private int _levelVelSensitivity;

        /// <summary>
        /// Envelope
        /// </summary>
        private Adsr _envelope;

        #endregion

        #region Properties

        /// <summary>
        /// Level
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
        /// Level keyfollow
        /// </summary>
        public int LevelKeyfollow
        {
            get => _levelKeyfollow;
            set
            {
                if (value != _levelKeyfollow)
                {
                    _levelKeyfollow = value;
                    NotifyOfPropertyChange(nameof(LevelKeyfollow));
                }
            }
        }

        /// <summary>
        /// Level velocity sensitivity
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

        #endregion

        /// <summary>
        /// Creates new instance of AnalogAmplifier
        /// </summary>
        public AnalogAmplifier()
        {
            Level = 127;
            LevelKeyfollow = 0;
            LevelVelSensitivity = 0;
            Envelope = new Adsr(0, 0, 127, 0);
        }
    }
}