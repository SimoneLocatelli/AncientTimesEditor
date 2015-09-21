using Editor.DockSystem.Dependencies;
using System;
using System.Globalization;
using System.Windows.Data;

namespace Editor.DockSystem
{
    public class ActiveDocumentConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is IDockTab)
                return value;

            return Binding.DoNothing;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is IDockTab)
                return value;

            return Binding.DoNothing;
        }
    }
}