using System;
using System.Globalization;
using System.Windows.Data;

namespace GrafGenerator.BuildNotificationTools.ControlApp.Converter
{
    public class GuidToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is Guid)
            {
                return ((Guid)value).ToString();
            }

            return "fef";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Guid.Parse(value.ToString());
        }
    }
}
