using System;
using Caliburn.Micro;
using JD_XI_Editor.Models.Enums.Common;
using JD_XI_Editor.Models.Enums.DrumKit;

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
        public void CopyFrom(IPatchPart part)
        {
            if (part is Amplifier amp)
            {
                Level = amp.Level;
                CoarseTune = amp.CoarseTune;
                FineTune = amp.FineTune;
                RandomPitchDepth = amp.RandomPitchDepth;
                Panorama = amp.Panorama;
                RandomPanoramaDepth = amp.RandomPanoramaDepth;
                AlternatePanoramaDepth = amp.AlternatePanoramaDepth;
                EnvelopeMode = amp.EnvelopeMode;
            }
            else
            {
                throw new NotSupportedException("Copying from that type is not supported");
            }
        }

        /// <inheritdoc />
        public void CopyFrom(byte[] data)
        {
            throw new NotImplementedException();
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

        //TODO: Init
        /// <inheritdoc />
        public int DumpLength { get; }

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