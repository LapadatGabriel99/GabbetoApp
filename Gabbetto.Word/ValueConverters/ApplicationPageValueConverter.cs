using Fasseto.Word.Core;
using Fasseto.Word;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fasseto.Word
{
    /// <summary>
    /// Converts hte <see cref="ApplicationPage"/> to a an actual view/page
    /// </summary>
    public class ApplicationPageValueConverter : BaseValueConverter<ApplicationPageValueConverter>
    {
        public override object Convert(object value, Type targetType = null, object parameter = null, CultureInfo culture = null)
        {
            //Find the  appropiate page
            switch ((ApplicationPage)value)
            {
                case ApplicationPage.Login:
                    return new LoginPage(parameter as LoginViewModel);

                case ApplicationPage.Chat:
                    return new ChatPage(parameter as ChatMessageListViewModel);

                case ApplicationPage.Register:
                    return new RegisterPage(parameter as RegisterViewModel);

                default:
                    Debugger.Break();
                    return null;
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
