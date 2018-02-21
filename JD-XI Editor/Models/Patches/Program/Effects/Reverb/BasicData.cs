using Caliburn.Micro;

// ReSharper disable InvertIf

namespace JD_XI_Editor.Models.Patches.Program.Effects.Reverb
{
    internal class BasicData : PropertyChangedBase, IPatchPart
    {
        /// <inheritdoc />
        /// <summary>
        ///     Creates a new instance of BasicData
        /// </summary>
        public BasicData()
        {
            Reset();
        }

        /// <inheritdoc />
        public void Reset()
        {
            On = true;
            Level = 0;
        }

        /// <inheritdoc />
        public byte[] GetBytes()
        {
            return new byte[]
            {
                (byte) (On ? 0x01 : 0x00),
                (byte) Level,
                0x00 // Reserve
            };
        }

        #region Fields

        /// <summary>
        ///     Is reverb on
        /// </summary>
        private bool _on;

        /// <summary>
        ///     Level
        /// </summary>
        private int _level;

        #endregion

        #region Properties

        /// <summary>
        ///     Is delay on
        /// </summary>
        public bool On
        {
            get => _on;
            set
            {
                if (value != _on)
                {
                    _on = value;
                    NotifyOfPropertyChange(nameof(On));
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