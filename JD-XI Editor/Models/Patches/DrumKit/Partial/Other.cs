using Caliburn.Micro;
using JD_XI_Editor.Utils;

// ReSharper disable InvertIf

namespace JD_XI_Editor.Models.Patches.DrumKit.Partial
{
    internal class Other : PropertyChangedBase, IPatchPart
    {
        /// <inheritdoc />
        public Other()
        {
            Reset();
        }

        /// <inheritdoc />
        public void Reset()
        {
            OneShotMode = false;
            RelativeLevel = 0;
        }

        /// <inheritdoc />
        public byte[] GetBytes()
        {
            return new[]
            {
                ByteUtils.BooleanToByte(OneShotMode),
                (byte) (RelativeLevel + 64)
            };
        }

        #region Fields

        /// <summary>
        ///     One shot mode
        /// </summary>
        private bool _oneShotMode;

        /// <summary>
        ///     Relative volume level
        /// </summary>
        private int _relativeLevel;

        #endregion

        #region Properties

        /// <summary>
        ///     One shot mode
        /// </summary>
        public bool OneShotMode
        {
            get => _oneShotMode;
            set
            {
                if (value != _oneShotMode)
                {
                    _oneShotMode = value;
                    NotifyOfPropertyChange(nameof(OneShotMode));
                }
            }
        }

        /// <summary>
        ///     Relative volume level
        /// </summary>
        public int RelativeLevel
        {
            get => _relativeLevel;
            set
            {
                if (value != _relativeLevel)
                {
                    _relativeLevel = value;
                    NotifyOfPropertyChange(nameof(RelativeLevel));
                }
            }
        }

        #endregion
    }
}