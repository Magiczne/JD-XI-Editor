using System;
using System.Collections.Generic;
using System.Linq;
using JD_XI_Editor.Exceptions;
using JD_XI_Editor.Models.Enums.Program.Effects.Common;
using JD_XI_Editor.Models.Enums.Program.Effects.Delay;
using JD_XI_Editor.Utils;
using Type = JD_XI_Editor.Models.Enums.Program.Effects.Delay.Type;

namespace JD_XI_Editor.Models.Patches.Program.Effects.Delay
{
    internal class Parameters : EffectParameters
    {
        /// <inheritdoc />
        /// <summary>
        ///     Creates a new instance of Parameters
        /// </summary>
        public Parameters()
        {
            Reset();
        }

        /// <inheritdoc />
        public sealed override void Reset()
        {
            Type = Type.Pan;
            Mode = Mode.Note;
            Note = Note.ThreeSixteenths;
            Time = 200;
            TapTime = 50;
            Feedback = 50;
            HfDamp = HfDamp.Damp5000;
            Level = 0;
        }

        /// <inheritdoc />
        public override void CopyFrom(IPatchPart part)
        {
            if (part is Parameters p)
            {
                Type = p.Type;
                Mode = p.Mode;
                Note = p.Note;
                Time = p.Time;
                TapTime = p.TapTime;
                Feedback = p.Feedback;
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
            Mode = (Mode) ByteUtils.NumberFrom4MidiPackets(data.Skip(4).Take(4).ToArray());
            Time = ByteUtils.NumberFrom4MidiPackets(data.Skip(8).Take(4).ToArray());
            Note = (Note) ByteUtils.NumberFrom4MidiPackets(data.Skip(12).Take(4).ToArray());
            TapTime = ByteUtils.NumberFrom4MidiPackets(data.Skip(16).Take(4).ToArray());
            Feedback = ByteUtils.NumberFrom4MidiPackets(data.Skip(20).Take(4).ToArray());
            HfDamp = (HfDamp) ByteUtils.NumberFrom4MidiPackets(data.Skip(24).Take(4).ToArray());
            Level = ByteUtils.NumberFrom4MidiPackets(data.Skip(28).Take(4).ToArray());
        }

        /// <inheritdoc />
        public override byte[] GetBytes()
        {
            var bytes = new List<byte>();

            bytes.AddRange(ByteUtils.NumberTo4MidiPackets((byte) Type));
            bytes.AddRange(ByteUtils.NumberTo4MidiPackets((byte) Mode));
            bytes.AddRange(ByteUtils.NumberTo4MidiPackets(Time));
            bytes.AddRange(ByteUtils.NumberTo4MidiPackets((byte) Note));
            bytes.AddRange(ByteUtils.NumberTo4MidiPackets(TapTime));
            bytes.AddRange(ByteUtils.NumberTo4MidiPackets(Feedback));
            bytes.AddRange(ByteUtils.NumberTo4MidiPackets((byte) HfDamp));
            bytes.AddRange(ByteUtils.NumberTo4MidiPackets(Level));
            bytes.AddRange(ByteUtils.Repeat4MidiPacketsReserve(16));

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
        ///     Mode
        /// </summary>
        public Mode Mode { get; set; }

        /// <summary>
        ///     Note
        /// </summary>
        public Note Note { get; set; }

        /// <summary>
        ///     Time
        /// </summary>
        public int Time { get; set; }

        /// <summary>
        ///     Tap time
        /// </summary>
        public int TapTime { get; set; }

        /// <summary>
        ///     Feedback
        /// </summary>
        public int Feedback { get; set; }

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