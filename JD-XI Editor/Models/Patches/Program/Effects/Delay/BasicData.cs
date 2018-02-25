using Caliburn.Micro;
using JD_XI_Editor.Utils;

namespace JD_XI_Editor.Models.Patches.Program.Effects.Delay
{
    internal class BasicData : PropertyChangedBase, IPatchPart
    {
        /// <inheritdoc />
        /// <summary>
        ///     Creates a new instance of BasicData
        /// </summary>
        public BasicData()
        {
            Reset();
        }

        /// <inheritdoc />
        public void Reset()
        {
            On = true;
            Level = 0;
            ReverbSendLevel = 0;
        }

        /// <inheritdoc />
        public byte[] GetBytes()
        {
            return new byte[]
            {
                ByteUtils.BooleanToByte(On),
                (byte) Level,
                0x00, // Reserve
                (byte) ReverbSendLevel
            };
        }

        #region Properties

        /// <summary>
        ///     Is delay on
        /// </summary>
        public bool On { get; set; }

        /// <summary>
        ///     Level
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        ///     Reverb Send Level
        /// </summary>
        public int ReverbSendLevel { get; set; }

        #endregion
    }
}