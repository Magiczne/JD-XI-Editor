using System;
using Caliburn.Micro;
using JD_XI_Editor.Models.Enums.DrumKit;

// ReSharper disable InvertIf

namespace JD_XI_Editor.Models.Patches.DrumKit.Partial
{
    internal class Envelope : PropertyChangedBase
    {
        #region Fields

        /// <summary>
        ///     Depth
        /// </summary>
        private int _depth;

        /// <summary>
        ///     Velocity curve
        /// </summary>
        private VelocityCurve _velocityCurve;

        /// <summary>
        ///     Velocity sensitivity
        /// </summary>
        private int _velocitySensitivity;

        /// <summary>
        ///     Time1 velocity sensitivity
        /// </summary>
        private int _time1VelocitySensitivity;

        /// <summary>
        ///     Time4 velocity sensitivity
        /// </summary>
        private int _time4VelocitySensitivity;

        /// <summary>
        ///     Time 1
        /// </summary>
        private int _time1;

        /// <summary>
        ///     Time 2
        /// </summary>
        private int _time2;

        /// <summary>
        ///     Time 3
        /// </summary>
        private int _time3;

        /// <summary>
        ///     Time 4
        /// </summary>
        private int _time4;

        /// <summary>
        ///     Level 0
        /// </summary>
        private int _level0;

        /// <summary>
        ///     Level 1
        /// </summary>
        private int _level1;

        /// <summary>
        ///     Level 2
        /// </summary>
        private int _level2;

        /// <summary>
        ///     Level 3
        /// </summary>
        private int _level3;

        /// <summary>
        ///     Level 4
        /// </summary>
        private int _level4;

        #endregion

        #region Properties

        /// <summary>
        ///     Depth
        /// </summary>
        public int Depth
        {
            get => _depth;
            set
            {
                if (value != _depth)
                {
                    _depth = value;
                    NotifyOfPropertyChange(nameof(Depth));
                }
            }
        }

        /// <summary>
        ///     Velocity curve
        /// </summary>
        public VelocityCurve VelocityCurve
        {
            get => _velocityCurve;
            set
            {
                if (value != _velocityCurve)
                {
                    _velocityCurve = value;
                    NotifyOfPropertyChange(nameof(VelocityCurve));
                }
            }
        }

        /// <summary>
        ///     Velocity sensitivity
        /// </summary>
        public int VelocitySensitivity
        {
            get => _velocitySensitivity;
            set
            {
                if (value != _velocitySensitivity)
                {
                    _velocitySensitivity = value;
                    NotifyOfPropertyChange(nameof(VelocitySensitivity));
                }
            }
        }

        /// <summary>
        ///     Time1 velocity sensitivity
        /// </summary>
        public int Time1VelocitySensitivity
        {
            get => _time1VelocitySensitivity;
            set
            {
                if (value != _time1VelocitySensitivity)
                {
                    _time1VelocitySensitivity = value;
                    NotifyOfPropertyChange(nameof(Time1VelocitySensitivity));
                }
            }
        }

        /// <summary>
        ///     Time4 velocity sensitivity
        /// </summary>
        public int Time4VelocitySensitivity
        {
            get => _time4VelocitySensitivity;
            set
            {
                if (value != _time4VelocitySensitivity)
                {
                    _time4VelocitySensitivity = value;
                    NotifyOfPropertyChange(nameof(Time4VelocitySensitivity));
                }
            }
        }

        /// <summary>
        ///     Time 1
        /// </summary>
        public int Time1
        {
            get => _time1;
            set
            {
                if (value != _time1)
                {
                    _time1 = value;
                    NotifyOfPropertyChange(nameof(Time1));
                }
            }
        }

        /// <summary>
        ///     Time 2
        /// </summary>
        public int Time2
        {
            get => _time2;
            set
            {
                if (value != _time2)
                {
                    _time2 = value;
                    NotifyOfPropertyChange(nameof(Time2));
                }
            }
        }

        /// <summary>
        ///     Time 3
        /// </summary>
        public int Time3
        {
            get => _time3;
            set
            {
                if (value != _time3)
                {
                    _time3 = value;
                    NotifyOfPropertyChange(nameof(Time3));
                }
            }
        }

        /// <summary>
        ///     Time 4
        /// </summary>
        public int Time4
        {
            get => _time4;
            set
            {
                if (value != _time4)
                {
                    _time4 = value;
                    NotifyOfPropertyChange(nameof(Time4));
                }
            }
        }

        /// <summary>
        ///     Level 0
        /// </summary>
        public int Level0
        {
            get => _level0;
            set
            {
                if (value != _level0)
                {
                    _level0 = value;
                    NotifyOfPropertyChange(nameof(Level0));
                }
            }
        }

        /// <summary>
        ///     Level 1
        /// </summary>
        public int Level1
        {
            get => _level1;
            set
            {
                if (value != _level1)
                {
                    _level1 = value;
                    NotifyOfPropertyChange(nameof(Level1));
                }
            }
        }

        /// <summary>
        ///     Level 2
        /// </summary>
        public int Level2
        {
            get => _level2;
            set
            {
                if (value != _level2)
                {
                    _level2 = value;
                    NotifyOfPropertyChange(nameof(Level2));
                }
            }
        }

        /// <summary>
        ///     Level 3
        /// </summary>
        public int Level3
        {
            get => _level3;
            set
            {
                if (value != _level3)
                {
                    _level3 = value;
                    NotifyOfPropertyChange(nameof(Level3));
                }
            }
        }

        /// <summary>
        ///     Level 4
        /// </summary>
        public int Level4
        {
            get => _level4;
            set
            {
                if (value != _level4)
                {
                    _level4 = value;
                    NotifyOfPropertyChange(nameof(Level4));
                }
            }
        }

        #endregion
    }
}