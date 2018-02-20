using JD_XI_Editor.Models.Enums.Effects.Common;
using JD_XI_Editor.Models.Enums.Effects.Delay;
// ReSharper disable InvertIf

namespace JD_XI_Editor.Models.Patches.Program.Effects.Delay
{
    internal class Parameters : EffectParameters
    {
        /// <inheritdoc />
        /// <summary>
        ///     Creates a new instance of Parameters
        /// </summary>
        public Parameters()
        {
            Reset();
        }

        /// <inheritdoc />
        public sealed override void Reset()
        {
            On = true;
            Type = Type.Pan;
            Mode = Mode.Note;
            Note = Note.ThreeSixteenths;
            Time = 200;
            TapTime = 50;
            Feedback = 50;
            HfDamp = HfDamp.Damp5000;
            ReverbSendLevel = 0;
            Level = 0;
        }

        /// <inheritdoc />
        public override byte[] GetBytes()
        {
            throw new System.NotImplementedException();
        }

        #region Fields

        /// <summary>
        ///     Is delay on
        /// </summary>
        private bool _on;

        /// <summary>
        ///     Threshold
        /// </summary>
        private int _threshold;

        /// <summary>
        ///     Type
        /// </summary>
        private Type _type;

        /// <summary>
        ///     Mode
        /// </summary>
        private Mode _mode;

        /// <summary>
        ///     Note
        /// </summary>
        private Note _note;

        /// <summary>
        ///     Time
        /// </summary>
        private int _time;

        /// <summary>
        ///     Tap time
        /// </summary>
        private int _tapTime;

        /// <summary>
        ///     Feedback
        /// </summary>
        private int _feedback;

        /// <summary>
        ///     HF Damp
        /// </summary>
        private HfDamp _hfDamp;

        /// <summary>
        ///     Reverb Send Level
        /// </summary>
        private int _reverbSendLevel;

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
        ///     Threshold
        /// </summary>
        public int Threshold
        {
            get => _threshold;
            set
            {
                if (value != _threshold)
                {
                    _threshold = value;
                    NotifyOfPropertyChange(nameof(Threshold));
                }
            }
        }

        /// <summary>
        ///     Type
        /// </summary>
        public Type Type
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
        ///     Mode
        /// </summary>
        public Mode Mode
        {
            get => _mode;
            set
            {
                if (value != _mode)
                {
                    _mode = value;
                    NotifyOfPropertyChange(nameof(Mode));
                }
            }
        }

        /// <summary>
        ///     Note
        /// </summary>
        public Note Note
        {
            get => _note;
            set
            {
                if (value != _note)
                {
                    _note = value;
                    NotifyOfPropertyChange(nameof(Note));
                }
            }
        }

        /// <summary>
        ///     Time
        /// </summary>
        public int Time
        {
            get => _time;
            set
            {
                if (value != _time)
                {
                    _time = value;
                    NotifyOfPropertyChange(nameof(Time));
                }
            }
        }

        /// <summary>
        ///     Tap time
        /// </summary>
        public int TapTime
        {
            get => _tapTime;
            set
            {
                if (value != _tapTime)
                {
                    _tapTime = value;
                    NotifyOfPropertyChange(nameof(TapTime));
                }
            }
        }

        /// <summary>
        ///     Feedback
        /// </summary>
        public int Feedback
        {
            get => _feedback;
            set
            {
                if (value != _feedback)
                {
                    _feedback = value;
                    NotifyOfPropertyChange(nameof(Feedback));
                }
            }
        }

        /// <summary>
        ///     HF Damp
        /// </summary>
        public HfDamp HfDamp
        {
            get => _hfDamp;
            set
            {
                if (value != _hfDamp)
                {
                    _hfDamp = value;
                    NotifyOfPropertyChange(nameof(HfDamp));
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