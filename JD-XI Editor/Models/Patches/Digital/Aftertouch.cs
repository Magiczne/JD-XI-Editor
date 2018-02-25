using Caliburn.Micro;

namespace JD_XI_Editor.Models.Patches.Digital
{
    internal class Aftertouch : PropertyChangedBase, IPatchPart
    {
        /// <inheritdoc />
        /// <summary>
        ///     Creates new instance of Aftertouch
        /// </summary>
        public Aftertouch()
        {
            Reset();
        }

        /// <inheritdoc />
        public void Reset()
        {
            CutoffAftertouchSensitivity = 9;
            LevelAftertouchSensitivity = 10;
        }

        /// <inheritdoc />
        public byte[] GetBytes()
        {
            return new byte[]
            {
                (byte) (CutoffAftertouchSensitivity + 64),
                (byte) (LevelAftertouchSensitivity + 64),
                0x00, //Reserve
                0x00 //Reserve
            };
        }

        #region Properties

        /// <summary>
        ///     Cutoff Aftertouch Sensitivity
        /// </summary>
        public int CutoffAftertouchSensitivity { get; set; }

        /// <summary>
        ///     Level Aftertouch Sensitivity
        /// </summary>
        public int LevelAftertouchSensitivity { get; set; }

        #endregion
    }
}