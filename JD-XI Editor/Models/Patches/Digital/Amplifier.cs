using System;
using Caliburn.Micro;
using PropertyChanged;

namespace JD_XI_Editor.Models.Patches.Digital
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
            Level = 100;
            LevelVelSensitivity = 19;
            Envelope.Set(0, 0, 127, 0);
            Panorama = 0;
        }

        /// <inheritdoc />
        public void CopyFrom(IPatchPart part)
        {
            if (part is Amplifier amp)
            {
                Level = amp.Level;
                LevelVelSensitivity = amp.LevelVelSensitivity;
                Envelope.CopyFrom(amp.Envelope);
                Panorama = amp.Panorama;
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
                (byte) Level,
                (byte) (LevelVelSensitivity + 64),
                (byte) Envelope.Attack,
                (byte) Envelope.Decay,
                (byte) Envelope.Sustain,
                (byte) Envelope.Release,
                (byte) (Panorama + 64)
            };
        }

        #region Properties

        /// <summary>
        ///     Level
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        ///     Level velocity sensitivity
        /// </summary>
        public int LevelVelSensitivity { get; set; }

        /// <summary>
        ///     Envelope
        /// </summary>
        [DoNotNotify]
        public Adsr Envelope { get; }

        /// <summary>
        ///     Panorama
        /// </summary>
        public int Panorama { get; set; }

        #endregion
    }
}