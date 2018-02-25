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

        #region Properties

        /// <summary>
        ///     Attack
        /// </summary>
        public int Attack { get; set; }

        /// <summary>
        ///     Decay
        /// </summary>
        public int Decay { get; set; }

        /// <summary>
        ///     Sustain
        /// </summary>
        public int Sustain { get; set; }

        /// <summary>
        ///     Release
        /// </summary>
        public int Release { get; set; }

        #endregion
    }
}