using System;
using System.Collections.Generic;
using System.Linq;
using JD_XI_Editor.Exceptions;
using JD_XI_Editor.Models.Enums.Program.Effects.Common;
using JD_XI_Editor.Models.Enums.Program.Effects.Slicer;
using JD_XI_Editor.Utils;

namespace JD_XI_Editor.Models.Patches.Program.Effects.Effect2
{
    internal class SlicerParameters : EffectParameters
    {
        /// <inheritdoc />
        /// <summary>
        ///     Creates new instance of Slicer Parameters
        /// </summary>
        public SlicerParameters()
        {
            Reset();
        }

        /// <inheritdoc />
        public sealed override void Reset()
        {
            TimingPattern = TimingPattern.Zero;
            Note = Note.One;
            Attack = 39;
            TriggerLevel = 50;
            Level = 127;
        }

        /// <inheritdoc />
        public override void CopyFrom(IPatchPart part)
        {
            if (part is SlicerParameters p)
            {
                TimingPattern = p.TimingPattern;
                Note = p.Note;
                Attack = p.Attack;
                TriggerLevel = p.TriggerLevel;
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

            TimingPattern = (TimingPattern) ByteUtils.NumberFrom4MidiPackets(data.Take(4).ToArray());
            Note = (Note) ByteUtils.NumberFrom4MidiPackets(data.Skip(4).Take(4).ToArray());
            Attack = ByteUtils.NumberFrom4MidiPackets(data.Skip(8).Take(4).ToArray());
            TriggerLevel = ByteUtils.NumberFrom4MidiPackets(data.Skip(12).Take(4).ToArray());
            Level = ByteUtils.NumberFrom4MidiPackets(data.Skip(16).Take(4).ToArray());
        }

        /// <inheritdoc />
        public override byte[] GetBytes()
        {
            var bytes = new List<byte>();

            bytes.AddRange(ByteUtils.NumberTo4MidiPackets((byte) TimingPattern));
            bytes.AddRange(ByteUtils.NumberTo4MidiPackets((byte) Note));
            bytes.AddRange(ByteUtils.NumberTo4MidiPackets(Attack));
            bytes.AddRange(ByteUtils.NumberTo4MidiPackets(TriggerLevel));
            bytes.AddRange(ByteUtils.NumberTo4MidiPackets(Level));
            bytes.AddRange(ByteUtils.Repeat4MidiPacketsReserve(27));

            return bytes.ToArray();
        }

        #region Properties

        /// <inheritdoc />
        public override int DumpLength { get; } = 128;

        /// <summary>
        ///     Timing Pattern
        /// </summary>
        public TimingPattern TimingPattern { get; set; }

        /// <summary>
        ///     Note
        /// </summary>
        public Note Note { get; set; }

        /// <summary>
        ///     Attack
        /// </summary>
        public int Attack { get; set; }

        /// <summary>
        ///     TriggerLevel
        /// </summary>
        public int TriggerLevel { get; set; }

        /// <summary>
        ///     Level
        /// </summary>
        public int Level { get; set; }

        #endregion
    }
}