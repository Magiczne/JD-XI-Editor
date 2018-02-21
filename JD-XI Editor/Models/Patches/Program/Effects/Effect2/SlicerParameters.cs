using System.Collections.Generic;
using JD_XI_Editor.Models.Enums.Effects.Common;
using JD_XI_Editor.Models.Enums.Effects.Slicer;
using JD_XI_Editor.Utils;

// ReSharper disable InvertIf

namespace JD_XI_Editor.Models.Patches.Program.Effects.Effect2
{
    internal class SlicerParameters : EffectParameters
    {
        /// <summary>
        ///     Creates new instance of Slicer Parameters
        /// </summary>
        public SlicerParameters()
        {
            Reset();
        }

        /// <inheritdoc />
        public sealed override void Reset()
        {
            TimingPattern = TimingPattern.Zero;
            Note = Note.One;
            Attack = 39;
            TriggerLevel = 50;
            Level = 127;
        }

        /// <inheritdoc />
        public override byte[] GetBytes()
        {
            var bytes = new List<byte>();
            bytes.AddRange(ByteUtils.NumberTo4Packets((byte) TimingPattern));
            bytes.AddRange(ByteUtils.NumberTo4Packets((byte) Note));
            bytes.AddRange(ByteUtils.NumberTo4Packets(Attack));
            bytes.AddRange(ByteUtils.NumberTo4Packets(TriggerLevel));
            bytes.AddRange(ByteUtils.NumberTo4Packets(Level));

            var reserve = new byte[] { 0x00, 0x00, 0x80, 0x00 };
            for (var i = 0; i < 27; i++)
            {
                bytes.AddRange(reserve);
            }

            return bytes.ToArray();
        }

        #region Fields

        /// <summary>
        ///     Timing Pattern
        /// </summary>
        private TimingPattern _timingPattern;

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
        ///     Timing Pattern
        /// </summary>
        public TimingPattern TimingPattern
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