using Caliburn.Micro;
using JD_XI_Editor.Models.Enums.Common;
using JD_XI_Editor.Utils;

namespace JD_XI_Editor.Models.Patches.Digital
{
    internal class ModLfo : PropertyChangedBase, IPatchPart
    {
        /// <inheritdoc />
        /// <summary>
        ///     Creates new intance of ModLfo
        /// </summary>
        public ModLfo()
        {
            Reset();
        }

        /// <inheritdoc />
        public void Reset()
        {
            Shape = LfoShape.Triangle;
            Rate = 88;
            TempoSync = false;
            SyncNote = SyncNote.SixteenthNote;
            PulseWidthShift = 127;
            PitchDepth = 16;
            FilterDepth = 0;
            AmpDepth = 0;
            PanDepth = 0;
        }

        /// <inheritdoc />
        public void CopyFrom(IPatchPart part)
        {
            if (part is ModLfo modLfo)
            {
                Shape = modLfo.Shape;
                Rate = modLfo.Rate;
                TempoSync = modLfo.TempoSync;
                SyncNote = modLfo.SyncNote;
                PulseWidthShift = modLfo.PulseWidthShift;
                PitchDepth = modLfo.PitchDepth;
                FilterDepth = modLfo.FilterDepth;
                AmpDepth = modLfo.AmpDepth;
                PanDepth = modLfo.PanDepth;
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
                (byte) PulseWidthShift,
                (byte) 0x00, //Reserve
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
        ///     Pulse width shift
        /// </summary>
        public int PulseWidthShift { get; set; }

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