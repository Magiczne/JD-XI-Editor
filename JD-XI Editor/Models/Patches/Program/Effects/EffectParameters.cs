using Caliburn.Micro;

namespace JD_XI_Editor.Models.Patches.Program.Effects
{
    internal abstract class EffectParameters : PropertyChangedBase, IPatchPart
    {
        /// <inheritdoc />
        public abstract void Reset();

        /// <inheritdoc />
        public abstract byte[] GetBytes();
    }
}