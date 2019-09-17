using System;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace Mohsenmou.UI.WPF.Converters
{
    internal class MaximizeVisibilityConverter : MarkupExtension, IValueConverter
    {
        private static MaximizeVisibilityConverter converter;

        public MaximizeVisibilityConverter()
        {
        }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (ResizeMode)value == ResizeMode.NoResize || (ResizeMode)value == ResizeMode.CanMinimize ? Visibility.Collapsed : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return converter ?? (converter = new MaximizeVisibilityConverter());
        }
    }

    internal class MinimizeVisibilityConverter : MarkupExtension, IValueConverter
    {
        private static MinimizeVisibilityConverter converter;

        public MinimizeVisibilityConverter()
        {
        }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (ResizeMode)value == ResizeMode.NoResize ? Visibility.Collapsed : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return converter ?? (converter = new MinimizeVisibilityConverter());
        }
    }
}