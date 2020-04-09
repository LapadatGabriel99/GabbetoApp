using ProjectUniversal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Fasseto.Word.Core
{
    /// <summary>
    /// The view model for the register page
    /// </summary>
    public class RegisterViewModel : BaseViewModel
    {
        #region Private Members       

        #endregion

        #region Public Properties

        /// <summary>
        /// The username of the user
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// The email of the user
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// A flag indicating whether we are trying to register or not
        /// </summary>
        public bool RegisterIsRunning { get; set; } = false;

        #endregion

        #region Commands

        /// <summary>
        /// The command to go to the login page
        /// </summary>
        public ICommand LoginCommand { get; set; }

        /// <summary>
        /// The command to perform registration action
        /// </summary>
        public ICommand RegisterCommand { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        public RegisterViewModel()
        {
            //Create commands
            RegisterCommand = new RelayParameterizedCommand(async (parameter) => await RegisterAsync(parameter));
            LoginCommand = new RelayCommand(async () => await LoginAsync());
        }

        #endregion

        #region Command Helpers

        /// <summary>
        /// Takes the user to the login page
        /// </summary>
        /// <returns></returns>
        public async Task LoginAsync()
        {
            // Goes to the login page
            IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.Login, new LoginViewModel());

            await Task.Delay(1);
        }

        /// <summary>
        /// Attempts to register the user
        /// </summary>
        /// <param name="parameter">The <see cref="SecureString"/> passed in from the view for the user's password</param>
        /// <returns></returns>
        public async Task RegisterAsync(object parameter)
        {
            await RunCommandAsync(() => this.RegisterIsRunning, async () => 
            {
                // Let the application view model perform a register task
                // TODO: Move all url's and api routes to static class in core
                await IoC.ApplicationViewModel.RegisterAsync("https://localhost:5001/api/login", Username, Email, parameter);
            });
        }

        #endregion

    }
}
