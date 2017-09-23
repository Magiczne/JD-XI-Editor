using System.Collections.Generic;
using System.Windows.Documents;
using Caliburn.Micro;
using JD_XI_Editor.Models.Patches.DrumKit.Partial.Wmt;

// ReSharper disable InvertIf

namespace JD_XI_Editor.Models.Patches.DrumKit.Partial
{
    internal class Partial : PropertyChangedBase, IPatchPart
    {
        /// <inheritdoc />
        public Partial()
        {
            Basic = new Basic();
            Assign = new Assign();
            Amplifier = new Amplifier();
            Output = new Output();
            Expression = new Expression();
            VelocityControl = new VelocityControl();
            Wmt1 = new Wmt.Wmt();
            Wmt2 = new Wmt.Wmt();
            Wmt3 = new Wmt.Wmt();
            Wmt4 = new Wmt.Wmt();
            Pitch = new Pitch();
            Tvf = new Tvf();
            Tva = new Tva();
            Other = new Other();

            Basic.PropertyChanged += (sender, args) => NotifyOfPropertyChange(nameof(Basic));
            Assign.PropertyChanged += (sender, args) => NotifyOfPropertyChange(nameof(Assign));
            Amplifier.PropertyChanged += (sender, args) => NotifyOfPropertyChange(nameof(Amplifier));
            Output.PropertyChanged += (sender, args) => NotifyOfPropertyChange(nameof(Output));
            Expression.PropertyChanged += (sender, args) => NotifyOfPropertyChange(nameof(Expression));
            VelocityControl.PropertyChanged += (sender, args) => NotifyOfPropertyChange(nameof(VelocityControl));
            Wmt1.PropertyChanged += (sender, args) => NotifyOfPropertyChange(nameof(Wmt1));
            Wmt2.PropertyChanged += (sender, args) => NotifyOfPropertyChange(nameof(Wmt2));
            Wmt3.PropertyChanged += (sender, args) => NotifyOfPropertyChange(nameof(Wmt3));
            Wmt4.PropertyChanged += (sender, args) => NotifyOfPropertyChange(nameof(Wmt4));
            Pitch.PropertyChanged += (sender, args) => NotifyOfPropertyChange(nameof(Pitch));
            Tvf.PropertyChanged += (sender, args) => NotifyOfPropertyChange(nameof(Tvf));
            Tva.PropertyChanged += (sender, args) => NotifyOfPropertyChange(nameof(Tva));
            Other.PropertyChanged += (sender, args) => NotifyOfPropertyChange(nameof(Other));
        }

        /// <inheritdoc />
        public void Reset()
        {
            Basic.Reset();
            Assign.Reset();
            Amplifier.Reset();
            Output.Reset();
            Expression.Reset();
            VelocityControl.Reset();
            Wmt1.Reset();
            Wmt2.Reset();
            Wmt3.Reset();
            Wmt4.Reset();
            Pitch.Reset();
            Tvf.Reset();
            Tva.Reset();
            Other.Reset();
        }

        /// <inheritdoc />
        public byte[] GetBytes()
        {
            var bytes = new List<byte>();

            bytes.AddRange(Basic.GetBytes());
            bytes.AddRange(Assign.GetBytes());
            bytes.AddRange(Amplifier.GetBytes());
            bytes.AddRange(Expression.GetBytes());
            bytes.AddRange(VelocityControl.GetBytes());
            bytes.AddRange(Wmt1.GetBytes());
            bytes.AddRange(Wmt2.GetBytes());
            bytes.AddRange(Wmt3.GetBytes());
            bytes.AddRange(Wmt4.GetBytes());
            bytes.AddRange(Pitch.GetBytes());
            bytes.AddRange(Tvf.GetBytes());
            bytes.AddRange(Tva.GetBytes());
            bytes.AddRange(Other.GetBytes());

            return bytes.ToArray();
        }

        #region Fields

        /// <summary>
        ///     Basic
        /// </summary>
        private Basic _basic;

        /// <summary>
        ///     Assign
        /// </summary>
        private Assign _assign;

        /// <summary>
        ///     Amplifier
        /// </summary>
        private Amplifier _amplifier;

        /// <summary>
        ///     Output
        /// </summary>
        private Output _output;

        /// <summary>
        ///     Expression
        /// </summary>
        private Expression _expression;

        /// <summary>
        ///     WMT Velocity control
        /// </summary>
        private VelocityControl _velocityControl;

        /// <summary>
        ///     WMT 1
        /// </summary>
        private Wmt.Wmt _wmt1;

        /// <summary>
        ///     WMT 2
        /// </summary>
        private Wmt.Wmt _wmt2;

        /// <summary>
        ///     WMT 3
        /// </summary>
        private Wmt.Wmt _wmt3;

        /// <summary>
        ///     WMT 4
        /// </summary>
        private Wmt.Wmt _wmt4;

        /// <summary>
        ///     Pitch
        /// </summary>
        private Pitch _pitch;

        /// <summary>
        ///     TVF
        /// </summary>
        private Tvf _tvf;

        /// <summary>
        ///     TVA
        /// </summary>
        private Tva _tva;

        /// <summary>
        ///     Other
        /// </summary>
        private Other _other;

        #endregion

        #region Properties

        /// <summary>
        ///     Basic
        /// </summary>
        public Basic Basic
        {
            get => _basic;
            set
            {
                if (value != _basic)
                {
                    _basic = value;
                    NotifyOfPropertyChange(nameof(Basic));
                }
            }
        }

        /// <summary>
        ///     Assign
        /// </summary>
        public Assign Assign
        {
            get => _assign;
            set
            {
                if (value != _assign)
                {
                    _assign = value;
                    NotifyOfPropertyChange(nameof(Assign));
                }
            }
        }

        /// <summary>
        ///     Amplifier
        /// </summary>
        public Amplifier Amplifier
        {
            get => _amplifier;
            set
            {
                if (value != _amplifier)
                {
                    _amplifier = value;
                    NotifyOfPropertyChange(nameof(Amplifier));
                }
            }
        }

        /// <summary>
        ///     Output
        /// </summary>
        public Output Output
        {
            get => _output;
            set
            {
                if (value != _output)
                {
                    _output = value;
                    NotifyOfPropertyChange(nameof(Output));
                }
            }
        }

        /// <summary>
        ///     Expression
        /// </summary>
        public Expression Expression
        {
            get => _expression;
            set
            {
                if (value != _expression)
                {
                    _expression = value;
                    NotifyOfPropertyChange(nameof(Expression));
                }
            }
        }

        /// <summary>
        ///     WMT Velocity control
        /// </summary>
        public VelocityControl VelocityControl
        {
            get => _velocityControl;
            set
            {
                if (value != _velocityControl)
                {
                    _velocityControl = value;
                    NotifyOfPropertyChange(nameof(VelocityControl));
                }
            }
        }

        /// <summary>
        ///     WMT 1
        /// </summary>
        public Wmt.Wmt Wmt1
        {
            get => _wmt1;
            set
            {
                if (value != _wmt1)
                {
                    _wmt1 = value;
                    NotifyOfPropertyChange(nameof(Wmt1));
                }
            }
        }

        /// <summary>
        ///     WMT 2
        /// </summary>
        public Wmt.Wmt Wmt2
        {
            get => _wmt2;
            set
            {
                if (value != _wmt2)
                {
                    _wmt2 = value;
                    NotifyOfPropertyChange(nameof(Wmt2));
                }
            }
        }

        /// <summary>
        ///     WMT 3
        /// </summary>
        public Wmt.Wmt Wmt3
        {
            get => _wmt3;
            set
            {
                if (value != _wmt3)
                {
                    _wmt3 = value;
                    NotifyOfPropertyChange(nameof(Wmt3));
                }
            }
        }

        /// <summary>
        ///     WMT 4
        /// </summary>
        public Wmt.Wmt Wmt4
        {
            get => _wmt4;
            set
            {
                if (value != _wmt4)
                {
                    _wmt4 = value;
                    NotifyOfPropertyChange(nameof(Wmt4));
                }
            }
        }

        /// <summary>
        ///     Pitch
        /// </summary>
        public Pitch Pitch
        {
            get => _pitch;
            set
            {
                if (value != _pitch)
                {
                    _pitch = value;
                    NotifyOfPropertyChange(nameof(Pitch));
                }
            }
        }

        /// <summary>
        ///     TVF
        /// </summary>
        public Tvf Tvf
        {
            get => _tvf;
            set
            {
                if (value != _tvf)
                {
                    _tvf = value;
                    NotifyOfPropertyChange(nameof(Tvf));
                }
            }
        }

        /// <summary>
        ///     TVA
        /// </summary>
        public Tva Tva
        {
            get => _tva;
            set
            {
                if (value != _tva)
                {
                    _tva = value;
                    NotifyOfPropertyChange(nameof(Tva));
                }
            }
        }

        /// <summary>
        ///     Other
        /// </summary>
        public Other Other
        {
            get => _other;
            set
            {
                if (value != _other)
                {
                    _other = value;
                    NotifyOfPropertyChange(nameof(Other));
                }
            }
        }

        #endregion
    }
}