using Caliburn.Micro;
using JD_XI_Editor.Models.Enums.Analog;

namespace JD_XI_Editor.Models.Patches.Analog
{
    internal class Oscillator : PropertyChangedBase, IPatchPart
    {
        /// <inheritdoc />
        /// <summary>
        ///     Creates new instance of Oscillator
        /// </summary>
        public Oscillator()
        {
            Reset();
        }

        /// <inheritdoc />
        public void Reset()
        {
            Shape = OscillatorShape.Saw;
            PulseWidth = 0;
            PulseWidthModDepth = 0;
            SubOsc = SubOscillatorStatus.Off;
            Pitch = 0;
            Detune = 0;
            Attack = 0;
            Decay = 0;
            EnvelopeDepth = 0;
            EnvelopeVelocitySensitivity = 0;
        }

        /// <inheritdoc />
        public byte[] GetBytes()
        {
            return new[]
            {
                (byte) Shape,
                (byte) (Pitch + 64),
                (byte) (Detune + 64),
                (byte) PulseWidth,
                (byte) PulseWidthModDepth,
                (byte) (EnvelopeVelocitySensitivity + 64),
                (byte) Attack,
                (byte) Decay,
                (byte) (EnvelopeDepth + 64),
                (byte) SubOsc
            };
        }

        #region Properties

        /// <summary>
        ///     Shape
        /// </summary>
        public OscillatorShape Shape { get; set; }

        /// <summary>
        ///     Pulse width
        /// </summary>
        public int PulseWidth { get; set; }

        /// <summary>
        ///     Pulse width modulation depth
        /// </summary>
        public int PulseWidthModDepth { get; set; }

        /// <summary>
        ///     Sub oscillator
        /// </summary>
        public SubOscillatorStatus SubOsc { get; set; }

        /// <summary>
        ///     Pitch
        /// </summary>
        public int Pitch { get; set; }

        /// <summary>
        ///     Detune
        /// </summary>
        public int Detune { get; set; }

        /// <summary>
        ///     Attack
        /// </summary>
        public int Attack { get; set; }

        /// <summary>
        ///     Decay
        /// </summary>
        public int Decay { get; set; }

        /// <summary>
        ///     Envelope depth
        /// </summary>
        public int EnvelopeDepth { get; set; }

        /// <summary>
        ///     Envelope velocity sensitivity
        /// </summary>
        public int EnvelopeVelocitySensitivity { get; set; }

        #endregion
    }
}