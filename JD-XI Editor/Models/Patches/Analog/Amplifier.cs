using System;
using Caliburn.Micro;
using JD_XI_Editor.Exceptions;
using PropertyChanged;

namespace JD_XI_Editor.Models.Patches.Analog
{
    internal class Amplifier : PropertyChangedBase, IPatchPart
    {
        /// <inheritdoc />
        /// <summary>
        ///     Creates new instance of Amplifier
        /// </summary>
        public Amplifier()
        {
            Envelope = new Adsr(0, 0, 127, 0);
            Reset();

            Envelope.PropertyChanged += (sender, args) => NotifyOfPropertyChange(nameof(Envelope));
        }

        /// <inheritdoc />
        public void Reset()
        {
            Level = 127;
            LevelKeyfollow = 0;
            LevelVelSensitivity = 0;
            Envelope.Set(0, 0, 127, 0);
        }

        /// <inheritdoc />
        public void CopyFrom(IPatchPart part)
        {
            if (part is Amplifier amplifier)
            {
                Level = amplifier.Level;
                LevelKeyfollow = amplifier.LevelKeyfollow;
                LevelVelSensitivity = amplifier.LevelVelSensitivity;
                Envelope.CopyFrom(amplifier.Envelope);
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

            Level = data[0];
            LevelKeyfollow = (data[1] - 64) * 10;
            LevelVelSensitivity = data[2] - 64;
            Envelope.Attack = data[3];
            Envelope.Decay = data[4];
            Envelope.Sustain = data[5];
            Envelope.Release = data[6];
        }

        /// <inheritdoc />
        public byte[] GetBytes()
        {
            return new[]
            {
                (byte) Level,
                (byte) (LevelKeyfollow / 10 + 64),
                (byte) (LevelVelSensitivity + 64),
                (byte) Envelope.Attack,
                (byte) Envelope.Decay,
                (byte) Envelope.Sustain,
                (byte) Envelope.Release
            };
        }

        #region Properties

        /// <inheritdoc />
        public int DumpLength { get; } = 7;

        /// <summary>
        ///     Level
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        ///     Level keyfollow
        /// </summary>
        public int LevelKeyfollow { get; set; }

        /// <summary>
        ///     Level velocity sensitivity
        /// </summary>
        public int LevelVelSensitivity { get; set; }

        /// <summary>
        ///     Envelope
        /// </summary>
        [DoNotNotify]
        public Adsr Envelope { get; }

        #endregion
    }
}