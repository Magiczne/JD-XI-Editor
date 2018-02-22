using JD_XI_Editor.Exceptions;

namespace JD_XI_Editor.Models.Patches.Program.Effects
{
    internal class Patch : IPatch
    {
        public Patch()
        {
            Effect1 = new Effect1.Patch();
            Effect2 = new Effect2.Patch();
            Delay = new Delay.Patch();
            Reverb = new Reverb.Patch();
        }

        /// <inheritdoc />
        public void Reset()
        {
            Effect1.Reset();
            Effect2.Reset();
            Delay.Reset();
            Reverb.Reset();
        }

        /// <inheritdoc />
        public byte[] GetBytes()
        {
            throw new PatchNotConvertibleIntoBytes();
        }

        #region Properties

        /// <summary>
        ///     Effect 1
        /// </summary>
        public Effect1.Patch Effect1 { get; }

        /// <summary>
        ///     Effect 2
        /// </summary>
        public Effect2.Patch Effect2 { get; }

        /// <summary>
        ///     Delay patch
        /// </summary>
        public Delay.Patch Delay { get; }

        /// <summary>
        ///     Reverb patch
        /// </summary>
        public Reverb.Patch Reverb { get; }

        #endregion
    }
}