using System;
using System.Collections.Generic;
using JD_XI_Editor.Models.Enums.Program.Effects.Common;
using JD_XI_Editor.Utils;
using Type = JD_XI_Editor.Models.Enums.Program.Effects.Reverb.Type;

namespace JD_XI_Editor.Models.Patches.Program.Effects.Reverb
{
    internal class Parameters : EffectParameters
    {
        /// <inheritdoc />
        /// <summary>
        ///     Creates new instance of Reverb Parameters
        /// </summary>
        public Parameters()
        {
            Reset();
        }

        /// <inheritdoc />
        public sealed override void Reset()
        {
            Type = Type.Hall1;
            Time = 80;
            HfDamp = HfDamp.Damp5000;
            Level = 0;
        }

        /// <inheritdoc />
        public override void CopyFrom(IPatchPart part)
        {
            if (part is Parameters p)
            {
                Type = p.Type;
                Time = p.Time;
                HfDamp = p.HfDamp;
                Level = p.Level;
            }
            else
            {
                throw new NotSupportedException("Copying from that type is not supported");
            }
        }

        /// <inheritdoc />
        public override byte[] GetBytes()
        {
            var bytes = new List<byte>();

            bytes.AddRange(ByteUtils.NumberTo4Packets((byte) Type));
            bytes.AddRange(ByteUtils.NumberTo4Packets(Time));
            bytes.AddRange(ByteUtils.NumberTo4Packets((byte) HfDamp));
            bytes.AddRange(ByteUtils.NumberTo4Packets(Level));
            bytes.AddRange(ByteUtils.Repeat4PacketsReserve(20));

            return bytes.ToArray();
        }

        #region Properties

        /// <summary>
        ///     Type
        /// </summary>
        public Type Type { get; set; }

        /// <summary>
        ///     Time
        /// </summary>
        public int Time { get; set; }

        /// <summary>
        ///     HF Damp
        /// </summary>
        public HfDamp HfDamp { get; set; }

        /// <summary>
        ///     Level
        /// </summary>
        public int Level { get; set; }

        #endregion
    }
}