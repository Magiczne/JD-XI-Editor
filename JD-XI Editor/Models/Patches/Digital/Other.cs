using Caliburn.Micro;
using JD_XI_Editor.Models.Enums.Common;
using JD_XI_Editor.Models.Enums.Digital;

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
        }

        /// <inheritdoc />
        public byte[] GetBytes()
        {
            return new[]
            {
                (byte) WaveGain,
                (byte) (((int) WaveNumber >> 12) & 0xF),
                (byte) (((int) WaveNumber >> 8) & 0xF),
                (byte) (((int) WaveNumber >> 4) & 0xF),
                (byte) ((int) WaveNumber & 0xF), //Wave number splitted
                (byte) HpfCutoff,
                (byte) SuperSawDetune,
                (byte) (ModLfoRateControl + 64),
                (byte) (AmpLevelKeyfollow / 10 + 64)
            };
        }

        #region Properties

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