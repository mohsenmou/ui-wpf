using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace Mohsenmou.UI.WPF.Converters
{
    public class BadgedConverter : MarkupExtension, IValueConverter
    {
        private BadgedConverter converter;
        public BadgedConverter()
        {

        }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return converter ?? (converter = new BadgedConverter());
        }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var margin = System.Convert.ToInt32(value);
            var x = -1*(margin+5);
            return x;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
