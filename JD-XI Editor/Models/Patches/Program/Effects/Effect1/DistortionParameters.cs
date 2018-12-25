using System;
using System.Collections.Generic;
using JD_XI_Editor.Utils;
using Type = JD_XI_Editor.Models.Enums.Program.Effects.Distortion.Type;

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
        public override void CopyFrom(IPatchPart part)
        {
            if (part is DistortionParameters p)
            {
                Type = p.Type;
                Drive = p.Drive;
                Presence = p.Presence;
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

            bytes.AddRange(ByteUtils.NumberTo4MidiPackets(Level));
            bytes.AddRange(ByteUtils.NumberTo4MidiPackets(Drive));
            bytes.AddRange(ByteUtils.NumberTo4MidiPackets((byte) Type));
            bytes.AddRange(ByteUtils.NumberTo4MidiPackets(Presence));
            bytes.AddRange(ByteUtils.Repeat4MidiPacketsReserve(28));

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