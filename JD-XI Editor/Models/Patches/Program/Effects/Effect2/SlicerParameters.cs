using JD_XI_Editor.Models.Enums.Effects.Common;

// ReSharper disable InvertIf

namespace JD_XI_Editor.Models.Patches.Program.Effects.Effect2
{
    internal class SlicerParameters : EffectParameters
    {
        public SlicerParameters()
        {
            Reset();
        }

        public sealed override void Reset()
        {
            TimingPattern = 0;
            Note = Note.One;
            Attack = 39;
            TriggerLevel = 50;
            Level = 127;
        }

        public override byte[] GetBytes()
        {
            throw new System.NotImplementedException();
        }

        #region Fields

        /// <summary>
        ///     Timing Pattern
        /// </summary>
        private int _timingPattern;

        /// <summary>
        ///     Note
        /// </summary>
        private Note _note;

        /// <summary>
        ///     Attack
        /// </summary>
        private int _attack;

        /// <summary>
        ///     Trigger Level
        /// </summary>
        private int _triggerLevel;

        /// <summary>
        ///     Level
        /// </summary>
        private int _level;

        #endregion

        #region Properties

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
        ///     Timing Pattern
        /// </summary>
        public int TimingPattern
        {
            get => _timingPattern;
            set
            {
                if (value != _timingPattern)
                {
                    _timingPattern = value;
                    NotifyOfPropertyChange(nameof(TimingPattern));
                }
            }
        }

        /// <summary>
        ///     Attack
        /// </summary>
        public int Attack
        {
            get => _attack;
            set
            {
                if (value != _attack)
                {
                    _attack = value;
                    NotifyOfPropertyChange(nameof(Attack));
                }
            }
        }

        /// <summary>
        ///     TriggerLevel
        /// </summary>
        public int TriggerLevel
        {
            get => _triggerLevel;
            set
            {
                if (value != _triggerLevel)
                {
                    _triggerLevel = value;
                    NotifyOfPropertyChange(nameof(TriggerLevel));
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