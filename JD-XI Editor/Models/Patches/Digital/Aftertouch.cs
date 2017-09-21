using Caliburn.Micro;

// ReSharper disable InvertIf

namespace JD_XI_Editor.Models.Patches.Digital
{
    internal class Aftertouch : PropertyChangedBase, IPatchPart
    {
        /// <inheritdoc />
        /// <summary>
        ///     Creates new instance of Aftertouch
        /// </summary>
        public Aftertouch()
        {
            Reset();
        }

        /// <inheritdoc />
        public void Reset()
        {
            CutoffAftertouchSensitivity = 9;
            LevelAftertouchSensitivity = 10;
        }

        /// <inheritdoc />
        public byte[] GetBytes()
        {
            return new byte[]
            {
                (byte) (CutoffAftertouchSensitivity + 64),
                (byte) (LevelAftertouchSensitivity + 64),
                0x00, //Reserve
                0x00 //Reserve
            };
        }

        #region Fields

        /// <summary>
        ///     Cutoff Aftertouch Sensitivity
        /// </summary>
        private int _cutoffAftertouchSensitivity;

        /// <summary>
        ///     Level Aftertouch Sensitivity
        /// </summary>
        private int _levelAftertouchSensitivity;

        #endregion

        #region Properties

        /// <summary>
        ///     Cutoff Aftertouch Sensitivity
        /// </summary>
        public int CutoffAftertouchSensitivity
        {
            get => _cutoffAftertouchSensitivity;
            set
            {
                if (value != _cutoffAftertouchSensitivity)
                {
                    _cutoffAftertouchSensitivity = value;
                    NotifyOfPropertyChange(nameof(CutoffAftertouchSensitivity));
                }
            }
        }

        /// <summary>
        ///     Level Aftertouch Sensitivity
        /// </summary>
        public int LevelAftertouchSensitivity
        {
            get => _levelAftertouchSensitivity;
            set
            {
                if (value != _levelAftertouchSensitivity)
                {
                    _levelAftertouchSensitivity = value;
                    NotifyOfPropertyChange(nameof(LevelAftertouchSensitivity));
                }
            }
        }

        #endregion
    }
}