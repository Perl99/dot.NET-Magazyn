using GameStore.REST.JSONs;
using System;
using System.Globalization;
using System.Windows.Data;

namespace GameStore.WPF.Helpers
{
    [ValueConversion(typeof(object), typeof(string))]
    public class OwnerConverter : BaseConverter, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return "-";
            }

            UserJson owner = (UserJson) value;
            return owner.Name + " " + owner.Surname;
        }


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => null;
    }
}
