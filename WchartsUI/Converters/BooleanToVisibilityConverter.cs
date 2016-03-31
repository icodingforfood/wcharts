using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace WchartsUI.Converters
{
    [ValueConversion(typeof(bool), typeof(Visibility))]
    public class BooleanToVisibilityConverter : IValueConverter
    {
        // Decide True Changing To Visibility or Collapsed
        public bool IsInverse { get; set; }

        // Decide False Changing To Collapsed or Hidden
        public bool IsHidden { get; set; }
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (!(value is bool))
                return DependencyProperty.UnsetValue;
            bool valueBool = (bool)value;
            if ((valueBool && IsInverse && !IsHidden) || (!valueBool && !IsInverse && !IsHidden))
            {
                return Visibility.Collapsed;
            }

            if ((valueBool && IsInverse && IsHidden) || (!valueBool && !IsInverse && IsHidden))
            {
                return Visibility.Hidden;
            }

            return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
