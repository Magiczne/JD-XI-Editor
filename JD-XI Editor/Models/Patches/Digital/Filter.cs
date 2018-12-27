using System;
using Caliburn.Micro;
using JD_XI_Editor.Exceptions;
using JD_XI_Editor.Models.Enums.Digital;
using PropertyChanged;

namespace JD_XI_Editor.Models.Patches.Digital
{
    internal class Filter : PropertyChangedBase, IPatchPart
    {
        /// <inheritdoc />
        /// <summary>
        ///     Creates new instance of Filter
        /// </summary>
        public Filter()
        {
            Envelope = new Adsr(0, 36, 0, 0);
            Reset();

            Envelope.PropertyChanged += (sender, args) => NotifyOfPropertyChange(nameof(Envelope));
        }

        /// <inheritdoc />
        public void Reset()
        {
            Type = FilterType.LowPassFilter;
            Slope = FilterSlope.NegativeTwentyFour;
            Cutoff = 127;
            CutoffKeyfollow = 0;
            EnvelopeVelocitySensitivity = 0;
            Resonance = 0;
            Envelope.Set(0, 36, 0, 0);
            EnvelopeDepth = 0;
        }

        /// <inheritdoc />
        public void CopyFrom(IPatchPart part)
        {
            if (part is Filter filter)
            {
                Type = filter.Type;
                Slope = filter.Slope;
                Cutoff = filter.Cutoff;
                CutoffKeyfollow = filter.CutoffKeyfollow;
                EnvelopeVelocitySensitivity = filter.EnvelopeVelocitySensitivity;
                Resonance = filter.Resonance;
                Envelope.CopyFrom(filter.Envelope);
                EnvelopeDepth = filter.EnvelopeDepth;
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

            Type = (FilterType) data[0];
            Slope = (FilterSlope) data[1];
            Cutoff = data[2];
            CutoffKeyfollow = (data[3] - 64) * 10;
            EnvelopeVelocitySensitivity = data[4] - 64;
            Resonance = data[5];
            Envelope.Attack = data[6];
            Envelope.Decay = data[7];
            Envelope.Sustain = data[8];
            Envelope.Release = data[9];
            EnvelopeDepth = data[10] - 64;
        }

        /// <inheritdoc />
        public byte[] GetBytes()
        {
            return new[]
            {
                (byte) Type,
                (byte) Slope,
                (byte) Cutoff,
                (byte) (CutoffKeyfollow / 10 + 64),
                (byte) (EnvelopeVelocitySensitivity + 64),
                (byte) Resonance,
                (byte) Envelope.Attack,
                (byte) Envelope.Decay,
                (byte) Envelope.Sustain,
                (byte) Envelope.Release,
                (byte) (EnvelopeDepth + 64)
            };
        }

        #region Properties

        /// <inheritdoc />
        public int DumpLength { get; } = 11;

        /// <summary>
        ///     Filter type
        /// </summary>
        public FilterType Type { get; set; }

        /// <summary>
        ///     Filter slope
        /// </summary>
        public FilterSlope Slope { get; set; }

        /// <summary>
        ///     Cutoff
        /// </summary>
        public int Cutoff { get; set; }

        /// <summary>
        ///     Cutoff keyfollow
        /// </summary>
        public int CutoffKeyfollow { get; set; }

        /// <summary>
        ///     Envelope velocity sensitivity
        /// </summary>
        public int EnvelopeVelocitySensitivity { get; set; }

        /// <summary>
        ///     Resonance
        /// </summary>
        public int Resonance { get; set; }

        /// <summary>
        ///     Envelope
        /// </summary>
        [DoNotNotify]
        public Adsr Envelope { get; }

        /// <summary>
        ///     Envelope depth
        /// </summary>
        public int EnvelopeDepth { get; set; }

        #endregion
    }
}