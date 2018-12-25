using System;
using JD_XI_Editor.Exceptions;
using PropertyChanged;

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
        public void CopyFrom(IPatch patch)
        {
            if (patch is Patch p)
            {
                Effect1.CopyFrom(p.Effect1);
                Effect2.CopyFrom(p.Effect2);
                Delay.CopyFrom(p.Delay);
                Reverb.CopyFrom(p.Delay);
            }
            else
            {
                throw new NotSupportedException("Copying from that type is not supported");
            }
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
        [DoNotNotify]
        public Effect1.Patch Effect1 { get; }

        /// <summary>
        ///     Effect 2
        /// </summary>
        [DoNotNotify]
        public Effect2.Patch Effect2 { get; }

        /// <summary>
        ///     Delay patch
        /// </summary>
        [DoNotNotify]
        public Delay.Patch Delay { get; }

        /// <summary>
        ///     Reverb patch
        /// </summary>
        [DoNotNotify]
        public Reverb.Patch Reverb { get; }

        #endregion
    }
}