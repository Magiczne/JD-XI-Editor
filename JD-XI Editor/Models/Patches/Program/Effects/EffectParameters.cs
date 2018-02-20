using System.Collections.Generic;
using Caliburn.Micro;

namespace JD_XI_Editor.Models.Patches.Program.Effects
{
    internal abstract class EffectParameters : PropertyChangedBase, IPatchPart
    {
        /// <summary>
        ///     Offset dictionary for the params, 
        ///     where the key is the minimum value that can be achived and the value is the offset
        /// </summary>
        protected static Dictionary<int, int> ParamOffsets = new Dictionary<int, int>
        {
            { 0, 0x4E20 }
        };

        /// <inheritdoc />
        public abstract void Reset();

        /// <inheritdoc />
        public abstract byte[] GetBytes();
    }
}