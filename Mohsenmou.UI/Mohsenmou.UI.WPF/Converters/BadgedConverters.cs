using System;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;

namespace Mohsenmou.UI.WPF.Converters
{
    public class BadgedLeftConverter : MarkupExtension, IValueConverter
    {
        private BadgedLeftConverter converter;
        public BadgedLeftConverter()
        {

        }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return converter ?? (converter = new BadgedLeftConverter());
        }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var controlWidth = ((Control)value).ActualWidth;
            var leftMargin = ((Control)value).Margin.Left;
            return (controlWidth + leftMargin) - 5;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
    public class BadgedTopConverter : MarkupExtension, IValueConverter
    {
        private const int ARRANGE_SIZE = 5;
        private BadgedTopConverter converter;
        public BadgedTopConverter()
        {

        }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return converter ?? (converter = new BadgedTopConverter());
        }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var topMargin = ((Control)value).Margin.Top;
            return topMargin - ARRANGE_SIZE;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}
