using System;
using Caliburn.Micro;
using JD_XI_Editor.Models.Enums.Common;
using JD_XI_Editor.Models.Enums.DrumKit;

// ReSharper disable InvertIf

namespace JD_XI_Editor.Models.Patches.DrumKit.Partial.Wmt
{
    internal class Wmt : PropertyChangedBase, IPatchPart
    {
        /// <inheritdoc />
        public Wmt()
        {
            Reset();
        }

        /// <inheritdoc />
        public void Reset()
        {
            On = false;
            GroupId = 0; //TODO: WHAT
            LeftWave = Wave.Off;
            RightWave = Wave.Off;
            WaveGain = WaveGain.Zero;

            Fxm = false;
            FxmColor = FxmWaveColor.One;
            FxmDepth = 0;

            TempoSync = false; //TODO: WHAT
            CoarseTune = 0;
            FineTune = 0;

            Panorama = 0;
            RandomPanorama = true;
            AlternatePanorama = AlternatePan.On;

            Level = 127;
            VelocityRangeLower = 1;
            VelocityRangeUpper = 127;
            VelocityFadeWidthLower = 0;
            VelocityFadeWidthUpper = 0;
        }

        /// <inheritdoc />
        public byte[] GetBytes()
        {
            return new[]
            {
                (byte) (On ? 0x01 : 0x00),
                (byte) GroupType,

                (byte) ((GroupId >> 24) & 0xFF),
                (byte) ((GroupId >> 16) & 0xFF),
                (byte) ((GroupId >> 8) & 0xFF),
                (byte) (GroupId & 0xFF),

                (byte) (((int) LeftWave >> 24) & 0xFF),
                (byte) (((int) LeftWave >> 16) & 0xFF),
                (byte) (((int) LeftWave >> 8) & 0xFF),
                (byte) ((int) LeftWave & 0xFF),

                (byte) (((int) RightWave >> 24) & 0xFF),
                (byte) (((int) RightWave >> 16) & 0xFF),
                (byte) (((int) RightWave >> 8) & 0xFF),
                (byte) ((int) RightWave & 0xFF),

                (byte) WaveGain,
                (byte) (Fxm ? 0x01 : 0x00),
                (byte) FxmColor,
                (byte) FxmDepth,
                (byte) (TempoSync ? 0x01 : 0x00),
                (byte) (CoarseTune + 64),
                (byte) (FineTune + 64),
                (byte) (Panorama + 64),
                (byte) (RandomPanorama ? 0x01 : 0x00),
                (byte) AlternatePanorama,
                (byte) Level,
                (byte) VelocityRangeLower,
                (byte) VelocityRangeUpper,
                (byte) VelocityFadeWidthLower,
                (byte) VelocityFadeWidthUpper
            };
        }

        #region Fields

        /// <summary>
        ///     Switch
        /// </summary>
        private bool _on;

        /// <summary>
        ///     Wave group type
        /// </summary>
        private const int GroupType = 0;

        /// <summary>
        ///     Group ID
        /// </summary>
        private int _groupId;

        /// <summary>
        ///     Left wave number (mono)
        /// </summary>
        private Wave _leftWave;

        /// <summary>
        ///     Right wave number
        /// </summary>
        private Wave _rightWave;

        /// <summary>
        ///     Wave gain
        /// </summary>
        private WaveGain _waveGain;

        /// <summary>
        ///     FXM switch
        /// </summary>
        private bool _fxm;

        /// <summary>
        ///     FXM Color
        /// </summary>
        private FxmWaveColor _fxmColor;

        /// <summary>
        ///     FXM Depth
        /// </summary>
        private int _fxmDepth;

        /// <summary>
        ///     Tempo sync
        /// </summary>
        private bool _tempoSync;

        /// <summary>
        ///     Coarse tune
        /// </summary>
        private int _coarseTune;

        /// <summary>
        ///     Fine tune
        /// </summary>
        private int _fineTune;

        /// <summary>
        ///     Panorama
        /// </summary>
        private int _panorama;

        /// <summary>
        ///     Random panorama switch
        /// </summary>
        private bool _randomPanorama;

        /// <summary>
        ///     Alternate panorama switch
        /// </summary>
        private AlternatePan _alternatePanorama;

        /// <summary>
        ///     Level
        /// </summary>
        private int _level;

        /// <summary>
        ///     Velocity range lower
        /// </summary>
        private int _velocityRangeLower;

        /// <summary>
        ///     Velocity range upper
        /// </summary>
        private int _velocityRangeUpper;

        /// <summary>
        ///     Velocity fade width lower
        /// </summary>
        private int _velocityFadeWidthLower;

        /// <summary>
        ///     Velocity fade width upper
        /// </summary>
        private int _velocityFadeWidthUpper;

        #endregion

        #region Properties

        /// <summary>
        ///     Switch
        /// </summary>
        public bool On
        {
            get => _on;
            set
            {
                if (value != _on)
                {
                    _on = value;
                    NotifyOfPropertyChange(nameof(On));
                }
            }
        }

        /// <summary>
        ///     Group ID
        /// </summary>
        public int GroupId
        {
            get => _groupId;
            set
            {
                if (value != _groupId)
                {
                    _groupId = value;
                    NotifyOfPropertyChange(nameof(GroupId));
                }
            }
        }

        /// <summary>
        ///     Left wave number (mono)
        /// </summary>
        public Wave LeftWave
        {
            get => _leftWave;
            set
            {
                if (value != _leftWave)
                {
                    _leftWave = value;
                    NotifyOfPropertyChange(nameof(LeftWave));
                }
            }
        }

        /// <summary>
        ///     Right wave number
        /// </summary>
        public Wave RightWave
        {
            get => _rightWave;
            set
            {
                if (value != _rightWave)
                {
                    _rightWave = value;
                    NotifyOfPropertyChange(nameof(RightWave));
                }
            }
        }

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
        ///     FXM switch
        /// </summary>
        public bool Fxm
        {
            get => _fxm;
            set
            {
                if (value != _fxm)
                {
                    _fxm = value;
                    NotifyOfPropertyChange(nameof(Fxm));
                }
            }
        }

        /// <summary>
        ///     FXM Color
        /// </summary>
        public FxmWaveColor FxmColor
        {
            get => _fxmColor;
            set
            {
                if (value != _fxmColor)
                {
                    _fxmColor = value;
                    NotifyOfPropertyChange(nameof(FxmColor));
                }
            }
        }

        /// <summary>
        ///     FXM Depth
        /// </summary>
        public int FxmDepth
        {
            get => _fxmDepth;
            set
            {
                if (value != _fxmDepth)
                {
                    _fxmDepth = value;
                    NotifyOfPropertyChange(nameof(FxmDepth));
                }
            }
        }

        /// <summary>
        ///     Tempo sync
        /// </summary>
        public bool TempoSync
        {
            get => _tempoSync;
            set
            {
                if (value != _tempoSync)
                {
                    _tempoSync = value;
                    NotifyOfPropertyChange(nameof(TempoSync));
                }
            }
        }

        /// <summary>
        ///     Coarse tune
        /// </summary>
        public int CoarseTune
        {
            get => _coarseTune;
            set
            {
                if (value != _coarseTune)
                {
                    _coarseTune = value;
                    NotifyOfPropertyChange(nameof(CoarseTune));
                }
            }
        }

        /// <summary>
        ///     Fine tune
        /// </summary>
        public int FineTune
        {
            get => _fineTune;
            set
            {
                if (value != _fineTune)
                {
                    _fineTune = value;
                    NotifyOfPropertyChange(nameof(FineTune));
                }
            }
        }

        /// <summary>
        ///     Panorama
        /// </summary>
        public int Panorama
        {
            get => _panorama;
            set
            {
                if (value != _panorama)
                {
                    _panorama = value;
                    NotifyOfPropertyChange(nameof(Panorama));
                }
            }
        }

        /// <summary>
        ///     Random panorama switch
        /// </summary>
        public bool RandomPanorama
        {
            get => _randomPanorama;
            set
            {
                if (value != _randomPanorama)
                {
                    _randomPanorama = value;
                    NotifyOfPropertyChange(nameof(RandomPanorama));
                }
            }
        }

        /// <summary>
        ///     Alternate panorama switch
        /// </summary>
        public AlternatePan AlternatePanorama
        {
            get => _alternatePanorama;
            set
            {
                if (value != _alternatePanorama)
                {
                    _alternatePanorama = value;
                    NotifyOfPropertyChange(nameof(AlternatePanorama));
                }
            }
        }

        /// <summary>
        ///     Level
        /// </summary>
        public int Level
        {
            get => _level;
            set
            {
                if (value != _level)
                {
                    _level = value;
                    NotifyOfPropertyChange(nameof(Level));
                }
            }
        }

        /// <summary>
        ///     Velocity range lower
        /// </summary>
        public int VelocityRangeLower
        {
            get => _velocityRangeLower;
            set
            {
                if (value != _velocityRangeLower)
                {
                    _velocityRangeLower = value;
                    NotifyOfPropertyChange(nameof(VelocityRangeLower));
                }
            }
        }

        /// <summary>
        ///     Velocity range upper
        /// </summary>
        public int VelocityRangeUpper
        {
            get => _velocityRangeUpper;
            set
            {
                if (value != _velocityRangeUpper)
                {
                    _velocityRangeUpper = value;
                    NotifyOfPropertyChange(nameof(VelocityRangeUpper));
                }
            }
        }

        /// <summary>
        ///     Velocity fade width lower
        /// </summary>
        public int VelocityFadeWidthLower
        {
            get => _velocityFadeWidthLower;
            set
            {
                if (value != _velocityFadeWidthLower)
                {
                    _velocityFadeWidthLower = value;
                    NotifyOfPropertyChange(nameof(VelocityFadeWidthLower));
                }
            }
        }

        /// <summary>
        ///     Velocity fade width upper
        /// </summary>
        public int VelocityFadeWidthUpper
        {
            get => _velocityFadeWidthUpper;
            set
            {
                if (value != _velocityFadeWidthUpper)
                {
                    _velocityFadeWidthUpper = value;
                    NotifyOfPropertyChange(nameof(VelocityFadeWidthUpper));
                }
            }
        }

        #endregion
    }
}