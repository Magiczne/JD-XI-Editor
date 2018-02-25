using Caliburn.Micro;

namespace JD_XI_Editor.Models.Patches.Analog
{
    internal class LfoModControl : PropertyChangedBase, IPatchPart
    {
        /// <inheritdoc />
        /// <summary>
        ///     Creates new instance of LfoModControl
        /// </summary>
        public LfoModControl()
        {
            Reset();
        }

        /// <inheritdoc />
        public void Reset()
        {
            PitchModControl = 16;
            FilterModControl = 0;
            AmpModControl = 0;
            RateModControl = 18;
        }

        /// <inheritdoc />
        public byte[] GetBytes()
        {
            return new[]
            {
                (byte) (PitchModControl + 64),
                (byte) (FilterModControl + 64),
                (byte) (AmpModControl + 64),
                (byte) (RateModControl + 64)
            };
        }

        #region Properties

        /// <summary>
        ///     Pitch modulation control
        /// </summary>
        public int PitchModControl { get; set; }

        /// <summary>
        ///     Filter modulation control
        /// </summary>
        public int FilterModControl { get; set; }

        /// <summary>
        ///     Amplifier modulation control
        /// </summary>
        public int AmpModControl { get; set; }

        /// <summary>
        ///     Rate modulation control
        /// </summary>
        public int RateModControl { get; set; }

        #endregion
    }
}