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
                // Call the server and attempt to log in with credentials
                // TODO: Move all url's and api routes to static class in core
                var result = await WebRequests.PostAsync<ApiResponse<LoginResultApiModel>>(
                    "https://localhost:5001/api/login",
                    new LoginCredentialsApiModel
                    {
                        UsernameOrEmail = Email,
                        Password = (parameter as IHavePassword).SecurePassword.Unsecure()
                    }
                    );

                // If there was no result, bad data, or a response with a error message...
                if(result == null || result.ServerResponse == null || !result.ServerResponse.Successful)
                {
                    // Default message
                    // TODO: Localize strings
                    var message = "Unknown error from server call";

                    // If got a response from the server
                    if (result?.ServerResponse != null)
                    {
                        // Set the message to the server response error message
                        message = result.ServerResponse.ErrorMessage;
                    }
                    // If we have a result, but deserialization failed
                    else if(!result.RawServerResponse.IsNullOrWhitespace())
                    {
                        message = $"Unexpected response from server. { result.RawServerResponse }";
                    }
                    // If we have a result, but no server response details
                    else if(result != null)
                    {
                        // Set message to standard HTTP server response details
                        message = $"Failed to communicate with server. Status code { result.StatusCode }. { result.StatusDescription }";
                    }

                    // Display error call
                    await IoC.UI.ShowMessage(new MessageBoxDialogViewModel
                    {
                        // TODO: Localize strings
                        Title = "Login Failed",
                        OkText = "Ok",
                        Message = message
                    });

                    // Return
                    return;
                }

                //OK successfully logged in... now get users data   

                // The user data we just received
                var userData = result.ServerResponse.Response;
                
                // Set the Name of the user inside the settings view model
                IoC.SettingsViewModel.Name = new TextEntryViewModel 
                { 
                    Label = "Name", 
                    OriginalText = $"{ userData.FirstName } { userData.LastName } { DateTime.Now.ToLocalTime() }" 
                };

                // Set the UserName of the user inside the settings view model
                IoC.SettingsViewModel.UserName = new TextEntryViewModel 
                { 
                    Label = "UserName", 
                    OriginalText = $"{ userData.UserName }" 
                };

                // We leave the password as it is, no need to show here the real deal :)
                IoC.SettingsViewModel.Password = new PasswordEntryViewModel 
                { 
                    Label = "Password", 
                    FakePassword = "*******" 
                };

                // Set the Email of the user inside the settings view model
                IoC.SettingsViewModel.Email = new TextEntryViewModel 
                { 
                    Label = "Email", 
                    OriginalText = $"{ userData.Email }" 
                };

                // Go to the chat page after all this is done
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
