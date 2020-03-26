using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Fasseto.Word.Core
{
    /// <summary>
    /// The view model for the login page
    /// </summary>
    public class LoginViewModel : BaseViewModel
    {
        #region Private Members       

        #endregion

        #region Public Properties

        /// <summary>
        /// The email of the user
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// A flag that is indicating whether we are trying to log in or not
        /// </summary>
        public bool LoginIsRunning { get; set; } = false;

        #endregion

        #region Commands

        /// <summary>
        /// The command to login
        /// </summary>
        public ICommand LoginCommand { get; set; }
        
        /// <summary>
        /// The command to go to the register page
        /// </summary>
        public ICommand RegisterCommand { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        public LoginViewModel()
        {
            //Create commands
            LoginCommand = new RelayParameterizedCommand(async (parameter) => await LoginAsync(parameter));
            RegisterCommand = new RelayCommand(async () => await RegisterAsync());
        }

        #endregion

        #region Private Helpers



        #endregion

        #region Command Helpers

        /// <summary>
        /// Attempts to log in the user
        /// </summary>
        /// <param name="parameter">Thee <see cref="SecureString"/> passed in from the view for the ussers password</param>
        /// <returns></returns>
        public async Task LoginAsync(object parameter)
        {
            await RunCommandAsync(() => this.LoginIsRunning, async () =>
            {
                //TODO: Fake a login...
                await Task.Delay(2000);

                //Ok successfully logged in... now get users data
                //TODO: ask server for users info

                //TODO: Remove this with real info pulled from our database in futere
                IoC.SettingsViewModel.Name = new TextEntryViewModel { Label = "Name", OriginalText = $"Gabi Lapadat { DateTime.Now.ToLocalTime() }" };
                IoC.SettingsViewModel.UserName = new TextEntryViewModel { Label = "UserName", OriginalText = "gabi" };
                IoC.SettingsViewModel.Password = new PasswordEntryViewModel { Label = "Password", FakePassword = "*******" };
                IoC.SettingsViewModel.Email = new TextEntryViewModel { Label = "Email", OriginalText = "blabla@gmail.com" };

                IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.Chat);

                //var email = this.Email;

                ////Note: Need to move this unsecure password
                //var password = (parameter as IHavePassword).SecurePassword.Unsecure();
            });
        }

        /// <summary>
        /// Takes the user to the register page
        /// </summary>
        /// <returns></returns>
        public async Task RegisterAsync()
        {
            // TODO: Go to register?           

            IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.Register);

            await Task.Delay(1);

            //Because we broke our work into multiple projects, and our view models now are in a Core project that can be shared between different enviorments
            //This way o accesing the UI isn't valid anymore
            //var currentApplication = Application.Current;

            //var mainWindow = (MainWindow)currentApplication.MainWindow;

            //var dataContext = (WindowViewModel)mainWindow.DataContext;

            //dataContext.CurrentPage = ApplicationPage.Register;
        }

        #endregion
    }
}
