using Caliburn.Micro;

// ReSharper disable InvertIf

namespace JD_XI_Editor.Models
{
    internal class Adsr : PropertyChangedBase
    {
        /// <inheritdoc />
        /// <summary>
        ///     Create new instance of ADSR
        /// </summary>
        /// <param name="attack">Attack</param>
        /// <param name="decay">Decay</param>
        /// <param name="sustain">Sustain</param>
        /// <param name="release">Release</param>
        public Adsr(int attack, int decay, int sustain, int release)
        {
            Set(attack, decay, sustain, release);
        }

        /// <summary>
        ///     Set all params at once
        /// </summary>
        /// <param name="attack">Attack</param>
        /// <param name="decay">Decay</param>
        /// <param name="sustain">Sustain</param>
        /// <param name="release">Release</param>
        public void Set(int attack, int decay, int sustain, int release)
        {
            Attack = attack;
            Decay = decay;
            Sustain = sustain;
            Release = release;
        }

        #region Fields

        /// <summary>
        ///     Attack
        /// </summary>
        private int _attack;

        /// <summary>
        ///     Decay
        /// </summary>
        private int _decay;

        /// <summary>
        ///     Sustain
        /// </summary>
        private int _sustain;

        /// <summary>
        ///     Release
        /// </summary>
        private int _release;

        #endregion

        #region Properties

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
        ///     Decay
        /// </summary>
        public int Decay
        {
            get => _decay;
            set
            {
                if (value != _decay)
                {
                    _decay = value;
                    NotifyOfPropertyChange(nameof(Decay));
                }
            }
        }

        /// <summary>
        ///     Sustain
        /// </summary>
        public int Sustain
        {
            get => _sustain;
            set
            {
                if (value != _sustain)
                {
                    _sustain = value;
                    NotifyOfPropertyChange(nameof(Sustain));
                }
            }
        }

        /// <summary>
        ///     Release
        /// </summary>
        public int Release
        {
            get => _release;
            set
            {
                if (value != _release)
                {
                    _release = value;
                    NotifyOfPropertyChange(nameof(Release));
                }
            }
        }

        #endregion
    }
}