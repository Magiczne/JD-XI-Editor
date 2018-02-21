using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using KnobControl.Annotations;

// ReSharper disable PossibleNullReferenceException
// ReSharper disable InvertIf

namespace KnobControl
{
    /// Simple WPF/C# Knob Control 
    /// Author: n37jan (n37jan@gmail.com)
    /// Modifications: Magiczne (michalkamilkleszczynski@gmail.com)
    /// License: BSD License
    [DefaultEvent("ValueChanged")]
    [DefaultProperty("Value")]
    public partial class Knob : INotifyPropertyChanged
    {
        /// <inheritdoc />
        /// <summary>
        ///     Creates new instance of the Knob
        /// </summary>
        public Knob()
        {
            InitializeComponent();
            KnobGrid.DataContext = this;

            IsEnabledChanged += (sender, args) =>
            {
                OnPropertyChanged(nameof(ArcStroke));

                Opacity = IsEnabled ? 1 : 0.5;
            };
        }

        /// <summary>
        ///     Method that is invoked on mouse wheel
        /// </summary>
        /// <param name="sender">Sedner</param>
        /// <param name="e">Event args</param>
        private void OnMouseWheel(object sender, MouseWheelEventArgs e)
        {
            var d = e.Delta / 120.0; // Mouse wheel 1 click (120 delta) = 1 step
            var toAdd = (int) d * Step;

            if (Value + toAdd > Maximum)
            {
                Value = Maximum;
                return;
            }

            if (Value == Maximum && Value + toAdd > Maximum)
                return;

            Value += toAdd;
        }

        /// <summary>
        ///     Method that is invoked on mouse down
        /// </summary>
        /// <param name="sender">Sedner</param>
        /// <param name="e">Event args</param>
        private void OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            _isMouseDown = true;

            var ellipse = (Ellipse) sender;

            ellipse.CaptureMouse();
            _previousMousePosition = e.GetPosition(ellipse);
        }

        /// <summary>
        ///     Method that is invoked on mouse move, but only if the mouse is down
        /// </summary>
        /// <param name="sender">Sedner</param>
        /// <param name="e">Event args</param>
        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (_isMouseDown)
            {
                var newMousePosition = e.GetPosition((Ellipse) sender);

                var dY = _previousMousePosition.Y - newMousePosition.Y;

                if (Math.Abs(dY) > MouseMoveThreshold)
                {
                    var toAdd = Math.Sign(dY) * Step;
                    _previousMousePosition = newMousePosition;

                    if (Value + toAdd > Maximum)
                    {
                        Value = Maximum;
                        return;
                    }

                    if (Value == Maximum && Value + toAdd > Maximum)
                        return;

                    Value += toAdd;
                }
            }
        }

        /// <summary>
        ///     Method that is invoked on mouse up
        /// </summary>
        /// <param name="sender">Sedner</param>
        /// <param name="e">Event args</param>
        private void OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            _isMouseDown = false;
            ((Ellipse) sender).ReleaseMouseCapture();
        }

        /// <summary>
        ///     Blend two colors into one
        /// </summary>
        /// <param name="color1">First color</param>
        /// <param name="color2">Second color</param>
        /// <param name="alpha">Alpha</param>
        /// <returns>Blent color</returns>
        private static Color ColorBlend(Color color1, Color color2, double alpha)
        {
            var r = (byte) (color1.R * (1 - alpha) + color2.R * alpha);
            var g = (byte) (color1.G * (1 - alpha) + color2.G * alpha);
            var b = (byte) (color1.B * (1 - alpha) + color2.B * alpha);

            return Color.FromRgb(r, g, b);
        }

        #region Fields

        private const double MouseMoveThreshold = 20;

        private bool _isMouseDown;
        private Point _previousMousePosition;

        #endregion

        #region Dependency properties

        public static readonly DependencyProperty MinimumColorProperty = DependencyProperty.Register(
            "MinimumColor", typeof(Color), typeof(Knob),
            new FrameworkPropertyMetadata(Brushes.Green.Color, OnMinimumColorPropertyChanged));

        public static readonly DependencyProperty MaximumColorProperty = DependencyProperty.Register(
            "MaximumColor", typeof(Color), typeof(Knob),
            new FrameworkPropertyMetadata(Brushes.GreenYellow.Color, OnMaximumColorPropertyChanged));

        public static readonly DependencyProperty ArcStartAngleProperty = DependencyProperty.Register(
            "ArcStartAngle", typeof(double), typeof(Knob),
            new FrameworkPropertyMetadata(-180d, OnArcStartAnglePropertyChanged));

        public static readonly DependencyProperty ArcEndAngleProperty = DependencyProperty.Register(
            "ArcEndAngle", typeof(double), typeof(Knob),
            new FrameworkPropertyMetadata(180d, OnArcEndAnglePropertyChanged));

        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(
            "Title", typeof(string), typeof(Knob),
            new FrameworkPropertyMetadata(string.Empty, OnTitlePropertyChanged));

        public static readonly DependencyProperty UnitProperty = DependencyProperty.Register(
            "Unit", typeof(string), typeof(Knob),
            new FrameworkPropertyMetadata(string.Empty, OnUnitPropertyChanged));

        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
            "Value", typeof(int), typeof(Knob),
            new FrameworkPropertyMetadata(0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnValuePropertyChanged, OnValuePropertyCoerce));

        public static readonly DependencyProperty MinimumProperty = DependencyProperty.Register(
            "Minumum", typeof(int), typeof(Knob),
            new FrameworkPropertyMetadata(0, OnMinimumPropertyChanged, OnMinimumPropertyCoerce));

        public static readonly DependencyProperty MaximumProperty = DependencyProperty.Register(
            "Maximum", typeof(int), typeof(Knob),
            new FrameworkPropertyMetadata(10, OnMaximumPropertyChanged, OnMaximumPropertyCoerce));

        public static readonly DependencyProperty StepProperty = DependencyProperty.Register(
            "Step", typeof(int), typeof(Knob),
            new FrameworkPropertyMetadata(1));

        public static readonly DependencyProperty LabelFontProperty = DependencyProperty.Register(
            "LabelFont", typeof(FontFamily), typeof(Knob),
            new FrameworkPropertyMetadata(new FontFamily("Consolas"), OnLabelFontPropertyChanged));

        public static readonly DependencyProperty LabelFontSizeProperty = DependencyProperty.Register(
            "LabelFontSize", typeof(double), typeof(Knob),
            new FrameworkPropertyMetadata(24d, OnLabelFontSizePropertyChanged));

        #endregion

        #region Properties

        /// <summary>
        ///     Color for the minimum value
        /// </summary>
        [Category("Knob")]
        public Color MinimumColor
        {
            get => (Color) GetValue(MinimumColorProperty);
            set => SetValue(MinimumColorProperty, value);
        }

        /// <summary>
        ///     Color for the maximum value
        /// </summary>
        [Category("Knob")]
        public Color MaximumColor
        {
            get => (Color) GetValue(MaximumColorProperty);
            set => SetValue(MaximumColorProperty, value);
        }

        /// <summary>
        ///     Start angle of the arc
        /// </summary>
        [Category("Knob")]
        public double ArcStartAngle
        {
            get => (double) GetValue(ArcStartAngleProperty);
            set => SetValue(ArcStartAngleProperty, value);
        }

        /// <summary>
        ///     End angle of the arc
        /// </summary>
        [Category("Knob")]
        public double ArcEndAngle
        {
            get => (double) GetValue(ArcEndAngleProperty);
            set => SetValue(ArcEndAngleProperty, value);
        }

        /// <summary>
        /// Knob title
        /// </summary>
        [Category("Knob")]
        public string Title
        {
            get => (string) GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }
        
        /// <summary>
        ///     Unit
        /// </summary>
        [Category("Knob")]
        public string Unit
        {
            get => (string) GetValue(UnitProperty);
            set => SetValue(UnitProperty, value);
        }

        /// <summary>
        ///     Knob value
        /// </summary>
        [Category("Knob")]
        public int Value
        {
            get => (int) GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }


        /// <summary>
        ///     Minimum knob value
        /// </summary>
        [Category("Knob")]
        public int Minimum
        {
            get => (int) GetValue(MinimumProperty);
            set => SetValue(MinimumProperty, value);
        }

        /// <summary>
        ///     Maximum knob value
        /// </summary>
        [Category("Knob")]
        public int Maximum
        {
            get => (int) GetValue(MaximumProperty);
            set => SetValue(MaximumProperty, value);
        }

        /// <summary>
        ///     Step of the knob
        /// </summary>
        [Category("Knob")]
        public int Step
        {
            get => (int) GetValue(StepProperty);
            set => SetValue(StepProperty, value);
        }

        /// <summary>
        ///     Font family of the label
        /// </summary>
        [Category("Knob")]
        public FontFamily LabelFont
        {
            get => (FontFamily) GetValue(LabelFontProperty);
            set => SetValue(LabelFontProperty, value);
        }

        /// <summary>
        ///     Font size of the label
        /// </summary>
        [Category("Knob")]
        public double LabelFontSize
        {
            get => (double) GetValue(LabelFontSizeProperty);
            set => SetValue(LabelFontSizeProperty, value);
        }

        /// <summary>
        ///     Calculated end angle of arc
        /// </summary>
        public double CalculatedEndAngle => (ArcEndAngle - ArcStartAngle) / (Maximum - Minimum) * (Value - Minimum) +
                                            ArcStartAngle;

        /// <summary>
        ///     Arc stroke brush
        /// </summary>
        public SolidColorBrush ArcStroke
        {
            get
            {
                if (IsEnabled)
                {
                    var newAlpha = 1.0 / (Maximum - Minimum) * (Value - Minimum);
                    var newColor = ColorBlend(MinimumColor, MaximumColor, newAlpha);
                    return new SolidColorBrush(newColor);
                }

                return Brushes.Gray;
            }
        }

        /// <summary>
        ///     Label text
        /// </summary>
        public string LabelText
        {
            get
            {
                var text = string.Empty;

                if (Title.Length > 0)
                    text = Title + '\n';

                text += Value;

                if (Unit.Length > 0)
                    text += Unit;

                return text;
            }
        }

        #endregion

        #region Property event handling and callbacks

        /// <summary>
        ///     An event that is raised when the value changes
        /// </summary>
        public event EventHandler ValueChanged;

        /// <summary>
        ///     Method that is invoked when the value changes
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event args</param>
        private static void OnValuePropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var knob = (Knob) sender;

            var oldValue = (int) e.OldValue;
            var newValue = (int) e.NewValue;

            if (oldValue != newValue)
            {
                knob.ValueChanged?.Invoke(knob, EventArgs.Empty);

                knob.OnPropertyChanged(nameof(ArcStroke));
                knob.OnPropertyChanged(nameof(CalculatedEndAngle));
                knob.OnPropertyChanged(nameof(LabelText));
            }
        }

        /// <summary>
        ///     Value property coerce callback
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="data">Value</param>
        /// <returns>Coerced value</returns>
        private static object OnValuePropertyCoerce(DependencyObject sender, object data)
        {
            var knob = (Knob) sender;
            var value = (int) data;

            if (value < knob.Minimum)
                value = knob.Minimum;

            if (value > knob.Maximum)
                value = knob.Maximum;

            return value;
        }

        /// <summary>
        ///     Method that is invoked when the MinimumColor property changes
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event args</param>
        private static void OnMinimumColorPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var knob = (Knob) sender;
            knob.OnPropertyChanged(nameof(ArcStroke));
        }

        /// <summary>
        ///     Method that is invoked when the MaximumColor property changes
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event args</param>
        private static void OnMaximumColorPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var knob = (Knob) sender;
            knob.OnPropertyChanged(nameof(ArcStroke));
        }

        /// <summary>
        ///     Method that is invoked when the ArcStartAngle property changes
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event args</param>
        private static void OnArcStartAnglePropertyChanged(DependencyObject sender,
            DependencyPropertyChangedEventArgs e)
        {
            var knob = (Knob) sender;
            knob.OnPropertyChanged(nameof(ArcStartAngle));
            knob.OnPropertyChanged(nameof(CalculatedEndAngle));
        }

        /// <summary>
        ///     Method that is invoked when the ArcEndAngle property changes
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event args</param>
        private static void OnArcEndAnglePropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var knob = (Knob) sender;
            knob.OnPropertyChanged(nameof(CalculatedEndAngle));
        }

        /// <summary>
        ///     Method that is invoked when the Title property changes
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event args</param>
        private static void OnTitlePropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var knob = (Knob) sender;
            knob.OnPropertyChanged(nameof(LabelText));
        }

        /// <summary>
        ///     Method that is invoked when the Unit property changes
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event args</param>
        private static void OnUnitPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var knob = (Knob) sender;
            knob.OnPropertyChanged(nameof(LabelText));
        }

        /// <summary>
        ///     Method that is invoked when the Minimum property changes
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event args</param>
        private static void OnMinimumPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var knob = (Knob) sender;
            knob.OnPropertyChanged(nameof(ArcStroke));
            knob.OnPropertyChanged(nameof(CalculatedEndAngle));
        }

        /// <summary>
        ///     Minimum property coerce callback
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="data">Value</param>
        /// <returns>Coerced value</returns>
        private static object OnMinimumPropertyCoerce(DependencyObject sender, object data)
        {
            var knob = (Knob) sender;
            var value = (int) data;

            if (value > knob.Maximum)
                value = knob.Maximum;

            return value;
        }

        /// <summary>
        ///     Method that is invoked when the Maximum property changes
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event args</param>
        private static void OnMaximumPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var knob = (Knob) sender;
            knob.OnPropertyChanged(nameof(ArcStroke));
            knob.OnPropertyChanged(nameof(CalculatedEndAngle));
        }

        /// <summary>
        ///     Maximum property coerce callback
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="data">Value</param>
        /// <returns>Coerced value</returns>
        private static object OnMaximumPropertyCoerce(DependencyObject sender, object data)
        {
            var knob = (Knob) sender;
            var value = (int) data;

            if (value < knob.Minimum)
                value = knob.Minimum;

            return value;
        }

        /// <summary>
        ///     Method that is invoked when the LabelFont property changes
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event args</param>
        private static void OnLabelFontPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var knob = (Knob) sender;
            knob.OnPropertyChanged(nameof(LabelFont));
        }

        /// <summary>
        ///     Method that is invoked when the LabelFontSize property changes
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event args</param>
        private static void OnLabelFontSizePropertyChanged(DependencyObject sender,
            DependencyPropertyChangedEventArgs e)
        {
            var knob = (Knob) sender;
            knob.OnPropertyChanged(nameof(LabelFontSize));
        }

        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}