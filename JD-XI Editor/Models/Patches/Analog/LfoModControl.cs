using Caliburn.Micro;

// ReSharper disable InvertIf

namespace JD_XI_Editor.Models.Patches.Analog
{
    internal class LfoModControl : PropertyChangedBase, IPatchPart
    {
        /// <inheritdoc />
        /// <summary>
        ///     Creates new instance of LfoModControl
        /// </summary>
        public LfoModControl()
        {
            Reset();
        }

        /// <inheritdoc />
        public void Reset()
        {
            PitchModControl = 16;
            FilterModControl = 0;
            AmpModControl = 0;
            RateModControl = 18;
        }

        /// <inheritdoc />
        public byte[] GetBytes()
        {
            return new[]
            {
                (byte) (PitchModControl + 64),
                (byte) (FilterModControl + 64),
                (byte) (AmpModControl + 64),
                (byte) (RateModControl + 64)
            };
        }

        #region Fields

        /// <summary>
        ///     Pitch modulation control
        /// </summary>
        private int _pitchModControl;

        /// <summary>
        ///     Filter modulation control
        /// </summary>
        private int _filterModControl;

        /// <summary>
        ///     Amplifier modulation control
        /// </summary>
        private int _ampModControl;

        /// <summary>
        ///     Rate modulation control
        /// </summary>
        private int _rateModControl;

        #endregion

        #region Properties

        /// <summary>
        ///     Pitch modulation control
        /// </summary>
        public int PitchModControl
        {
            get => _pitchModControl;
            set
            {
                if (value != _pitchModControl)
                {
                    _pitchModControl = value;
                    NotifyOfPropertyChange(nameof(PitchModControl));
                }
            }
        }

        /// <summary>
        ///     Filter modulation control
        /// </summary>
        public int FilterModControl
        {
            get => _filterModControl;
            set
            {
                if (value != _filterModControl)
                {
                    _filterModControl = value;
                    NotifyOfPropertyChange(nameof(FilterModControl));
                }
            }
        }

        /// <summary>
        ///     Amplifier modulation control
        /// </summary>
        public int AmpModControl
        {
            get => _ampModControl;
            set
            {
                if (value != _ampModControl)
                {
                    _ampModControl = value;
                    NotifyOfPropertyChange(nameof(AmpModControl));
                }
            }
        }

        /// <summary>
        ///     Rate modulation control
        /// </summary>
        public int RateModControl
        {
            get => _rateModControl;
            set
            {
                if (value != _rateModControl)
                {
                    _rateModControl = value;
                    NotifyOfPropertyChange(nameof(RateModControl));
                }
            }
        }

        #endregion
    }
}