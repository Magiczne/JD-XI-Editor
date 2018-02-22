using Caliburn.Micro;
using JD_XI_Editor.Models.Enums.Program.VocalEffect;

namespace JD_XI_Editor.Models.Patches.Program.VocalEffect
{
    internal class Common : PropertyChangedBase, IPatchPart
    {
        /// <inheritdoc />
        public void Reset()
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc />
        public byte[] GetBytes()
        {
            throw new System.NotImplementedException();
        }

        #region Fields

        /// <summary>
        ///     Level
        /// </summary>
        private int _level;

        /// <summary>
        ///     Pan
        /// </summary>
        private int _panorama;

        /// <summary>
        ///     Delay Send Level
        /// </summary>
        private int _delaySendLevel;

        /// <summary>
        ///     Reverb Send Level
        /// </summary>
        private int _reverbSendLevel;

        /// <summary>
        ///     Output Assign
        /// </summary>
        private OutputAssign _outputAssign;

        #endregion
    }
}