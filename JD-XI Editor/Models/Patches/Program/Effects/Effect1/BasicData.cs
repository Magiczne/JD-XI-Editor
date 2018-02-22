using Caliburn.Micro;
using JD_XI_Editor.Models.Enums.Program.Effects;

// ReSharper disable InvertIf

namespace JD_XI_Editor.Models.Patches.Program.Effects.Effect1
{
    internal class BasicData : PropertyChangedBase, IPatchPart
    {
        /// <inheritdoc />
        /// <summary>
        ///     Creates new instance of BasicData
        /// </summary>
        public BasicData()
        {
            Reset();
        }

        /// <inheritdoc />
        public void Reset()
        {
            Type = Effect1Type.Thru;
            Level = 127;
            DelaySendLevel = 50;
            ReverbSendLevel = 50;
            OutputAssign = OutputAssign.Effect2;
        }

        /// <inheritdoc />
        public byte[] GetBytes()
        {
            return new[]
            {
                (byte) Type,
                (byte) Level,
                (byte) DelaySendLevel,
                (byte) ReverbSendLevel,
                (byte) OutputAssign
            };
        }

        #region Fields

        /// <summary>
        ///     Effect Type
        /// </summary>
        private Effect1Type _type;

        /// <summary>
        ///     Level
        /// </summary>
        private int _level;

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

        #region Properties

        /// <summary>
        ///     Effect Type
        /// </summary>
        public Effect1Type Type
        {
            get => _type;
            set
            {
                if (value != _type)
                {
                    _type = value;
                    NotifyOfPropertyChange(nameof(Type));
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