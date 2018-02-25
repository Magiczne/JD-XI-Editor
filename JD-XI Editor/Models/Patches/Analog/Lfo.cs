using Caliburn.Micro;
using JD_XI_Editor.Models.Enums.Common;
using JD_XI_Editor.Utils;

// ReSharper disable InvertIf

namespace JD_XI_Editor.Models.Patches.Analog
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
            Rate = 53;
            FadeTime = 0;
            TempoSync = false;
            SyncNote = SyncNote.SixteenthNote;
            PitchDepth = 0;
            FilterDepth = 0;
            AmpDepth = 0;
            KeyTrigger = true;
        }

        /// <inheritdoc />
        public byte[] GetBytes()
        {
            return new[]
            {
                (byte) Shape,
                (byte) Rate,
                (byte) FadeTime,
                ByteUtils.BooleanToByte(TempoSync),
                (byte) SyncNote,
                (byte) (PitchDepth + 64),
                (byte) (FilterDepth + 64),
                (byte) (AmpDepth + 64),
                ByteUtils.BooleanToByte(KeyTrigger)
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
        ///     Fade time
        /// </summary>
        public int FadeTime { get; set; }

        /// <summary>
        ///     Is tempo synchronization on
        /// </summary>
        public bool TempoSync { get; set; }

        /// <summary>
        ///     Tempo synchronization base note
        /// </summary>
        public SyncNote SyncNote { get; set; }

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
        ///     Is key trigger on
        /// </summary>
        public bool KeyTrigger { get; set; }

        #endregion
    }
}