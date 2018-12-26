using Caliburn.Micro;

namespace JD_XI_Editor.Models.Patches.Program.Effects
{
    internal abstract class EffectParameters : PropertyChangedBase, IPatchPart
    {
        /// <inheritdoc />
        public abstract int DumpLength { get; }

        /// <inheritdoc />
        public abstract void Reset();

        /// <inheritdoc />
        public abstract void CopyFrom(IPatchPart part);

        /// <inheritdoc />
        public abstract void CopyFrom(byte[] data);

        /// <inheritdoc />
        public abstract byte[] GetBytes();
    }
}