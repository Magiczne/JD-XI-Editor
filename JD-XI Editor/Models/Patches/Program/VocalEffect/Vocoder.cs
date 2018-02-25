using Caliburn.Micro;
using JD_XI_Editor.Models.Enums.Program.VocalEffect.Vocoder;
using JD_XI_Editor.Utils;

// ReSharper disable InvertIf

namespace JD_XI_Editor.Models.Patches.Program.VocalEffect
{
    internal class Vocoder : PropertyChangedBase, IPatchPart
    {
        /// <inheritdoc />
        /// <summary>
        ///     Creates new instance of Vocoder
        /// </summary>
        public Vocoder()
        {
            Reset();
        }

        /// <inheritdoc />
        public void Reset()
        {
            On = false;
            Envelope = Envelope.Sharp;
            UnknowParameter = 0;    //TODO: WHAT
            MicrophoneSensitivity = 40;
            SynthLevel = 0;
            MicrophoneMixLevel = 2;
            MicrophoneHpf = HighPassFilter.Bypass;
        }

        /// <inheritdoc />
        public byte[] GetBytes()
        {
            return new byte[]
            {
                ByteUtils.BooleanToByte(On),
                (byte) Envelope,
                (byte) UnknowParameter,
                (byte) MicrophoneSensitivity,
                (byte) SynthLevel,
                (byte) MicrophoneMixLevel,
                (byte) MicrophoneHpf,
                0x00 // Reserve
            };
        }

        #region Properties

        /// <summary>
        ///     Vocoder Switch
        /// </summary>
        public bool On { get; set; }

        /// <summary>
        ///     Vocoder Envelope
        /// </summary>
        public Envelope Envelope { get; set; }

        /// <summary>
        ///     Unknow Parameter
        /// </summary>
        public int UnknowParameter { get; set; }

        /// <summary>
        ///     Vocoder Mic Sensitivity
        /// </summary>
        public int MicrophoneSensitivity { get; set; }

        /// <summary>
        ///     Vocoder Synth Level
        /// </summary>
        public int SynthLevel { get; set; }

        /// <summary>
        ///     Vocoder Mic Mix Level
        /// </summary>
        public int MicrophoneMixLevel { get; set; }

        /// <summary>
        ///     Vocoder Microphone HPF
        /// </summary>
        public HighPassFilter MicrophoneHpf { get; set; }

        #endregion
    }
}