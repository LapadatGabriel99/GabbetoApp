using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fasseto.Word
{
    /// <summary>
    /// A converter that takes in a data and converts it into a user friendly read time
    /// </summary>
    public class TimeToReadTimeConverter : BaseValueConverter<TimeToReadTimeConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //Get the time passed in
            var time = (DateTimeOffset)value;

            //If it is not read...
            if (time == DateTimeOffset.MinValue)
                //Show nothing
                return string.Empty;

            //If it is today...
            if (time.Date == DateTimeOffset.Now.Date)
                //Return just time(ex 11:54)
                return $"Read { time.ToLocalTime().ToString("HH:mm") }";
            else
                //Otherwise return a full date
                return $"Read { time.ToLocalTime().ToString("HH:mm, MMM yyyy") }";
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
