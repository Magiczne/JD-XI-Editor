// ReSharper disable InvertIf

namespace JD_XI_Editor.Models.Patches.Program.Effects.Effect2
{
    internal class RingModulationParameters : EffectParameters
    {
        public RingModulationParameters()
        {
            Reset();
        }

        public sealed override void Reset()
        {
            Frequency = 60;
            Sensitivity = 80;
            DryWetBalance = 50;
            Level = 127;
        }

        public override byte[] GetBytes()
        {
            throw new System.NotImplementedException();
        }

        #region Fields

        /// <summary>
        ///     Frequency
        /// </summary>
        private int _frequency;

        /// <summary>
        ///     Sensitivity
        /// </summary>
        private int _sensitivity;

        /// <summary>
        ///     Dry/Wet balance
        /// </summary>
        private int _dryWetBalance;

        /// <summary>
        ///     Level
        /// </summary>
        private int _level;

        #endregion

        #region Properties

        /// <summary>
        ///     Frequency
        /// </summary>
        public int Frequency
        {
            get => _frequency;
            set
            {
                if (value != _frequency)
                {
                    _frequency = value;
                    NotifyOfPropertyChange(nameof(Frequency));
                }
            }
        }

        /// <summary>
        ///     Sensitivity
        /// </summary>
        public int Sensitivity
        {
            get => _sensitivity;
            set
            {
                if (value != _sensitivity)
                {
                    _sensitivity = value;
                    NotifyOfPropertyChange(nameof(Sensitivity));
                }
            }
        }

        /// <summary>
        ///     Dry/Wet Balance
        /// </summary>
        public int DryWetBalance
        {
            get => _dryWetBalance;
            set
            {
                if (value != _dryWetBalance)
                {
                    _dryWetBalance = value;
                    NotifyOfPropertyChange(nameof(DryWetBalance));
                }
            }
        }

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

        #endregion
    }
}