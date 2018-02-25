using System.Collections.Generic;
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
        public override byte[] GetBytes()
        {
            var bytes = new List<byte>();

            bytes.AddRange(ByteUtils.NumberTo4Packets((byte) Mode));
            bytes.AddRange(ByteUtils.NumberTo4Packets(Rate));
            bytes.AddRange(ByteUtils.NumberTo4Packets((byte) Note));
            bytes.AddRange(ByteUtils.NumberTo4Packets(Depth));
            bytes.AddRange(ByteUtils.NumberTo4Packets(Feedback));
            bytes.AddRange(ByteUtils.NumberTo4Packets(Manual));
            bytes.AddRange(ByteUtils.NumberTo4Packets(DryWetBalance));
            bytes.AddRange(ByteUtils.NumberTo4Packets(Level));
            bytes.AddRange(ByteUtils.Repeat4PacketsReserve(24));

            return bytes.ToArray();
        }

        #region Properties

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