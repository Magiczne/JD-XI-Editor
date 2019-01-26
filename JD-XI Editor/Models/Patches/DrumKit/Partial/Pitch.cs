using System;
using Caliburn.Micro;
using PropertyChanged;

namespace JD_XI_Editor.Models.Patches.DrumKit.Partial
{
    internal class Pitch : PropertyChangedBase, IPatchPart
    {
        /// <inheritdoc />
        public Pitch()
        {
            Envelope = new Envelope();
            Reset();

            Envelope.PropertyChanged += (sender, args) => NotifyOfPropertyChange(nameof(Envelope));
        }

        #region Properties

        /// TODO: Set
        /// <inheritdoc />
        public int DumpLength { get; }

        /// <summary>
        /// </summary>
        [DoNotNotify]
        public Envelope Envelope { get; }

        #endregion

        /// <inheritdoc />
        public void Reset()
        {
            Envelope.Depth = 0;
            Envelope.VelocitySensitivity = 0;
            Envelope.Time1VelocitySensitivity = 0;
            Envelope.Time4VelocitySensitivity = 0;

            Envelope.Time1 = 0;
            Envelope.Time2 = 40;
            Envelope.Time3 = 80;
            Envelope.Time4 = 40;

            Envelope.Level0 = 63;
            Envelope.Level1 = 63;
            Envelope.Level2 = 63;
            Envelope.Level3 = 0;
            Envelope.Level4 = 0;
        }

        /// <inheritdoc />
        public void CopyFrom(IPatchPart part)
        {
            if (part is Pitch pitch)
            {
                Envelope.CopyFrom(pitch.Envelope);
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
                (byte) (Envelope.Depth + 64),
                (byte) (Envelope.VelocitySensitivity + 64),
                (byte) (Envelope.Time1VelocitySensitivity + 64),
                (byte) (Envelope.Time4VelocitySensitivity + 64),

                (byte) Envelope.Time1,
                (byte) Envelope.Time2,
                (byte) Envelope.Time3,
                (byte) Envelope.Time4,

                (byte) (Envelope.Level0 + 64),
                (byte) (Envelope.Level1 + 64),
                (byte) (Envelope.Level2 + 64),
                (byte) (Envelope.Level3 + 64),
                (byte) (Envelope.Level4 + 64)
            };
        }
    }
}