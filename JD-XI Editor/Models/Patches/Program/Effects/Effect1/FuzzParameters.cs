﻿using System;
using System.Collections.Generic;
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
        public override byte[] GetBytes()
        {
            var bytes = new List<byte>();

            bytes.AddRange(ByteUtils.NumberTo4Packets(Level));
            bytes.AddRange(ByteUtils.NumberTo4Packets(Drive));
            bytes.AddRange(ByteUtils.NumberTo4Packets((byte) Type));
            bytes.AddRange(ByteUtils.NumberTo4Packets(Presence));
            bytes.AddRange(ByteUtils.Repeat4PacketsReserve(28));

            return bytes.ToArray();
        }

        #region Properties

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