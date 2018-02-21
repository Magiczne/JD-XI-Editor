using System.Collections.Generic;
using JD_XI_Editor.Models.Enums.Effects.Common;
using JD_XI_Editor.Models.Enums.Effects.Flanger;
using JD_XI_Editor.Utils;

// ReSharper disable InvertIf

namespace JD_XI_Editor.Models.Patches.Program.Effects.Effect2
{
    internal class FlangerParameters : EffectParameters
    {
        public FlangerParameters()
        {
            Reset();
        }

        public sealed override void Reset()
        {
            Mode = Mode.Note;
            Note = Note.Two;
            Rate = 25;
            Depth = 100;
            Feedback = 80;
            Manual = 30;
            DryWetBalance = 50;
            Level = 127;
        }

        public override byte[] GetBytes()
        {
            var bytes = new List<byte>();

            bytes.AddRange(ByteUtils.NumberTo4Packets((byte) Mode));
            bytes.AddRange(ByteUtils.NumberTo4Packets(Rate));
            bytes.AddRange(ByteUtils.NumberTo4Packets((byte) Note));
            bytes.AddRange(ByteUtils.NumberTo4Packets(Depth));
            bytes.AddRange(ByteUtils.NumberTo4Packets(Feedback));
            bytes.AddRange(ByteUtils.NumberTo4Packets(Manual));
            bytes.AddRange(ByteUtils.NumberTo4Packets(DryWetBalance));
            bytes.AddRange(ByteUtils.NumberTo4Packets(Level));
            bytes.AddRange(ByteUtils.Repeat4PacketsReserve(24));

            return bytes.ToArray();
        }

        #region Fields

        /// <summary>
        ///     Mode
        /// </summary>
        private Mode _mode;

        /// <summary>
        ///     Note
        /// </summary>
        private Note _note;

        /// <summary>
        ///     Rate
        /// </summary>
        private int _rate;

        /// <summary>
        ///     Depth
        /// </summary>
        private int _depth;

        /// <summary>
        ///     Feedback
        /// </summary>
        private int _feedback;
        
        /// <summary>
        ///     Manual
        /// </summary>
        private int _manual;
        
        /// <summary>
        ///     Dry/Wet balance
        /// </summary>
        private int _dryWetBalance;

        /// <summary>
        ///     Level
        /// </summary>
        private int _level;

        #endregion

        #region Properties

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
        ///     Depth
        /// </summary>
        public int Depth
        {
            get => _depth;
            set
            {
                if (value != _depth)
                {
                    _depth = value;
                    NotifyOfPropertyChange(nameof(Depth));
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
        ///     Manual
        /// </summary>
        public int Manual
        {
            get => _manual;
            set
            {
                if (value != _manual)
                {
                    _manual = value;
                    NotifyOfPropertyChange(nameof(Manual));
                }
            }
        }

        /// <summary>
        ///     Dry/Wet Balance
        /// </summary>
        public int DryWetBalance
        {
            get => _dryWetBalance;
            set
            {
                if (value != _dryWetBalance)
                {
                    _dryWetBalance = value;
                    NotifyOfPropertyChange(nameof(DryWetBalance));
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