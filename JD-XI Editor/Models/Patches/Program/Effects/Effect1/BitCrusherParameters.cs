using System.Collections.Generic;
using JD_XI_Editor.Utils;

// ReSharper disable InvertIf

namespace JD_XI_Editor.Models.Patches.Program.Effects.Effect1
{
    internal class BitCrusherParameters : EffectParameters
    {
        /// <summary>
        ///     Creates new instance of BitCrusherParameters
        /// </summary>
        public BitCrusherParameters()
        {
            Reset();
        }

        /// <inheritdoc />
        public sealed override void Reset()
        {
            Rate = 75;
            Bit = 70;
            Filter = 85;
            Level = 127;
        }

        /// <inheritdoc />
        public override byte[] GetBytes()
        {
            var bytes = new List<byte>();

            bytes.AddRange(ByteUtils.NumberTo4Packets(Level));
            bytes.AddRange(ByteUtils.NumberTo4Packets(Rate));
            bytes.AddRange(ByteUtils.NumberTo4Packets(Bit));
            bytes.AddRange(ByteUtils.NumberTo4Packets(Filter));
            bytes.AddRange(ByteUtils.Repeat4PacketsReserve(28));

            return bytes.ToArray();
        }

        #region Properties

        /// <summary>
        ///     Rate
        /// </summary>
        public int Rate { get; set; }

        /// <summary>
        ///     Bit
        /// </summary>
        public int Bit { get; set; }

        /// <summary>
        ///     Filter
        /// </summary>
        public int Filter { get; set; }

        /// <summary>
        ///     Level
        /// </summary>
        public int Level { get; set; }

        #endregion
    }
}