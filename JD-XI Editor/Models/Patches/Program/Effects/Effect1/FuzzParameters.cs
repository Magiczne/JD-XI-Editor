using System;
using System.Collections.Generic;
using System.Linq;
using JD_XI_Editor.Exceptions;
using JD_XI_Editor.Utils;
using Type = JD_XI_Editor.Models.Enums.Program.Effects.Fuzz.Type;

namespace JD_XI_Editor.Models.Patches.Program.Effects.Effect1
{
    internal class FuzzParameters : EffectParameters
    {
        /// <inheritdoc />
        /// <summary>
        ///     Creates a new instance of FuzzParameters
        /// </summary>
        public FuzzParameters()
        {
            Reset();
        }

        /// <inheritdoc />
        public sealed override void Reset()
        {
            Type = Type.Three;
            Drive = 100;
            Presence = 127;
            Level = 70;
        }

        /// <inheritdoc />
        public override void CopyFrom(IPatchPart part)
        {
            if (part is FuzzParameters p)
            {
                Type = p.Type;
                Drive = p.Drive;
                Presence = p.Presence;
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

            Level = ByteUtils.NumberFrom4MidiPackets(data.Take(4).ToArray());
            Drive = ByteUtils.NumberFrom4MidiPackets(data.Skip(4).Take(4).ToArray());
            Type = (Type) ByteUtils.NumberFrom4MidiPackets(data.Skip(8).Take(4).ToArray());
            Presence = ByteUtils.NumberFrom4MidiPackets(data.Skip(12).Take(4).ToArray());
        }

        /// <inheritdoc />
        public override byte[] GetBytes()
        {
            var bytes = new List<byte>();

            bytes.AddRange(ByteUtils.NumberTo4MidiPackets(Level));
            bytes.AddRange(ByteUtils.NumberTo4MidiPackets(Drive));
            bytes.AddRange(ByteUtils.NumberTo4MidiPackets((byte) Type));
            bytes.AddRange(ByteUtils.NumberTo4MidiPackets(Presence));
            bytes.AddRange(ByteUtils.Repeat4MidiPacketsReserve(28));

            return bytes.ToArray();
        }

        #region Properties

        /// <inheritdoc />
        public override int DumpLength { get; } = 128;

        /// <summary>
        ///     Fuzz Type
        /// </summary>
        public Type Type { get; set; }

        /// <summary>
        ///     Drive
        /// </summary>
        public int Drive { get; set; }

        /// <summary>
        ///     Presence
        /// </summary>
        public int Presence { get; set; }

        /// <summary>
        ///     Level
        /// </summary>
        public int Level { get; set; }

        #endregion
    }
}