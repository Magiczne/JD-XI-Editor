using System;
using Caliburn.Micro;
using JD_XI_Editor.Models.Enums.DrumKit;

// ReSharper disable InvertIf

namespace JD_XI_Editor.Models.Patches.DrumKit.Partial
{
    internal class Output : PropertyChangedBase, IPatchPart
    {
        /// <inheritdoc />
        public Output()
        {
            Reset();
        }

        /// <inheritdoc />
        public void Reset()
        {
            OutputLevel = 127;
            ChorusSendLevel = 0;
            ReverbSendLevel = 64;
            OutputAssign = OutputAssign.Reverb;
        }

        /// <inheritdoc />
        public byte[] GetBytes()
        {
            return new[]
            {
                (byte) OutputLevel,
                (byte) 0x00,    //Reserve
                (byte) 0x00,    //Reserve
                (byte) ChorusSendLevel,
                (byte) ReverbSendLevel,
                (byte) OutputAssign
            };
        }

        #region Fields

        /// <summary>
        ///     Output level
        /// </summary>
        private int _outputLevel;

        /// <summary>
        ///     Chorus send level
        /// </summary>
        private int _chorusSendLevel;

        /// <summary>
        ///     Reverb send level
        /// </summary>
        private int _reverbSendLevel;

        /// <summary>
        ///     Output assign
        /// </summary>
        private OutputAssign _outputAssign;

        #endregion

        #region Properties

        /// <summary>
        ///     Output level
        /// </summary>
        public int OutputLevel
        {
            get => _outputLevel;
            set
            {
                if (value != _outputLevel)
                {
                    _outputLevel = value;
                    NotifyOfPropertyChange(nameof(OutputLevel));
                }
            }
        }

        /// <summary>
        ///     Chorus send level
        /// </summary>
        public int ChorusSendLevel
        {
            get => _chorusSendLevel;
            set
            {
                if (value != _chorusSendLevel)
                {
                    _chorusSendLevel = value;
                    NotifyOfPropertyChange(nameof(ChorusSendLevel));
                }
            }
        }

        /// <summary>
        ///     Reverb send level
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
        ///     Output assign
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