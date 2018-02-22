using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace JD_XI_Editor.Utils.Converters
{
    [ValueConversion(typeof(bool), typeof(bool))]
    internal class InverseBooleanConverter : MarkupExtension, IValueConverter
    {
        /// <summary>
        ///     Convert
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (targetType != typeof(bool))
                throw new InvalidOperationException("Target type must be a boolean");

            if (value == null)
                throw new ArgumentNullException(nameof(value));

            return !(bool) value;
        }

        /// <summary>
        ///     Convert back
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (targetType != typeof(bool))
                throw new InvalidOperationException("Target type must be a boolean");

            if (value == null)
                throw new ArgumentNullException(nameof(value));

            return !(bool) value;
        }

        /// <summary>
        ///     Returns an object that is provided as the value of the target property for this markup extension.
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <returns>The object value to set on the property where the extension is applied.</returns>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}