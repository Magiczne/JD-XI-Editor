using Caliburn.Micro;
using JD_XI_Editor.Models.Enums.Common;
using JD_XI_Editor.Models.Enums.Digital;

// ReSharper disable InvertIf

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
        public byte[] GetBytes()
        {
            return new[]
            {
                (byte) WaveGain,
                (byte) (((int) WaveNumber >> 12) & 0xF),
                (byte) (((int) WaveNumber >> 8) & 0xF),
                (byte) (((int) WaveNumber >> 4) & 0xF),
                (byte) ((int) WaveNumber & 0xF),           //Wave number splitted
                (byte) HpfCutoff,
                (byte) SuperSawDetune,
                (byte) (ModLfoRateControl + 64),
                (byte) (AmpLevelKeyfollow / 10 + 64)
            };
        }

        #region Fields

        /// <summary>
        ///     Wave gain
        /// </summary>
        private WaveGain _waveGain;

        /// <summary>
        ///     Wave number
        /// </summary>
        private PcmWave _waveNumber; //4 bytes!

        /// <summary>
        ///     High Pass Filter cutoff
        /// </summary>
        private int _hpfCutoff;

        /// <summary>
        ///     Super saw detune
        /// </summary>
        private int _superSawDetune;

        /// <summary>
        ///     LFO Mod Rate Control
        /// </summary>
        private int _modLfoRateControl;

        /// <summary>
        ///     Amplifier Level Keyfollow
        /// </summary>
        private int _ampLevelKeyfollow;

        #endregion

        #region Properties

        /// <summary>
        ///     Wave gain
        /// </summary>
        public WaveGain WaveGain
        {
            get => _waveGain;
            set
            {
                if (value != _waveGain)
                {
                    _waveGain = value;
                    NotifyOfPropertyChange(nameof(WaveGain));
                }
            }
        }

        /// <summary>
        ///     Wave number
        /// </summary>
        public PcmWave WaveNumber
        {
            get => _waveNumber;
            set
            {
                if (value != _waveNumber)
                {
                    _waveNumber = value;
                    NotifyOfPropertyChange(nameof(WaveNumber));
                }
            }
        }

        /// <summary>
        ///     High Pass Filter cutoff
        /// </summary>
        public int HpfCutoff
        {
            get => _hpfCutoff;
            set
            {
                if (value != _hpfCutoff)
                {
                    _hpfCutoff = value;
                    NotifyOfPropertyChange(nameof(HpfCutoff));
                }
            }
        }

        /// <summary>
        ///     Super saw detune
        /// </summary>
        public int SuperSawDetune
        {
            get => _superSawDetune;
            set
            {
                if (value != _superSawDetune)
                {
                    _superSawDetune = value;
                    NotifyOfPropertyChange(nameof(SuperSawDetune));
                }
            }
        }

        /// <summary>
        ///     LFO Mod Rate Control
        /// </summary>
        public int ModLfoRateControl
        {
            get => _modLfoRateControl;
            set
            {
                if (value != _modLfoRateControl)
                {
                    _modLfoRateControl = value;
                    NotifyOfPropertyChange(nameof(ModLfoRateControl));
                }
            }
        }

        /// <summary>
        ///     Amplifier Level Keyfollow
        /// </summary>
        public int AmpLevelKeyfollow
        {
            get => _ampLevelKeyfollow;
            set
            {
                if (value != _ampLevelKeyfollow)
                {
                    _ampLevelKeyfollow = value;
                    NotifyOfPropertyChange(nameof(AmpLevelKeyfollow));
                }
            }
        }

        #endregion
    }
}