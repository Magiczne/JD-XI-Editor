using System;
using Caliburn.Micro;
using JD_XI_Editor.Models.Enums.DrumKit;
using PropertyChanged;

namespace JD_XI_Editor.Models.Patches.DrumKit.Partial
{
    internal class Tva : PropertyChangedBase, IPatchPart
    {
        /// <inheritdoc />
        public Tva()
        {
            Envelope = new Envelope();
            Reset();

            Envelope.PropertyChanged += (sender, args) => NotifyOfPropertyChange(nameof(Envelope));
        }

        /// <summary>
        ///     TVA Envelope
        /// </summary>
        [DoNotNotify]
        public Envelope Envelope { get; }


        /// TODO: Set
        /// <inheritdoc />
        public int DumpLength { get; }


        /// <inheritdoc />
        public void Reset()
        {
            Envelope.VelocityCurve = VelocityCurve.One;
            Envelope.VelocitySensitivity = 32;

            Envelope.Time1VelocitySensitivity = 0;
            Envelope.Time4VelocitySensitivity = 0;

            Envelope.Time1 = 0;
            Envelope.Time2 = 10;
            Envelope.Time3 = 10;
            Envelope.Time4 = 10;

            Envelope.Level1 = 127;
            Envelope.Level2 = 127;
            Envelope.Level3 = 127;
        }

        /// <inheritdoc />
        public void CopyFrom(IPatchPart part)
        {
            if (part is Tva tva)
            {
                Envelope.CopyFrom(tva.Envelope);
            }
            else
            {
                throw new NotSupportedException("Copying from that type is not supported");
            }
        }

        /// <inheritdoc />
        public void CopyFrom(byte[] data)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public byte[] GetBytes()
        {
            return new[]
            {
                (byte) Envelope.VelocityCurve,
                (byte) (Envelope.VelocitySensitivity + 64),
                (byte) (Envelope.Time1VelocitySensitivity + 64),
                (byte) (Envelope.Time4VelocitySensitivity + 64),

                (byte) Envelope.Time1,
                (byte) Envelope.Time2,
                (byte) Envelope.Time3,
                (byte) Envelope.Time4,

                (byte) Envelope.Level1,
                (byte) Envelope.Level2,
                (byte) Envelope.Level3
            };
        }
    }
}