using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using Microsoft.Expression.Shapes;
// ReSharper disable InvertIf

namespace KnobControl
{
    /// Simple WPF/C# Knob Control 
    /// Author: n37jan (n37jan@gmail.com)
    /// License: BSD License
    [DefaultEvent("ValueChanged"), DefaultProperty("Value")]
    public partial class Knob
    {
        public event RoutedPropertyChangedEventHandler<double> ValueChanged;

        public static readonly DependencyProperty MinimumColorProperty = DependencyProperty.Register(
            "MinimumColor",
            typeof(Color),
            typeof(Knob));

        public static readonly DependencyProperty MaximumColorProperty = DependencyProperty.Register(
            "MaximumColor",
            typeof(Color),
            typeof(Knob));

        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
            "Value",
            typeof(double),
            typeof(Knob));

        #region Fields

        private const double MouseMoveThreshold = 20;

        private double _arcStartAngle = -180;
        private double _arcEndAngle = 180;
        private string _title = string.Empty;
        private string _unit = string.Empty;
        private double _minimum;
        private double _maximum = 10;
        private double _step = 1;
        private double _labelFontSize = 50;
        private FontFamily _labelFont = new FontFamily("Consolas");
        private readonly Arc _levelIndicatingArc = new Arc();

        private bool _isMouseDown;
        private Point _previousMousePosition;

        #endregion

        #region Properties

        [Description("Gets or sets a color for the knob control's minimum value."), Category("Knob Control")]
        public Color MinimumColor
        {
            get => (Color)GetValue(MinimumColorProperty);
            set
            {
                SetValue(MinimumColorProperty, value);
                Update();
            }
        }

        [Description("Gets or sets a color for the knob control's maximum value."), Category("Knob Control")]
        public Color MaximumColor
        {
            get => (Color)GetValue(MaximumColorProperty);
            set
            {
                SetValue(MaximumColorProperty, value);
                Update();
            }
        }

        [Description("Gets or sets start angle for the level indicating arc. Unit is in degree."), Category("Knob Control")]
        public double ArcStartAngle
        {
            get => _arcStartAngle;
            set
            {
                _arcStartAngle = value;
                Update();
            }
        }

        [Description("Gets or sets end angle for the level indicating arc. Unit is in degree."), Category("Knob Control")]
        public double ArcEndAngle
        {
            get => _arcEndAngle;
            set
            {
                _arcEndAngle = value;

                Update();
            }
        }

        [Description("Gets or sets title for the knob control."), Category("Knob Control")]
        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                Update();
            }
        }

        [Description("Gets or sets unit text for the knob control."), Category("Knob Control")]
        public string Unit
        {
            get => _unit;
            set
            {
                _unit = value;

                Update();
            }
        }

        [Category("Knob Control")]
        public double Value
        {
            get => (double) GetValue(ValueProperty);
            set
            {
                var oldValue = Value;
                var newValue = Math.Max(Math.Min(value, Maximum), Minimum);

                SetValue(ValueProperty, newValue);
                OnChanged(new RoutedPropertyChangedEventArgs<double>(oldValue, newValue));
                Update();
            }
        }

        //[Description("Gets or sets value for the knob control."), ]
        //public double Value
        //{
        //    get => _value;
        //    set
        //    {
        //        var oldValue = _value;
        //        _value = value;

        //        if (IsLoaded)
        //        {
        //            _value = Math.Max(Math.Min(_value, Maximum), Minimum);
        //            OnChanged(new RoutedPropertyChangedEventArgs<double>(oldValue, _value));
        //            Update();
        //        }
        //    }
        //}

        [Description("Gets or sets the minimum value for the knob control. It can not be more than the maximum."), Category("Knob Control")]
        public double Minimum
        {
            get => _minimum;
            set
            {
                _minimum = value;
                Update();
            }
        }

        [Description("Gets or sets the maximum value for the knob control. It can not be less than the maximum."), Category("Knob Control")]
        public double Maximum
        {
            get => _maximum;
            set
            {
                _maximum = value;
                Update();
            }
        }

        [Description("Gets or sets a step for the knob control."), Category("Knob Control")]
        public double Step
        {
            get => _step;
            set
            {
                _step = value;
                Update();
            }
        }

        [Description("Gets or sets a font for the knob control."), Category("Knob Control")]
        public FontFamily LabelFont
        {
            get => _labelFont;
            set
            {
                _labelFont = value;
                Update();
            }
        }

        [Description("Gets or sets a font size for the knob control."), Category("Knob Control")]
        public double LabelFontSize
        {
            get => _labelFontSize;
            set
            {
                _labelFontSize = value;
                Update();
            }
        }

        #endregion

        private void OnChanged(RoutedPropertyChangedEventArgs<double> e)
        {
            ValueChanged?.Invoke(this, e);
            Update();
        }

        public Knob()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            _levelIndicatingArc.Stretch = Stretch.None;
            _levelIndicatingArc.StartAngle = ArcStartAngle;
            _levelIndicatingArc.EndAngle = ArcEndAngle;
            _levelIndicatingArc.Stroke = Brushes.Green;
            _levelIndicatingArc.IsHitTestVisible = false;
            _levelIndicatingArc.StrokeThickness = 30;

            KnobGrid.Children.Add(_levelIndicatingArc);
        }



        private void Update()
        {
            // for Title Label
            DisplayTextBlock.Text = string.Empty;
            if (Title.Length > 0)
            {
                DisplayTextBlock.Text = Title + '\n';
            }

            DisplayTextBlock.FontFamily = LabelFont;
            DisplayTextBlock.FontSize = LabelFontSize;

            // for Value Label
            DisplayTextBlock.Text += Value;

            if (Unit.Length > 0)
            {
                DisplayTextBlock.Text += "[" + Unit + "]";
            }

            // Update Arc
            _levelIndicatingArc.StartAngle = ArcStartAngle;

            var newAngle = (ArcEndAngle - ArcStartAngle) / (Maximum - Minimum) * (Value - Minimum) + ArcStartAngle;
            _levelIndicatingArc.EndAngle = newAngle;

            var newColorAlpha = 1.0 / (Maximum - Minimum) * (Value - Minimum);
            var newColor = ColorBlend(MinimumColor, MaximumColor, newColorAlpha);
            _levelIndicatingArc.Stroke = new SolidColorBrush(newColor);
        }



        private void Ellipse_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            var d = e.Delta / 120.0;    // Mouse wheel 1 click (120 delta) = 1 step
            Value += d * Step;
        }

        private void Ellipse_MouseDown(object sender, MouseButtonEventArgs e)
        {
            _isMouseDown = true;

            var ellipse = (Ellipse) sender;

            ellipse.CaptureMouse();
            _previousMousePosition = e.GetPosition(ellipse);
        }

        private void Ellipse_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isMouseDown)
            {
                var newMousePosition = e.GetPosition((Ellipse)sender);

                var dY = _previousMousePosition.Y - newMousePosition.Y;

                if (Math.Abs(dY) > MouseMoveThreshold)
                {
                    Value += Math.Sign(dY) * Step;
                    _previousMousePosition = newMousePosition;
                }
            }
        }

        private void Ellipse_MouseUp(object sender, MouseButtonEventArgs e)
        {
            _isMouseDown = false;
            ((Ellipse) sender).ReleaseMouseCapture();
        }

        private static Color ColorBlend(Color color1, Color color2, double alpha)
        {
            var r = (byte)(color1.R * (1 - alpha) + color2.R * alpha);
            var g = (byte)(color1.G * (1 - alpha) + color2.G * alpha);
            var b = (byte)(color1.B * (1 - alpha) + color2.B * alpha);

            return Color.FromRgb(r, g, b);
        }

        private void knobUserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Update();
        }
    }
}