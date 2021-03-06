﻿using System;
using System.Collections.Generic;
using System.Linq;
using JD_XI_Editor.Exceptions;
using JD_XI_Editor.Models.Enums.Program.Effects.Common;
using JD_XI_Editor.Models.Enums.Program.Effects.Phaser;
using JD_XI_Editor.Utils;

namespace JD_XI_Editor.Models.Patches.Program.Effects.Effect2
{
    internal class PhaserParameters : EffectParameters
    {
        /// <inheritdoc />
        /// <summary>
        ///     Creates new instance of Phaser Parameters
        /// </summary>
        public PhaserParameters()
        {
            Reset();
        }

        /// <inheritdoc />
        public sealed override void Reset()
        {
            Mode = Mode.Note;
            Note = Note.One;
            Rate = 35;
            Depth = 40;
            Resonance = 40;
            Manual = 30;
            Level = 100;
        }

        /// <inheritdoc />
        public override void CopyFrom(IPatchPart part)
        {
            if (part is PhaserParameters p)
            {
                Mode = p.Mode;
                Note = p.Note;
                Rate = p.Rate;
                Depth = p.Depth;
                Resonance = p.Resonance;
                Manual = p.Manual;
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

            Mode = (Mode)ByteUtils.NumberFrom4MidiPackets(data.Take(4).ToArray());
            Rate = ByteUtils.NumberFrom4MidiPackets(data.Skip(4).Take(4).ToArray());
            Note = (Note)ByteUtils.NumberFrom4MidiPackets(data.Skip(8).Take(4).ToArray());
            Depth = ByteUtils.NumberFrom4MidiPackets(data.Skip(12).Take(4).ToArray());
            Resonance = ByteUtils.NumberFrom4MidiPackets(data.Skip(16).Take(4).ToArray());
            Manual = ByteUtils.NumberFrom4MidiPackets(data.Skip(20).Take(4).ToArray());
            Level = ByteUtils.NumberFrom4MidiPackets(data.Skip(24).Take(4).ToArray());
        }

        /// <inheritdoc />
        public override byte[] GetBytes()
        {
            var bytes = new List<byte>();

            bytes.AddRange(ByteUtils.NumberTo4MidiPackets((byte) Mode));
            bytes.AddRange(ByteUtils.NumberTo4MidiPackets(Rate));
            bytes.AddRange(ByteUtils.NumberTo4MidiPackets((byte) Note));
            bytes.AddRange(ByteUtils.NumberTo4MidiPackets(Depth));
            bytes.AddRange(ByteUtils.NumberTo4MidiPackets(Resonance));
            bytes.AddRange(ByteUtils.NumberTo4MidiPackets(Manual));
            bytes.AddRange(ByteUtils.NumberTo4MidiPackets(Level));
            bytes.AddRange(ByteUtils.Repeat4MidiPacketsReserve(25));

            return bytes.ToArray();
        }

        #region Properties

        /// <inheritdoc />
        public override int DumpLength { get; } = 128;

        /// <summary>
        ///     Mode
        /// </summary>
        public Mode Mode { get; set; }

        /// <summary>
        ///     Note
        /// </summary>
        public Note Note { get; set; }

        /// <summary>
        ///     Rate
        /// </summary>
        public int Rate { get; set; }

        /// <summary>
        ///     Depth
        /// </summary>
        public int Depth { get; set; }

        /// <summary>
        ///     Resonance
        /// </summary>
        public int Resonance { get; set; }

        /// <summary>
        ///     Manual
        /// </summary>
        public int Manual { get; set; }

        /// <summary>
        ///     Level
        /// </summary>
        public int Level { get; set; }

        #endregion
    }
}