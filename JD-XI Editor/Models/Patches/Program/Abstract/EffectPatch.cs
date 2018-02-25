using Caliburn.Micro;
using JD_XI_Editor.Models.Patches.Program.Effects;
using PropertyChanged;

// ReSharper disable InvertIf

namespace JD_XI_Editor.Models.Patches.Program.Abstract
{
    internal abstract class EffectPatch : PropertyChangedBase, IPatch
    {
        /// <inheritdoc />
        public void Reset()
        {
            Basic.Reset();
            Parameters.Reset();
        }

        /// <inheritdoc />
        public abstract byte[] GetBytes();

        #region Properties

        /// <summary>
        ///     Basic Data
        /// </summary>
        [DoNotNotify]
        public IPatchPart Basic { get; protected set; }

        /// <summary>
        ///     Delay parameters
        /// </summary>
        [DoNotNotify]
        public EffectParameters Parameters { get; protected set; }

        #endregion
    }
}