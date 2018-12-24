using Caliburn.Micro;
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