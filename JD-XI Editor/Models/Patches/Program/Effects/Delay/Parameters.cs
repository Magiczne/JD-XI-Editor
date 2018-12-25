using System;
using System.Collections.Generic;
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
            ReverbSendLevel = 0;
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
                ReverbSendLevel = p.ReverbSendLevel;
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

            bytes.AddRange(ByteUtils.NumberTo4Packets((byte) Type)); // 0x04
            bytes.AddRange(ByteUtils.NumberTo4Packets((byte) Mode)); // 0x08
            bytes.AddRange(ByteUtils.NumberTo4Packets(Time)); // 0x0C
            bytes.AddRange(ByteUtils.NumberTo4Packets((byte) Note)); // 0x10
            bytes.AddRange(ByteUtils.NumberTo4Packets(TapTime)); // 0x14
            bytes.AddRange(ByteUtils.NumberTo4Packets(Feedback)); // 0x18
            bytes.AddRange(ByteUtils.NumberTo4Packets((byte) HfDamp)); // 0x1C
            bytes.AddRange(ByteUtils.NumberTo4Packets(Level)); // 0x20
            bytes.AddRange(ByteUtils.Repeat4PacketsReserve(16));

            return bytes.ToArray();
        }

        #region Properties

        /// <summary>
        ///     Threshold
        /// </summary>
        public int Threshold { get; set; }

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
        ///     Reverb Send Level
        /// </summary>
        public int ReverbSendLevel { get; set; }

        /// <summary>
        ///     Level
        /// </summary>
        public int Level { get; set; }

        #endregion
    }
}