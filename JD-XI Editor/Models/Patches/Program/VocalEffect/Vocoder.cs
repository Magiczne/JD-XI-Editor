using Caliburn.Micro;
using JD_XI_Editor.Models.Enums.Program.VocalEffect.Vocoder;

namespace JD_XI_Editor.Models.Patches.Program.VocalEffect
{
    internal class Vocoder : PropertyChangedBase, IPatchPart
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
        ///     Vocoder Switch
        /// </summary>
        private bool _on;

        /// <summary>
        ///     Vocoder Envelope
        /// </summary>
        private Envelope _envelope;

        //TODO: Maybe vocoder tone number?
        private int _unknownParam;

        /// <summary>
        ///     Vocoder Mic Sensitivity
        /// </summary>
        private int _microphoneSensitivity;

        /// <summary>
        ///     Vocoder Synth Level
        /// </summary>
        private int _synthLevel;

        /// <summary>
        ///     Vocoder Mic Mix Level
        /// </summary>
        private int _microphoneMixLevel;

        /// <summary>
        ///     Vocoder Microphone HPF
        /// </summary>
        private HighPassFilter _microphoneHpf;

        #endregion

    }
}