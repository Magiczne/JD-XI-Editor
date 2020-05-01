using System;
using Caliburn.Micro;
using JD_XI_Editor.Exceptions;
using JD_XI_Editor.Models.Enums.DrumKit;
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
            if (data.Length != DumpLength)
            {
                throw new InvalidDumpSizeException(DumpLength, data.Length);
            }

            Envelope.Depth = data[0] - 64;
            Envelope.VelocitySensitivity = data[1] - 64;
            Envelope.Time1VelocitySensitivity = data[2] - 64;
            Envelope.Time4VelocitySensitivity = data[3] - 64;

            Envelope.Time1 = data[4];
            Envelope.Time2 = data[5];
            Envelope.Time3 = data[6];
            Envelope.Time4 = data[7];

            Envelope.Level0 = data[8] - 64;
            Envelope.Level1 = data[9] - 64;
            Envelope.Level2 = data[10] - 64;
            Envelope.Level3 = data[11] - 64;
            Envelope.Level4 = data[12] - 64;
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

        #region Properties

        /// <inheritdoc />
        public int DumpLength { get; } = 13;

        /// <summary>
        /// </summary>
        [DoNotNotify]
        public Envelope Envelope { get; }

        #endregion 
    }
}