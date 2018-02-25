using System.Collections.Generic;
using Caliburn.Micro;
using JD_XI_Editor.Models.Patches.DrumKit.Partial.Wmt;
using PropertyChanged;

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

        #endregion

        #region Properties

        /// <summary>
        ///     Basic
        /// </summary>
        [DoNotNotify]
        public Basic Basic { get; }

        /// <summary>
        ///     Assign
        /// </summary>
        [DoNotNotify]
        public Assign Assign { get; }

        /// <summary>
        ///     Amplifier
        /// </summary>
        [DoNotNotify]
        public Amplifier Amplifier { get; }

        /// <summary>
        ///     Output
        /// </summary>
        [DoNotNotify]
        public Output Output { get; }

        /// <summary>
        ///     Expression
        /// </summary>
        [DoNotNotify]
        public Expression Expression { get; }

        /// <summary>
        ///     WMT Velocity control
        /// </summary>
        [DoNotNotify]
        public VelocityControl VelocityControl { get; }

        /// <summary>
        ///     WMT 1
        /// </summary>
        [DoNotNotify]
        public Wmt.Wmt Wmt1 { get; }

        /// <summary>
        ///     WMT 2
        /// </summary>
        [DoNotNotify]
        public Wmt.Wmt Wmt2 { get; }

        /// <summary>
        ///     WMT 3
        /// </summary>
        [DoNotNotify]
        public Wmt.Wmt Wmt3 { get; }

        /// <summary>
        ///     WMT 4
        /// </summary>
        [DoNotNotify]
        public Wmt.Wmt Wmt4 { get; }

        /// <summary>
        ///     Pitch
        /// </summary>
        [DoNotNotify]
        public Pitch Pitch { get; }

        /// <summary>
        ///     TVF
        /// </summary>
        [DoNotNotify]
        public Tvf Tvf { get; }

        /// <summary>
        ///     TVA
        /// </summary>
        [DoNotNotify]
        public Tva Tva { get; }

        /// <summary>
        ///     Other
        /// </summary>
        [DoNotNotify]
        public Other Other { get; }

        #endregion
    }
}