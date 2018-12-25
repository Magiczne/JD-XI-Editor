using System;
using Caliburn.Micro;
using JD_XI_Editor.Models.Enums.Common;
using JD_XI_Editor.Utils;

namespace JD_XI_Editor.Models.Patches.Digital
{
    internal class Lfo : PropertyChangedBase, IPatchPart
    {
        /// <inheritdoc />
        /// <summary>
        ///     Creates new instance of Lfo
        /// </summary>
        public Lfo()
        {
            Reset();
        }

        /// <inheritdoc />
        public void Reset()
        {
            Shape = LfoShape.Triangle;
            Rate = 81;
            TempoSync = false;
            SyncNote = SyncNote.SixteenthNote;
            FadeTime = 0;
            KeyTrigger = false;
            PitchDepth = 0;
            FilterDepth = 0;
            AmpDepth = 0;
            PanDepth = 0;
        }

        /// <inheritdoc />
        public void CopyFrom(IPatchPart part)
        {
            if (part is Lfo lfo)
            {
                Shape = lfo.Shape;
                Rate = lfo.Rate;
                TempoSync = lfo.TempoSync;
                SyncNote = lfo.SyncNote;
                FadeTime = lfo.FadeTime;
                KeyTrigger = lfo.KeyTrigger;
                PitchDepth = lfo.PitchDepth;
                FilterDepth = lfo.FilterDepth;
                AmpDepth = lfo.AmpDepth;
                PanDepth = lfo.PanDepth;
            }
            else
            {
                throw new NotSupportedException("Copying from that type is not supported");
            }
        }

        /// <inheritdoc />
        public byte[] GetBytes()
        {
            return new[]
            {
                (byte) Shape,
                (byte) Rate,
                ByteUtils.BooleanToByte(TempoSync),
                (byte) SyncNote,
                (byte) FadeTime,
                ByteUtils.BooleanToByte(KeyTrigger),
                (byte) (PitchDepth + 64),
                (byte) (FilterDepth + 64),
                (byte) (AmpDepth + 64),
                (byte) (PanDepth + 64)
            };
        }

        #region Properties

        /// <summary>
        ///     LFO shape
        /// </summary>
        public LfoShape Shape { get; set; }

        /// <summary>
        ///     Rate
        /// </summary>
        public int Rate { get; set; }

        /// <summary>
        ///     Is tempo synchronization on
        /// </summary>
        public bool TempoSync { get; set; }

        /// <summary>
        ///     Tempo synchronization base note
        /// </summary>
        public SyncNote SyncNote { get; set; }

        /// <summary>
        ///     Fade time
        /// </summary>
        public int FadeTime { get; set; }

        /// <summary>
        ///     Is key trigger on
        /// </summary>
        public bool KeyTrigger { get; set; }

        /// <summary>
        ///     Pitch depth
        /// </summary>
        public int PitchDepth { get; set; }

        /// <summary>
        ///     Filter depth
        /// </summary>
        public int FilterDepth { get; set; }

        /// <summary>
        ///     Amplifier depth
        /// </summary>
        public int AmpDepth { get; set; }

        /// <summary>
        ///     Panorama depth
        /// </summary>
        public int PanDepth { get; set; }

        #endregion
    }
}