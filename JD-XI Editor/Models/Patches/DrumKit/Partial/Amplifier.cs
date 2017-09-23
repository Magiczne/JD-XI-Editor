using System;
using Caliburn.Micro;
using JD_XI_Editor.Models.Enums.DrumKit;

// ReSharper disable InvertIf

namespace JD_XI_Editor.Models.Patches.DrumKit.Partial
{
    internal class Amplifier : PropertyChangedBase, IPatchPart
    {
        /// <inheritdoc />
        public Amplifier()
        {
            Reset();
        }

        /// <inheritdoc />
        public void Reset()
        {
            Level = 127;
            CoarseTune = NotePitch.C4;
            FineTune = 0;
            RandomPitchDepth = RandomPitchDepth.Zero;
            Panorama = 0;
            RandomPanoramaDepth = 0;
            AlternatePanoramaDepth = 0;
            EnvelopeMode = EnvelopeMode.Sustain;
        }

        /// <inheritdoc />
        public byte[] GetBytes()
        {
            return new[]
            {
                (byte) Level,
                (byte) CoarseTune,
                (byte) (FineTune + 64),
                (byte) RandomPitchDepth,
                (byte) (Panorama + 64),
                (byte) (RandomPanoramaDepth),
                (byte) (AlternatePanoramaDepth + 64),
                (byte) EnvelopeMode
            };
        }

        #region Fields

        /// <summary>
        ///     Level
        /// </summary>
        private int _level;

        /// <summary>
        ///     Coarse tune
        /// </summary>
        private NotePitch _coarseTune;

        /// <summary>
        ///     Fine tune
        /// </summary>
        private int _fineTune;

        /// <summary>
        ///     Random pitch depth
        /// </summary>
        private RandomPitchDepth _randomPitchDepth;

        /// <summary>
        ///     Panorama
        /// </summary>
        private int _panorama;

        /// <summary>
        ///     Random panorama depth
        /// </summary>
        private int _randomPanoramaDepth;

        /// <summary>
        ///     Alternate panorama depth
        /// </summary>
        private int _alternatePanoramaDepth;

        /// <summary>
        ///     Envelope mode
        /// </summary>
        private EnvelopeMode _envelopeMode;

        #endregion

        #region Properties

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
        ///     Coarse tune
        /// </summary>
        public NotePitch CoarseTune
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
        ///     Random pitch depth
        /// </summary>
        public RandomPitchDepth RandomPitchDepth
        {
            get => _randomPitchDepth;
            set
            {
                if (value != _randomPitchDepth)
                {
                    _randomPitchDepth = value;
                    NotifyOfPropertyChange(nameof(RandomPitchDepth));
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
        ///     Random panorama depth
        /// </summary>
        public int RandomPanoramaDepth
        {
            get => _randomPanoramaDepth;
            set
            {
                if (value != _randomPanoramaDepth)
                {
                    _randomPanoramaDepth = value;
                    NotifyOfPropertyChange(nameof(RandomPanoramaDepth));
                }
            }
        }

        /// <summary>
        ///     Alternate panorama depth
        /// </summary>
        public int AlternatePanoramaDepth
        {
            get => _alternatePanoramaDepth;
            set
            {
                if (value != _alternatePanoramaDepth)
                {
                    _alternatePanoramaDepth = value;
                    NotifyOfPropertyChange(nameof(AlternatePanoramaDepth));
                }
            }
        }

        /// <summary>
        ///     Envelope mode
        /// </summary>
        public EnvelopeMode EnvelopeMode
        {
            get => _envelopeMode;
            set
            {
                if (value != _envelopeMode)
                {
                    _envelopeMode = value;
                    NotifyOfPropertyChange(nameof(EnvelopeMode));
                }
            }
        }

        #endregion
    }
}