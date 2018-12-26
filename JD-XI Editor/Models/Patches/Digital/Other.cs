using System;
using System.Collections.Generic;
using System.Linq;
using Caliburn.Micro;
using JD_XI_Editor.Exceptions;
using JD_XI_Editor.Models.Enums.Common;
using JD_XI_Editor.Models.Enums.Digital;
using JD_XI_Editor.Utils;

namespace JD_XI_Editor.Models.Patches.Digital
{
    internal class Other : PropertyChangedBase, IPatchPart
    {
        /// <inheritdoc />
        /// <summary>
        ///     Creates new instance of Other
        /// </summary>
        public Other()
        {
            Reset();
        }

        /// <inheritdoc />
        public void Reset()
        {
            WaveGain = WaveGain.Zero;
            WaveNumber = PcmWave.SyncSweep;
            HpfCutoff = 0;
            SuperSawDetune = 0;
            ModLfoRateControl = 18;
            AmpLevelKeyfollow = 0;
        }

        /// <inheritdoc />
        public void CopyFrom(IPatchPart part)
        {
            if (part is Other other)
            {
                WaveGain = other.WaveGain;
                WaveNumber = other.WaveNumber;
                HpfCutoff = other.HpfCutoff;
                SuperSawDetune = other.SuperSawDetune;
                ModLfoRateControl = other.ModLfoRateControl;
                AmpLevelKeyfollow = other.AmpLevelKeyfollow;
            }
            else
            {
                throw new NotSupportedException("Copying from that type is not supported");
            }
        }

        /// <inheritdoc />
        public void CopyFrom(byte[] data)
        {
            if (data.Length != DumpLength)
            {
                throw new InvalidDumpSizeException(DumpLength, data.Length);
            }

            WaveGain = (WaveGain) data[0];
            WaveNumber = (PcmWave) ByteUtils.NumberFrom4MidiPackets(data.Skip(1).Take(4).ToArray());
            HpfCutoff = data[5];
            SuperSawDetune = data[6];
            ModLfoRateControl = data[7] - 64;
            AmpLevelKeyfollow = (data[8] - 64) * 10;
        }

        /// <inheritdoc />
        public byte[] GetBytes()
        {
            var bytes = new List<byte>
            {
                (byte) WaveGain
            };
            bytes.AddRange(ByteUtils.NumberTo4MidiPackets((int) WaveNumber, ByteUtils.Offset.None));
            bytes.AddRange(new byte[]
            {
                (byte) HpfCutoff,
                (byte) SuperSawDetune,
                (byte) (ModLfoRateControl + 64),
                (byte) (AmpLevelKeyfollow / 10 + 64)
            });

            return bytes.ToArray();
        }

        #region Properties

        /// <inheritdoc />
        public int DumpLength { get; } = 9;

        /// <summary>
        ///     Wave gain
        /// </summary>
        public WaveGain WaveGain { get; set; }

        /// <summary>
        ///     Wave number
        /// </summary>
        public PcmWave WaveNumber { get; set; }

        /// <summary>
        ///     High Pass Filter cutoff
        /// </summary>
        public int HpfCutoff { get; set; }

        /// <summary>
        ///     Super saw detune
        /// </summary>
        public int SuperSawDetune { get; set; }

        /// <summary>
        ///     LFO Mod Rate Control
        /// </summary>
        public int ModLfoRateControl { get; set; }

        /// <summary>
        ///     Amplifier Level Keyfollow
        /// </summary>
        public int AmpLevelKeyfollow { get; set; }

        #endregion
    }
}