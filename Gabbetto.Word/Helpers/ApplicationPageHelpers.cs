using Fasseto.Word.Core;
using System;
using System.Diagnostics;

namespace Fasseto.Word
{
    ///<sumary>
    ///Converts the <see cref="ApplicationPage"/> to a an actual view/page
    ///</sumary>
    public static class ApplicationPageHelpers
    {
        /// <summary>
        /// Converts a application page to the respective base page
        /// </summary>
        /// <param name="applicationPage">The respective application page</param>
        /// <param name="viewModel">The specific view model we want to pass in for the base page</param>
        /// <returns></returns>
        public static BasePage ToBasePage(this ApplicationPage applicationPage, object viewModel = null)
        {
            switch (applicationPage)
            {
                case ApplicationPage.Login:
                    return new LoginPage(viewModel as LoginViewModel);

                case ApplicationPage.Chat:
                    return new ChatPage(viewModel as ChatMessageListViewModel);

                case ApplicationPage.Register:
                    return new RegisterPage(viewModel as RegisterViewModel);

                default:
                    Debugger.Break();
                    return null;
            }
        }

        /// <summary>
        /// Converts a base page to the respective application page
        /// </summary>
        /// <param name="basePage">The respective base page</param>
        /// <returns></returns>
        public static ApplicationPage ToApplicationPage(this BasePage basePage)
        {
            if (basePage is LoginPage)
            {
                return ApplicationPage.Login;
            }

            if (basePage is RegisterPage)
            {
                return ApplicationPage.Register;
            }

            if (basePage is ChatPage)
            {
                return ApplicationPage.Chat;
            }

            Debugger.Break();
            return default(ApplicationPage);
        }
    }
}
