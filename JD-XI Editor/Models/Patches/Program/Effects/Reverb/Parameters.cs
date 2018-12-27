using System;
using System.Collections.Generic;
using System.Linq;
using JD_XI_Editor.Exceptions;
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
        public override void CopyFrom(byte[] data)
        {
            if (data.Length != DumpLength)
            {
                throw new InvalidDumpSizeException(DumpLength, data.Length);
            }

            Type = (Type) ByteUtils.NumberFrom4MidiPackets(data.Take(4).ToArray());
            Time = ByteUtils.NumberFrom4MidiPackets(data.Skip(4).Take(4).ToArray());
            HfDamp = (HfDamp) ByteUtils.NumberFrom4MidiPackets(data.Skip(8).Take(4).ToArray());
            Level = ByteUtils.NumberFrom4MidiPackets(data.Skip(12).Take(4).ToArray());
        }

        /// <inheritdoc />
        public override byte[] GetBytes()
        {
            var bytes = new List<byte>();

            bytes.AddRange(ByteUtils.NumberTo4MidiPackets((byte) Type));
            bytes.AddRange(ByteUtils.NumberTo4MidiPackets(Time));
            bytes.AddRange(ByteUtils.NumberTo4MidiPackets((byte) HfDamp));
            bytes.AddRange(ByteUtils.NumberTo4MidiPackets(Level));
            bytes.AddRange(ByteUtils.Repeat4MidiPacketsReserve(20));

            return bytes.ToArray();
        }

        #region Properties

        /// <inheritdoc />
        public override int DumpLength { get; } = 96;

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