using System;
using System.Collections.Generic;
using System.Linq;
using JD_XI_Editor.Exceptions;
using JD_XI_Editor.Models.Enums.Program.Effects.Common;
using JD_XI_Editor.Models.Enums.Program.Effects.Flanger;
using JD_XI_Editor.Utils;

namespace JD_XI_Editor.Models.Patches.Program.Effects.Effect2
{
    internal class FlangerParameters : EffectParameters
    {
        /// <inheritdoc />
        /// <summary>
        ///     Creates new instance of Flanger Parameters
        /// </summary>
        public FlangerParameters()
        {
            Reset();
        }

        /// <inheritdoc />
        public sealed override void Reset()
        {
            Mode = Mode.Note;
            Note = Note.Two;
            Rate = 25;
            Depth = 100;
            Feedback = 80;
            Manual = 30;
            DryWetBalance = 50;
            Level = 127;
        }

        /// <inheritdoc />
        public override void CopyFrom(IPatchPart part)
        {
            if (part is FlangerParameters p)
            {
                Mode = p.Mode;
                Note = p.Note;
                Rate = p.Rate;
                Depth = p.Depth;
                Feedback = p.Feedback;
                Manual = p.Manual;
                DryWetBalance = p.DryWetBalance;
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

            Mode = (Mode) ByteUtils.NumberFrom4MidiPackets(data.Take(4).ToArray());
            Rate = ByteUtils.NumberFrom4MidiPackets(data.Skip(4).Take(4).ToArray());
            Note = (Note) ByteUtils.NumberFrom4MidiPackets(data.Skip(8).Take(4).ToArray());
            Depth = ByteUtils.NumberFrom4MidiPackets(data.Skip(12).Take(4).ToArray());
            Feedback = ByteUtils.NumberFrom4MidiPackets(data.Skip(16).Take(4).ToArray());
            Manual = ByteUtils.NumberFrom4MidiPackets(data.Skip(20).Take(4).ToArray());
            DryWetBalance = ByteUtils.NumberFrom4MidiPackets(data.Skip(24).Take(4).ToArray());
            Level = ByteUtils.NumberFrom4MidiPackets(data.Skip(28).Take(4).ToArray());
        }

        /// <inheritdoc />
        public override byte[] GetBytes()
        {
            var bytes = new List<byte>();

            bytes.AddRange(ByteUtils.NumberTo4MidiPackets((byte) Mode));
            bytes.AddRange(ByteUtils.NumberTo4MidiPackets(Rate));
            bytes.AddRange(ByteUtils.NumberTo4MidiPackets((byte) Note));
            bytes.AddRange(ByteUtils.NumberTo4MidiPackets(Depth));
            bytes.AddRange(ByteUtils.NumberTo4MidiPackets(Feedback));
            bytes.AddRange(ByteUtils.NumberTo4MidiPackets(Manual));
            bytes.AddRange(ByteUtils.NumberTo4MidiPackets(DryWetBalance));
            bytes.AddRange(ByteUtils.NumberTo4MidiPackets(Level));
            bytes.AddRange(ByteUtils.Repeat4MidiPacketsReserve(24));

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
        ///     Feedback
        /// </summary>
        public int Feedback { get; set; }

        /// <summary>
        ///     Manual
        /// </summary>
        public int Manual { get; set; }

        /// <summary>
        ///     Dry/Wet Balance
        /// </summary>
        public int DryWetBalance { get; set; }

        /// <summary>
        ///     Level
        /// </summary>
        public int Level { get; set; }

        #endregion
    }
}