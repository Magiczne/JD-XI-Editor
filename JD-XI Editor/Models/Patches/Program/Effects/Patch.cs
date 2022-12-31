using System;
using System.Collections.Generic;
using System.Linq;
using JD_XI_Editor.Exceptions;
using JD_XI_Editor.Managers.Enums;
using PropertyChanged;
using Sanford.Multimedia.Midi;

namespace JD_XI_Editor.Models.Patches.Program.Effects
{
    internal class Patch : IPatch
    {
        /// <inheritdoc />
        /// <summary>
        ///     Creates new instance of Patch
        /// </summary>
        public Patch()
        {
            Effect1 = new Effect1.Patch();
            Effect2 = new Effect2.Patch();
            Delay = new Delay.Patch();
            Reverb = new Reverb.Patch();
        }

        /// <inheritdoc />
        /// <summary>
        ///     Creates new instance of Patch using sysex dump
        /// </summary>
        public Patch(Dictionary<Effect, SysExMessage> effects) : this()
        {
            CopyFrom(effects);
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
                Reverb.CopyFrom(p.Reverb);
            }
            else
            {
                throw new NotSupportedException("Copying from that type is not supported");
            }
        }

        /// <summary>
        ///     Copy data from sysex dumps
        /// </summary>
        public void CopyFrom(Dictionary<Effect, SysExMessage> effects)
        {
            // Skipping 12 bytes from front because it's header and address offset
            // Skipping 2 bytes from end because it's checksum and sysex footer

            var effect1Bytes = effects[Effect.Effect1].GetBytes().Skip(12).ToArray();
            var effect2Bytes = effects[Effect.Effect2].GetBytes().Skip(12).ToArray();
            var delayBytes = effects[Effect.Delay].GetBytes().Skip(12).ToArray();
            var reverbBytes = effects[Effect.Reverb].GetBytes().Skip(12).ToArray();

            Effect1.CopyFrom(effect1Bytes.Take(effect1Bytes.Length - 2).ToArray());
            Effect2.CopyFrom(effect2Bytes.Take(effect2Bytes.Length - 2).ToArray());
            Delay.CopyFrom(delayBytes.Take(delayBytes.Length - 2).ToArray());
            Reverb.CopyFrom(reverbBytes.Take(reverbBytes.Length - 2).ToArray());
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
        public Effect1.Patch Effect1 { get; set; }

        /// <summary>
        ///     Effect 2
        /// </summary>
        [DoNotNotify]
        public Effect2.Patch Effect2 { get; set; }

        /// <summary>
        ///     Delay patch
        /// </summary>
        [DoNotNotify]
        public Delay.Patch Delay { get; set; }

        /// <summary>
        ///     Reverb patch
        /// </summary>
        [DoNotNotify]
        public Reverb.Patch Reverb { get; set; }

        #endregion
    }
}