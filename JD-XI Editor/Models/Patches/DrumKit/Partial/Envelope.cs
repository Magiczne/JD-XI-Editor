using Caliburn.Micro;
using JD_XI_Editor.Models.Enums.DrumKit;

// ReSharper disable InvertIf

namespace JD_XI_Editor.Models.Patches.DrumKit.Partial
{
    internal class Envelope : PropertyChangedBase
    {
        #region Properties

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