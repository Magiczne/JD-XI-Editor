using System;
using System.Collections.Generic;
using JD_XI_Editor.Models.Enums.Common;
using JD_XI_Editor.Models.Enums.Program.Effects.Compressor;
using JD_XI_Editor.Utils;

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
        public override void CopyFrom(IPatchPart part)
        {
            if (part is CompressorParameters p)
            {
                Threshold = p.Threshold;
                Ratio = p.Ratio;
                Attack = p.Attack;
                Release = p.Release;
                Level = p.Level;
                Sidechain = p.Sidechain;
                SidechainSync = p.SidechainSync;
                SidechainLevel = p.SidechainLevel;
                SidechainNote = p.SidechainNote;
                SidechainTime = p.SidechainTime;
                SidechainRelease = p.SidechainRelease;
            }
            else
            {
                throw new NotSupportedException("Copying from that type is not supported");
            }
        }

        /// <inheritdoc />
        public override void CopyFrom(byte[] data)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override byte[] GetBytes()
        {
            var bytes = new List<byte>();

            bytes.AddRange(ByteUtils.NumberTo4MidiPackets(Threshold));
            bytes.AddRange(ByteUtils.NumberTo4MidiPackets((byte) Ratio));
            bytes.AddRange(ByteUtils.NumberTo4MidiPackets((byte) Attack));
            bytes.AddRange(ByteUtils.NumberTo4MidiPackets((byte) Release));
            bytes.AddRange(ByteUtils.NumberTo4MidiPackets(Level));
            bytes.AddRange(ByteUtils.BooleanTo4MidiPackets(Sidechain));
            bytes.AddRange(ByteUtils.NumberTo4MidiPackets(SidechainLevel));
            bytes.AddRange(ByteUtils.NumberTo4MidiPackets((byte) SidechainNote));
            bytes.AddRange(ByteUtils.NumberTo4MidiPackets(SidechainTime));
            bytes.AddRange(ByteUtils.NumberTo4MidiPackets(SidechainRelease));
            bytes.AddRange(ByteUtils.BooleanTo4MidiPackets(SidechainSync));
            bytes.AddRange(ByteUtils.Repeat4MidiPacketsReserve(21));

            return bytes.ToArray();
        }

        #region Properties

        /// TODO: Set
        /// <inheritdoc />
        public override int DumpLength { get; }

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