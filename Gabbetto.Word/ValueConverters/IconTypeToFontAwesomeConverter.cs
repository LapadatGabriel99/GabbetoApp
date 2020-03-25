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
    /// A converter that takes in a <see cref="MenuItemType"/> and returns the font awesome string for that icon
    /// </summary>
    public class IconTypeToFontAwesomeConverter : BaseValueConverter<IconTypeToFontAwesomeConverter>
    {
        //Converter method to convert from a boolean value to a visibility value
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((IconType)value).ToFontAweseome();
        }

        //Converter method to convert from a visibility value to a boolean one
        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
