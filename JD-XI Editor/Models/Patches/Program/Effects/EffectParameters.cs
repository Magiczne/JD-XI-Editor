using Caliburn.Micro;

namespace JD_XI_Editor.Models.Patches.Program.Effects
{
    /// <summary>
    ///     Class is not abstract for deserialization reasons.
    ///     This is the simplest solutions, instead of writing custom, complicated
    ///     deserialization logic just for FX model.
    /// </summary>
    internal class EffectParameters : PropertyChangedBase, IPatchPart
    {
        /// <inheritdoc />
        public virtual int DumpLength { get; } = 0;

        /// <inheritdoc />
        public virtual void Reset()
        {
            // noop
        }

        /// <inheritdoc />
        public virtual void CopyFrom(IPatchPart part)
        {
            // noop
        }

        /// <inheritdoc />
        public virtual void CopyFrom(byte[] data)
        {
            // noop
        }

        /// <inheritdoc />
        public virtual byte[] GetBytes()
        {
            return new byte[0];
        }
    }
}