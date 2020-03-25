using Fasseto.Word.Core;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fasseto.Word
{
    /// <summary>
    /// A converter that takes in a <see cref="MenuItemType"/> and returns a <see cref="System.Windows.Visibility"/>
    /// </summary>
    public class MenuItemTypeVisibilityConverter : BaseValueConverter<MenuItemTypeVisibilityConverter>
    {
        //Converter method to convert from a boolean value to a visibility value
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //If we have no parameter return invisible
            if (parameter == null)
                return System.Windows.Visibility.Collapsed;

            // Try and convert parameter string to enum
            if (!Enum.TryParse(parameter as string, out MenuItemType type))
                return System.Windows.Visibility.Collapsed;

            //Return visible if the param matches the type
            return (MenuItemType)value == type ? System.Windows.Visibility.Visible : System.Windows.Visibility.Collapsed;
        }

        //Converter method to convert from a visibility value to a boolean one
        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
