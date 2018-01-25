using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace SeaBattleWPF.Converters
{
    public class StringToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return null;

            var color = (Color)ColorConverter.ConvertFromString((string)value);

            return new SolidColorBrush(color);

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
