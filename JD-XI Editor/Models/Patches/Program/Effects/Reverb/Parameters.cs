using JD_XI_Editor.Models.Enums.Effects.Common;
using JD_XI_Editor.Models.Enums.Effects.Reverb;

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
            On = true;
            Type = Type.Hall1;
            Time = 80;
            HfDamp = HfDamp.Damp5000;
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