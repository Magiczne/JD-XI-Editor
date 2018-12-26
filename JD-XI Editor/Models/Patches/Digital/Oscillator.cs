using System;
using Caliburn.Micro;
using JD_XI_Editor.Exceptions;
using JD_XI_Editor.Models.Enums.Digital;

namespace JD_XI_Editor.Models.Patches.Digital
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
            WaveVariation = WaveVariation.A;
            Pitch = 0;
            Detune = 0;
            PulseWidth = 0;
            PulseWidthModDepth = 0;
            Attack = 0;
            Decay = 0;
            EnvelopeDepth = 0;
        }

        /// <inheritdoc />
        public void CopyFrom(IPatchPart part)
        {
            if (part is Oscillator osc)
            {
                Shape = osc.Shape;
                WaveVariation = osc.WaveVariation;
                Pitch = osc.Pitch;
                Detune = osc.Detune;
                PulseWidth = osc.PulseWidth;
                PulseWidthModDepth = osc.PulseWidthModDepth;
                Attack = osc.Attack;
                Decay = osc.Decay;
                EnvelopeDepth = osc.EnvelopeDepth;
            }
            else
            {
                throw new NotSupportedException("Copying from that type is not supported");
            }
        }

        /// <inheritdoc />
        public void CopyFrom(byte[] data)
        {
            if (data.Length != DumpLength)
            {
                throw new InvalidDumpSizeException(DumpLength, data.Length);
            }

            Shape = (OscillatorShape) data[0];
            WaveVariation = (WaveVariation) data[1];
            Pitch = data[3] - 64;
            Detune = data[4] - 64;
            PulseWidthModDepth = data[5];
            PulseWidth = data[6];
            Attack = data[7];
            Decay = data[8];
            EnvelopeDepth = data[9] - 64;
        }

        /// <inheritdoc />
        public byte[] GetBytes()
        {
            return new[]
            {
                (byte) Shape,
                (byte) WaveVariation,
                (byte) 0x00, //Reserve
                (byte) (Pitch + 64),
                (byte) (Detune + 64),
                (byte) PulseWidthModDepth,
                (byte) PulseWidth,
                (byte) Attack,
                (byte) Decay,
                (byte) (EnvelopeDepth + 64)
            };
        }

        #region Properties

        /// <inheritdoc />
        public int DumpLength { get; } = 10;

        /// <summary>
        ///     Shape
        /// </summary>
        public OscillatorShape Shape { get; set; }

        /// <summary>
        ///     Wave variation
        /// </summary>
        public WaveVariation WaveVariation { get; set; }

        /// <summary>
        ///     Pitch
        /// </summary>
        public int Pitch { get; set; }

        /// <summary>
        ///     Detune
        /// </summary>
        public int Detune { get; set; }

        /// <summary>
        ///     Pulse width
        /// </summary>
        public int PulseWidth { get; set; }

        /// <summary>
        ///     Pulse width modulation depth
        /// </summary>
        public int PulseWidthModDepth { get; set; }

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

        #endregion
    }
}