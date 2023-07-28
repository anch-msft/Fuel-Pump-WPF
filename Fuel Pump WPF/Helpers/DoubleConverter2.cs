using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Fuel_Pump_WPF
{
    [ValueConversion(typeof(double), typeof(string))]
    public class DoubleConverter2 : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double num = (double)value;
            if (num >= 0)
            {
                return num.ToString("F");
            }
            else
            {
                return DependencyProperty.UnsetValue;
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string strValue = value as string;
            double resultNum;
            if (Double.TryParse(strValue, out resultNum))
            {
                return resultNum;
            }
            return DependencyProperty.UnsetValue;
        }
    }
}
