using System.Collections.Generic;
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
        public override byte[] GetBytes()
        {
            var bytes = new List<byte>();

            bytes.AddRange(ByteUtils.NumberTo4Packets((byte) Mode));
            bytes.AddRange(ByteUtils.NumberTo4Packets(Rate));
            bytes.AddRange(ByteUtils.NumberTo4Packets((byte) Note));
            bytes.AddRange(ByteUtils.NumberTo4Packets(Depth));
            bytes.AddRange(ByteUtils.NumberTo4Packets(Resonance));
            bytes.AddRange(ByteUtils.NumberTo4Packets(Manual));
            bytes.AddRange(ByteUtils.NumberTo4Packets(Level));
            bytes.AddRange(ByteUtils.Repeat4PacketsReserve(25));

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