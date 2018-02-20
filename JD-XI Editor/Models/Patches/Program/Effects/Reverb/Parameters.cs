using System.Collections.Generic;
using JD_XI_Editor.Models.Enums.Effects.Common;
using JD_XI_Editor.Models.Enums.Effects.Reverb;
using JD_XI_Editor.Utils;

// ReSharper disable InvertIf

namespace JD_XI_Editor.Models.Patches.Program.Effects.Reverb
{
    internal class Parameters : EffectParameters
    {
        /// <inheritdoc />
        /// <summary>
        ///     Creates new instance of Reverb Parameters
        /// </summary>
        public Parameters()
        {
            Reset();
        }

        /// <inheritdoc />
        public sealed override void Reset()
        {
            Type = Type.Hall1;
            Time = 80;
            HfDamp = HfDamp.Damp5000;
            Level = 0;
        }

        /// <inheritdoc />
        public override byte[] GetBytes()
        {
            var bytes = new List<byte>();
            bytes.AddRange(ByteUtils.NumberTo4Packets((byte) Type));
            bytes.AddRange(ByteUtils.NumberTo4Packets(Time));
            bytes.AddRange(ByteUtils.NumberTo4Packets((byte) HfDamp));
            bytes.AddRange(ByteUtils.NumberTo4Packets(Level));

            var reserve = new byte[] { 0x00, 0x00, 0x80, 0x00 };
            for (var i = 0; i < 20; i++)
            {
                bytes.AddRange(reserve);
            }

            return bytes.ToArray();
        }

        #region Fields

        /// <summary>
        ///     Type
        /// </summary>
        private Type _type;

        /// <summary>
        ///     Time
        /// </summary>
        private int _time;

        /// <summary>
        ///     HF Damp
        /// </summary>
        private HfDamp _hfDamp;

        /// <summary>
        ///     Level
        /// </summary>
        private int _level;

        #endregion

        #region Properties

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