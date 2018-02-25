using System.Collections.Generic;
using JD_XI_Editor.Models.Enums.Common;
using JD_XI_Editor.Models.Enums.Program.Effects.Compressor;
using JD_XI_Editor.Utils;

// ReSharper disable InvertIf

namespace JD_XI_Editor.Models.Patches.Program.Effects.Effect1
{
    internal class CompressorParameters : EffectParameters
    {
        /// <summary>
        ///     Creates new instance of Compressor parameters
        /// </summary>
        public CompressorParameters()
        {
            Reset();
        }

        /// <inheritdoc />
        public sealed override void Reset()
        {
            Threshold = 40;
            Ratio = Ratio.FourToOne;
            Attack = Attack.ZeroPoint5;
            Release = Release.ZeroPoint05;
            Level = 50;
            Sidechain = false;
            SidechainSync = false;
            SidechainLevel = 0;
            SidechainNote = NotePitch.C2;
            SidechainTime = 60;
            SidechainRelease = 0;
        }

        /// <inheritdoc />
        public override byte[] GetBytes()
        {
            var bytes = new List<byte>();

            bytes.AddRange(ByteUtils.NumberTo4Packets(Threshold));
            bytes.AddRange(ByteUtils.NumberTo4Packets((byte) Ratio));
            bytes.AddRange(ByteUtils.NumberTo4Packets((byte) Attack));
            bytes.AddRange(ByteUtils.NumberTo4Packets((byte) Release));
            bytes.AddRange(ByteUtils.NumberTo4Packets(Level));
            bytes.AddRange(ByteUtils.BooleanTo4Packets(Sidechain));
            bytes.AddRange(ByteUtils.NumberTo4Packets(SidechainLevel));
            bytes.AddRange(ByteUtils.NumberTo4Packets((byte) SidechainNote));
            bytes.AddRange(ByteUtils.NumberTo4Packets(SidechainTime));
            bytes.AddRange(ByteUtils.NumberTo4Packets(SidechainRelease));
            bytes.AddRange(ByteUtils.BooleanTo4Packets(SidechainSync));
            bytes.AddRange(ByteUtils.Repeat4PacketsReserve(21));

            return bytes.ToArray();
        }

        #region Properties

        /// <summary>
        ///     Threshold
        /// </summary>
        public int Threshold { get; set; }

        /// <summary>
        ///     Ratio
        /// </summary>
        public Ratio Ratio { get; set; }

        /// <summary>
        ///     Attack
        /// </summary>
        public Attack Attack { get; set; }

        /// <summary>
        ///     Release
        /// </summary>
        public Release Release { get; set; }

        /// <summary>
        ///     Level
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        ///     Sidechain
        /// </summary>
        public bool Sidechain { get; set; }

        /// <summary>
        ///     Sidechain synchronization
        /// </summary>
        public bool SidechainSync { get; set; }

        /// <summary>
        ///     Sidechain level
        /// </summary>
        public int SidechainLevel { get; set; }

        /// <summary>
        ///     Sidechain note
        /// </summary>
        public NotePitch SidechainNote { get; set; }

        /// <summary>
        ///     Sidechain Time
        /// </summary>
        public int SidechainTime { get; set; }

        /// <summary>
        ///     Sidechain Release
        /// </summary>
        public int SidechainRelease { get; set; }

        #endregion
    }
}