using System;
using System.Globalization;
using System.Windows.Data;
using GameStore.REST.JSONs;

namespace GameStore.WPF.Helpers
{
    [ValueConversion(typeof(object), typeof(string))]
    public class YesNoConverter : BaseConverter, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return "Nie";
            }

            return (bool) value ? "Tak" : "Nie";
        }


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => null;
    }
}
