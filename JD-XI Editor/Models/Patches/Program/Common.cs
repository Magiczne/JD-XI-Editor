using Caliburn.Micro;
using JD_XI_Editor.Models.Enums.Program.VocalEffect;

namespace JD_XI_Editor.Models.Patches.Program
{
    internal class Common : PropertyChangedBase, IPatchPart
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
        ///     Program Name (12 chars)
        /// </summary>
        private string _name;
            
        /// <summary>
        ///     Program Level
        /// </summary>
        private int _level;

        /// <summary>
        ///     Program Tempo
        /// </summary>
        private int _tempo;

        /// <summary>
        ///     Vocal Effect Type
        /// </summary>
        private Type _vocalEffectType;

        //Vocal effect number
        //Vocal effect part

        /// <summary>
        ///     Auto Note Switch
        /// </summary>
        private bool _autoNote;

        #endregion
    }
}