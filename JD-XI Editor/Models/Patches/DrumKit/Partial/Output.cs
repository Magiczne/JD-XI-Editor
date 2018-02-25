using Caliburn.Micro;
using JD_XI_Editor.Models.Enums.DrumKit;

namespace JD_XI_Editor.Models.Patches.DrumKit.Partial
{
    internal class Output : PropertyChangedBase, IPatchPart
    {
        /// <inheritdoc />
        public Output()
        {
            Reset();
        }

        /// <inheritdoc />
        public void Reset()
        {
            OutputLevel = 127;
            ChorusSendLevel = 0;
            ReverbSendLevel = 64;
            OutputAssign = OutputAssign.Reverb;
        }

        /// <inheritdoc />
        public byte[] GetBytes()
        {
            return new[]
            {
                (byte) OutputLevel,
                (byte) 0x00, //Reserve
                (byte) 0x00, //Reserve
                (byte) ChorusSendLevel,
                (byte) ReverbSendLevel,
                (byte) OutputAssign
            };
        }

        #region Properties

        /// <summary>
        ///     Output level
        /// </summary>
        public int OutputLevel { get; set; }

        /// <summary>
        ///     Chorus send level
        /// </summary>
        public int ChorusSendLevel { get; set; }

        /// <summary>
        ///     Reverb send level
        /// </summary>
        public int ReverbSendLevel { get; set; }

        /// <summary>
        ///     Output assign
        /// </summary>
        public OutputAssign OutputAssign { get; set; }

        #endregion
    }
}