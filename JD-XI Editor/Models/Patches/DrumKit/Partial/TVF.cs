using System;
using Caliburn.Micro;
using JD_XI_Editor.Models.Enums.DrumKit;
using PropertyChanged;

namespace JD_XI_Editor.Models.Patches.DrumKit.Partial
{
    internal class Tvf : PropertyChangedBase, IPatchPart
    {
        public Tvf()
        {
            Envelope = new Envelope();
            Reset();

            Envelope.PropertyChanged += (sender, args) => NotifyOfPropertyChange(nameof(Envelope));
        }

        /// <inheritdoc />
        public void Reset()
        {
            Type = FilterType.LowPassFilter;
            Cutoff = 127;
            CutoffVelocityCurve = VelocityCurve.One;
            CutoffVelocitySensitivity = 0;
            Resonance = 0;
            ResonanceVelocitySensitivity = 0;

            Envelope.Depth = 0;
            Envelope.VelocityCurve = VelocityCurve.One;
            Envelope.VelocitySensitivity = 0;
            Envelope.Time1VelocitySensitivity = 0;
            Envelope.Time4VelocitySensitivity = 0;

            Envelope.Time1 = 0;
            Envelope.Time2 = 10;
            Envelope.Time3 = 10;
            Envelope.Time4 = 64;

            Envelope.Level0 = 0;
            Envelope.Level1 = 127;
            Envelope.Level2 = 127;
            Envelope.Level3 = 127;
            Envelope.Level4 = 0;
        }

        /// <inheritdoc />
        public void CopyFrom(IPatchPart part)
        {
            if (part is Tvf tvf)
            {
                Type = tvf.Type;
                Cutoff = tvf.Cutoff;
                CutoffVelocityCurve = tvf.CutoffVelocityCurve;
                CutoffVelocitySensitivity = tvf.CutoffVelocitySensitivity;
                Resonance = tvf.Resonance;
                ResonanceVelocitySensitivity = tvf.ResonanceVelocitySensitivity;

                Envelope.CopyFrom(tvf.Envelope);
            }
            else
            {
                throw new NotSupportedException("Copying from that type is not supported");
            }
        }

        /// <inheritdoc />
        public byte[] GetBytes()
        {
            return new[]
            {
                (byte) Type,
                (byte) Cutoff,
                (byte) CutoffVelocityCurve,
                (byte) (CutoffVelocitySensitivity + 64),
                (byte) Resonance,
                (byte) (ResonanceVelocitySensitivity + 64),

                (byte) (Envelope.Depth + 64),
                (byte) Envelope.VelocityCurve,
                (byte) (Envelope.VelocitySensitivity + 64),
                (byte) (Envelope.Time1VelocitySensitivity + 64),
                (byte) (Envelope.Time4VelocitySensitivity + 64),

                (byte) Envelope.Time1,
                (byte) Envelope.Time2,
                (byte) Envelope.Time3,
                (byte) Envelope.Time4,

                (byte) Envelope.Level0,
                (byte) Envelope.Level1,
                (byte) Envelope.Level2,
                (byte) Envelope.Level3,
                (byte) Envelope.Level4
            };
        }

        #region Properties

        /// <summary>
        ///     Type
        /// </summary>
        public FilterType Type { get; set; }

        /// <summary>
        ///     Cutoff
        /// </summary>
        public int Cutoff { get; set; }

        /// <summary>
        ///     Cutoff velocity curve
        /// </summary>
        public VelocityCurve CutoffVelocityCurve { get; set; }

        /// <summary>
        ///     Cutoff velocity sensitivity
        /// </summary>
        public int CutoffVelocitySensitivity { get; set; }

        /// <summary>
        ///     Resonance
        /// </summary>
        public int Resonance { get; set; }

        /// <summary>
        ///     Resonance velocity sensitivity
        /// </summary>
        public int ResonanceVelocitySensitivity { get; set; }

        /// <summary>
        ///     Envelope
        /// </summary>
        [DoNotNotify]
        public Envelope Envelope { get; }

        #endregion
    }
}