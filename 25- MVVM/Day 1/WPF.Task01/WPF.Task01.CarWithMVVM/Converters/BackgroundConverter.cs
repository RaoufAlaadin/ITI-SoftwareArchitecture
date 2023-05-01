using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WPF.Task01.CarWithMVVM.Converters
{
    internal class BackgroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string colorString = "LightGray"; // default color if no match found

            if (value is string manufacturer)
            {
                switch (manufacturer)
                {
                    case "Honda":
                        colorString = "#E4002B"; // red
                        break;
                    case "Toyota":
                        colorString = "#FFD600"; // yellow
                        break;
                    case "Tesla":
                        colorString = "#C6C6C6"; // gray
                        break;
                    case "Ford":
                        colorString = "#0072C6"; // blue
                        break;
                    case "Dodge":
                        colorString = "#FF5733"; // orange
                        break;
                    default:
                        colorString = "LightGray";
                        break;
                }
            }

            return colorString;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
