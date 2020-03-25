using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fasseto.Word
{
    public class BooleanToVisibilityConverter : BaseValueConverter<BooleanToVisibilityConverter>
    {
        //Converter method to convert from a boolean value to a visibility value
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter == null)
                //If the value is true then we change the visibility to hidden, else it stays visible
                return (bool)value ? System.Windows.Visibility.Hidden : System.Windows.Visibility.Visible;
            else
                return (bool)value ? System.Windows.Visibility.Visible : System.Windows.Visibility.Hidden;
        }

        //Converter method to convert from a visibility value to a boolean one
        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
