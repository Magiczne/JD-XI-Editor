using Caliburn.Micro;
using JD_XI_Editor.Models.Enums.Program.VocalEffect.AutoPitch;

namespace JD_XI_Editor.Models.Patches.Program.VocalEffect
{
    internal class AutoPitch : PropertyChangedBase, IPatchPart
    {
        /// <inheritdoc />
        public void Reset()
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc />
        public byte[] GetBytes()
        {
            throw new System.NotImplementedException();
        }

        #region Fields

        /// <summary>
        ///     Auto Pitch Switch
        /// </summary>
        private bool _on;

        /// <summary>
        ///     Auto Pitch Type
        /// </summary>
        private Type _type;

        /// <summary>
        ///     Auto Pitch Scale
        /// </summary>
        private Scale _scale;

        /// <summary>
        ///     Auto Pitch Key
        /// </summary>
        private Key _key;

        /// <summary>
        ///     Auto Pitch Note
        /// </summary>
        private Note _note;

        /// <summary>
        ///     Auto Pitch Gender
        /// </summary>
        private int _gender;

        /// <summary>
        ///     Auto Pitch Octave
        /// </summary>
        private Octave _octave;

        /// <summary>
        ///     Auto Pitch Balance
        /// </summary>
        private int _dryWetBalance;

        #endregion
    }
}