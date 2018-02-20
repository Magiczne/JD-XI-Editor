using System;

// ReSharper disable InvertIf

namespace JD_XI_Editor.Models.Patches.Program.Effects.Effect1
{
    internal class BitCrusherParameters : EffectParameters
    {
        /// <summary>
        ///     Creates new instance of BitCrusherParameters
        /// </summary>
        public BitCrusherParameters()
        {
            Reset();
        }

        /// <inheritdoc />
        public sealed override void Reset()
        {
            Rate = 75;
            Bit = 70;
            Filter = 85;
            Level = 127;
        }

        /// <inheritdoc />
        public override byte[] GetBytes()
        {
            throw new NotImplementedException();
        }

        #region Fields

        /// <summary>
        ///     Rate
        /// </summary>
        private int _rate;

        /// <summary>
        ///     Bit
        /// </summary>
        private int _bit;

        /// <summary>
        ///     Filter
        /// </summary>
        private int _filter;

        /// <summary>
        ///     Level
        /// </summary>
        private int _level;

        #endregion

        #region Properties

        /// <summary>
        ///     Rate
        /// </summary>
        public int Rate
        {
            get => _rate;
            set
            {
                if (value != _rate)
                {
                    _rate = value;
                    NotifyOfPropertyChange(nameof(Rate));
                }
            }
        }

        /// <summary>
        ///     Bit
        /// </summary>
        public int Bit
        {
            get => _bit;
            set
            {
                if (value != _bit)
                {
                    _bit = value;
                    NotifyOfPropertyChange(nameof(Bit));
                }
            }
        }

        /// <summary>
        ///     Filter
        /// </summary>
        public int Filter
        {
            get => _filter;
            set
            {
                if (value != _filter)
                {
                    _filter = value;
                    NotifyOfPropertyChange(nameof(Filter));
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
