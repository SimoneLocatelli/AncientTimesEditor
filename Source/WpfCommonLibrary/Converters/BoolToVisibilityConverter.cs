using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace WpfCommonLibrary.Converters
{
    public class BoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return GetVisibility(value as bool?);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return GetBoolean(value as Visibility?);
        }

        private static bool GetBoolean(Visibility? value)
        {
            return value.GetValueOrDefault() == Visibility.Visible;
        }

        private static Visibility GetVisibility(bool? value)
        {
            return (value.GetValueOrDefault()) ? Visibility.Visible : Visibility.Collapsed;
        }
    }
}