using Caliburn.Micro;
using JD_XI_Editor.Models.Enums.Common;
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
                (byte) RandomPanoramaDepth,
                (byte) (AlternatePanoramaDepth + 64),
                (byte) EnvelopeMode
            };
        }

        #region Properties

        /// <summary>
        ///     Level
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        ///     Coarse tune
        /// </summary>
        public NotePitch CoarseTune { get; set; }

        /// <summary>
        ///     Fine tune
        /// </summary>
        public int FineTune { get; set; }

        /// <summary>
        ///     Random pitch depth
        /// </summary>
        public RandomPitchDepth RandomPitchDepth { get; set; }

        /// <summary>
        ///     Panorama
        /// </summary>
        public int Panorama { get; set; }

        /// <summary>
        ///     Random panorama depth
        /// </summary>
        public int RandomPanoramaDepth { get; set; }

        /// <summary>
        ///     Alternate panorama depth
        /// </summary>
        public int AlternatePanoramaDepth { get; set; }

        /// <summary>
        ///     Envelope mode
        /// </summary>
        public EnvelopeMode EnvelopeMode { get; set; }

        #endregion
    }
}