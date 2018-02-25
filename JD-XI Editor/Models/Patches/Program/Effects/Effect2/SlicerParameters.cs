using System.Collections.Generic;
using JD_XI_Editor.Models.Enums.Program.Effects.Common;
using JD_XI_Editor.Models.Enums.Program.Effects.Slicer;
using JD_XI_Editor.Utils;

// ReSharper disable InvertIf

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
        public override byte[] GetBytes()
        {
            var bytes = new List<byte>();
            bytes.AddRange(ByteUtils.NumberTo4Packets((byte) TimingPattern));
            bytes.AddRange(ByteUtils.NumberTo4Packets((byte) Note));
            bytes.AddRange(ByteUtils.NumberTo4Packets(Attack));
            bytes.AddRange(ByteUtils.NumberTo4Packets(TriggerLevel));
            bytes.AddRange(ByteUtils.NumberTo4Packets(Level));

            var reserve = new byte[] {0x00, 0x00, 0x80, 0x00};
            for (var i = 0; i < 27; i++) bytes.AddRange(reserve);

            return bytes.ToArray();
        }

        #region Properties

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