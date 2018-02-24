using System;
using Caliburn.Micro;
using JD_XI_Editor.Models.Enums.Program.VocalEffect;

// ReSharper disable InvertIf

namespace JD_XI_Editor.Models.Patches.Program.VocalEffect
{
    internal class Common : PropertyChangedBase, IPatchPart
    {
        /// <inheritdoc />
        /// <summary>
        ///     Creates new instance of Common
        /// </summary>
        public Common()
        {
            Reset();
        }

        /// <inheritdoc />
        public void Reset()
        {
            Level = 127;
            Panorama = 0;
            DelaySendLevel = 0x0;
            ReverbSendLevel = 0x0;
            OutputAssign = OutputAssign.Delay;
        }

        /// <inheritdoc />
        public byte[] GetBytes()
        {
            return new[]
            {
                (byte) Level,
                (byte) (Panorama + 64),
                (byte) DelaySendLevel,
                (byte) ReverbSendLevel,
                (byte) OutputAssign
            };
        }

        #region Fields

        /// <summary>
        ///     Level
        /// </summary>
        private int _level;

        /// <summary>
        ///     Pan
        /// </summary>
        private int _panorama;

        /// <summary>
        ///     Delay Send Level
        /// </summary>
        private int _delaySendLevel;

        /// <summary>
        ///     Reverb Send Level
        /// </summary>
        private int _reverbSendLevel;

        /// <summary>
        ///     Output Assign
        /// </summary>
        private OutputAssign _outputAssign;

        #endregion

        #region MyRegion

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

        /// <summary>
        ///     Delay Send Level
        /// </summary>
        public int DelaySendLevel
        {
            get => _delaySendLevel;
            set
            {
                if (value != _delaySendLevel)
                {
                    _delaySendLevel = value;
                    NotifyOfPropertyChange(nameof(DelaySendLevel));
                }
            }
        }

        /// <summary>
        ///     Reverb Send Level
        /// </summary>
        public int ReverbSendLevel
        {
            get => _reverbSendLevel;
            set
            {
                if (value != _reverbSendLevel)
                {
                    _reverbSendLevel = value;
                    NotifyOfPropertyChange(nameof(ReverbSendLevel));
                }
            }
        }

        /// <summary>
        ///     Output Assign
        /// </summary>
        public OutputAssign OutputAssign
        {
            get => _outputAssign;
            set
            {
                if (value != _outputAssign)
                {
                    _outputAssign = value;
                    NotifyOfPropertyChange(nameof(OutputAssign));
                }
            }
        }

        #endregion
    }
}