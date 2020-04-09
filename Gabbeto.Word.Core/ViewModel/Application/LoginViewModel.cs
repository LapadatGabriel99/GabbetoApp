using ProjectUniversal;
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
        /// <param name="parameter">Thee <see cref="SecureString"/> passed in from the view for the users password</param>
        /// <returns></returns>
        public async Task LoginAsync(object parameter)
        {
            await RunCommandAsync(() => this.LoginIsRunning, async () =>
            {
                // Let the application view model perform a login task
                // TODO: Move all url's and api routes to static class in core                
                await IoC.ApplicationViewModel.LoginAsync("https://localhost:5001/api/login", Email, parameter);
            });
        }

        /// <summary>
        /// Takes the user to the register page
        /// </summary>
        /// <returns></returns>
        public async Task RegisterAsync()
        {                   
            // Goes to the register page
            IoC.ApplicationViewModel.GoToPage(ApplicationPage.Register, new RegisterViewModel());

            await Task.Delay(1);
        }

        #endregion
    }
}
