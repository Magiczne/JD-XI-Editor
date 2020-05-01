using System;
using Caliburn.Micro;
using JD_XI_Editor.Exceptions;
using JD_XI_Editor.Models.Enums.DrumKit;

namespace JD_XI_Editor.Models.Patches.DrumKit.Partial
{
    internal class Envelope : PropertyChangedBase, IPatchPart
    {
        #region Methods

        /// <inheritdoc />
        public void Reset()
        {
            Depth = 0;
            VelocityCurve = VelocityCurve.One;
            VelocitySensitivity = 0;
            Time1VelocitySensitivity = 0;
            Time4VelocitySensitivity = 0;

            Time1 = 0;
            Time2 = 0;
            Time3 = 0;
            Time4 = 0;

            Level0 = 0;
            Level1 = 0;
            Level2 = 0;
            Level3 = 0;
            Level4 = 0;
        }

        /// <inheritdoc />
        public void CopyFrom(IPatchPart part)
        {
            if (part is Envelope env)
            {
                Depth = env.Depth;
                VelocityCurve = env.VelocityCurve;
                VelocitySensitivity = env.VelocitySensitivity;
                Time1VelocitySensitivity = env.Time1VelocitySensitivity;
                Time4VelocitySensitivity = env.Time4VelocitySensitivity;

                Time1 = env.Time1;
                Time2 = env.Time2;
                Time3 = env.Time3;
                Time4 = env.Time4;

                Level0 = env.Level0;
                Level1 = env.Level1;
                Level2 = env.Level2;
                Level3 = env.Level3;
                Level4 = env.Level4;
            }
            else
            {
                throw new NotSupportedException("Copying from that type is not supported");
            }
        }

        /// <inheritdoc />
        public void CopyFrom(byte[] data)
        {
            throw new NotSupportedException("Copying from byte array is not supported");
        }

        /// <inheritdoc />
        public byte[] GetBytes()
        {
            throw new PatchNotConvertibleIntoBytes();
        }

        #endregion

        #region Properties

        /// <inheritdoc />
        public int DumpLength { get; } = 0;

        /// <summary>
        ///     Depth
        /// </summary>
        public int Depth { get; set; }

        /// <summary>
        ///     Velocity curve
        /// </summary>
        public VelocityCurve VelocityCurve { get; set; }

        /// <summary>
        ///     Velocity sensitivity
        /// </summary>
        public int VelocitySensitivity { get; set; }

        /// <summary>
        ///     Time1 velocity sensitivity
        /// </summary>
        public int Time1VelocitySensitivity { get; set; }

        /// <summary>
        ///     Time4 velocity sensitivity
        /// </summary>
        public int Time4VelocitySensitivity { get; set; }

        /// <summary>
        ///     Time 1
        /// </summary>
        public int Time1 { get; set; }

        /// <summary>
        ///     Time 2
        /// </summary>
        public int Time2 { get; set; }

        /// <summary>
        ///     Time 3
        /// </summary>
        public int Time3 { get; set; }

        /// <summary>
        ///     Time 4
        /// </summary>
        public int Time4 { get; set; }

        /// <summary>
        ///     Level 0
        /// </summary>
        public int Level0 { get; set; }

        /// <summary>
        ///     Level 1
        /// </summary>
        public int Level1 { get; set; }

        /// <summary>
        ///     Level 2
        /// </summary>
        public int Level2 { get; set; }

        /// <summary>
        ///     Level 3
        /// </summary>
        public int Level3 { get; set; }

        /// <summary>
        ///     Level 4
        /// </summary>
        public int Level4 { get; set; }

        #endregion
    }
}