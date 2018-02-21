using System;
using System.Collections.Generic;
using JD_XI_Editor.Models.Enums.Effects.Common;
using JD_XI_Editor.Models.Enums.Effects.Phaser;
using JD_XI_Editor.Utils;

// ReSharper disable InvertIf

namespace JD_XI_Editor.Models.Patches.Program.Effects.Effect2
{
    internal class PhaserParameters : EffectParameters
    {
        public PhaserParameters()
        {
            Reset();
        }

        public sealed override void Reset()
        {
            Mode = Mode.Note;
            Note = Note.One;
            Rate = 35;
            Depth = 40;
            Resonance = 40;
            Manual = 30;
            Level = 100;
        }

        public override byte[] GetBytes()
        {
            var bytes = new List<byte>();

            bytes.AddRange(ByteUtils.NumberTo4Packets((byte) Mode));
            bytes.AddRange(ByteUtils.NumberTo4Packets(Rate));
            bytes.AddRange(ByteUtils.NumberTo4Packets((byte) Note));
            bytes.AddRange(ByteUtils.NumberTo4Packets(Depth));
            bytes.AddRange(ByteUtils.NumberTo4Packets(Resonance));
            bytes.AddRange(ByteUtils.NumberTo4Packets(Manual));
            bytes.AddRange(ByteUtils.NumberTo4Packets(Level));
            bytes.AddRange(ByteUtils.Repeat4PacketsReserve(25));

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
        ///     Resonance
        /// </summary>
        private int _resonance;

        /// <summary>
        ///     Manual
        /// </summary>
        private int _manual;

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
        ///     Resonance
        /// </summary>
        public int Resonance
        {
            get => _resonance;
            set
            {
                if (value != _resonance)
                {
                    _resonance = value;
                    NotifyOfPropertyChange(nameof(Resonance));
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