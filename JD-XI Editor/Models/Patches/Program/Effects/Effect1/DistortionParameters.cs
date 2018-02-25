using System.Collections.Generic;
using JD_XI_Editor.Models.Enums.Program.Effects.Distortion;
using JD_XI_Editor.Utils;

// ReSharper disable InvertIf

namespace JD_XI_Editor.Models.Patches.Program.Effects.Effect1
{
    internal class DistortionParameters : EffectParameters
    {
        /// <inheritdoc />
        /// <summary>
        ///     Creates a new instance of DistortionParameters
        /// </summary>
        public DistortionParameters()
        {
            Reset();
        }

        /// <inheritdoc />
        public sealed override void Reset()
        {
            Type = Type.Two;
            Drive = 110;
            Presence = 127;
            Level = 80;
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
        ///     Distortion Type
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