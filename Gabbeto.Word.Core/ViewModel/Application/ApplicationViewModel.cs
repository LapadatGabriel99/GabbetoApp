using ProjectUniversal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fasseto.Word.Core
{
    /// <summary>
    /// The app state as a view model
    /// </summary>
    public class ApplicationViewModel : BaseViewModel
    {
        /// <summary>
        /// The current page of the application
        /// </summary>
        public ApplicationPage CurrentPage { get; private set; } = ApplicationPage.Login;

        /// <summary>
        /// The view model to use for the current page when the CurrentPage changes
        /// NOTE: This is not a live up-to-date view model of the current page
        ///       it is simply used to set the view model of the current page
        ///       at the time it changes
        /// </summary>
        public BaseViewModel CurrentPageViewModel { get; set; }

        /// <summary>
        /// True if the side menu should be shown
        /// </summary>
        public bool SideMenuVisible { get; set; } = false;

        /// <summary>
        /// True if the settings menu should be shown
        /// </summary>
        public bool SettingsMenuVisible { get; set; } = false;

        /// <summary>
        /// Navigate to the specified page
        /// </summary>
        /// <param name="page">The page to go to</param>
        public void GoToPage(ApplicationPage page, BaseViewModel viewModel = null)
        {
            //Always hide settings menu when going to different page
            SettingsMenuVisible = false;

            //Set the view model
            CurrentPageViewModel = viewModel;

            //Set the current page to the passed value
            CurrentPage = page;

            //Fire off a CurrentPage changed event
            OnPropertyChanged(nameof(CurrentPage));

            //Show menu or not?
            if (page == ApplicationPage.Chat)
                SideMenuVisible = true;
            else
                SideMenuVisible = false;
        }

        /// <summary>
        /// A method that handles the aftermath of a successful authentication web request
        /// </summary>
        /// <param name="authenticationResult">The authentication result containing user details</param>
        /// <returns>Returns once the client data store transaction, user settings load and page changing happen</returns>
        public async Task OnSuccesfulLoginHandler(IDefaultAuthenticationResult authenticationResult)
        {
            // Save the web request result inside the client data store
            await IoC.ClientDataStore.SaveLoginCredentialsAsync(new LoginCredentialsDataModel
            {
                Token = authenticationResult.Token,
                Username = authenticationResult.Username,
                Email = authenticationResult.Email,
                FirstName = authenticationResult.FirstName,
                LastName = authenticationResult.LastName
            });

            // After login save the client details inside the settings view model
            await IoC.SettingsViewModel.LoadAsync();

            // Go to chat page after all is done
            IoC.ApplicationViewModel.GoToPage(ApplicationPage.Chat);
        }
       
        /// <summary>
        /// Tries to login a user
        /// </summary>
        /// <param name="url">The url where the request is made</param>
        /// <param name="usernameOrEmail">The username or the email included in the credentials</param>
        /// <param name="password">The password included in the credentials</param>
        /// <returns>Returns once the task is finished</returns>
        public async Task LoginAsync(string url, string usernameOrEmail, object password)
        {
            // Call the server and attempt to log in with credentials           
            var result = await WebRequests.PostAsync<ApiResponse<LoginResultApiModel>>(
                url,
                new LoginCredentialsApiModel
                {
                    UsernameOrEmail = usernameOrEmail,
                    Password = (password as IHavePassword).SecurePassword.Unsecure()
                });

            // Check the web request result for any possible errors
            var errors = await result.DisplayErrorIfFailedAsync<ApiResponse<LoginResultApiModel>, LoginResultApiModel>("Login Failed!", "OK");

            // If we encounter any errors
            if (errors)
            {
                // Return
                return;
            }

            //OK successfully logged in... now get users data  

            // The user data we just received
            var userData = result.ServerResponse.Response;

            // Pass the users data so that the response of the web request
            // can be handled accordingly 
            await IoC.ApplicationViewModel.OnSuccesfulLoginHandler(userData);
        }

        /// <summary>
        /// Tries to register a suer
        /// </summary>
        /// <param name="url">The url where the request is made</param>
        /// <param name="username">The username included in the credentials</param>
        /// <param name="email">The email included in the credentials</param>
        /// <param name="password">The password included in the credentials</param>
        /// <returns>Returns once the task is finished</returns>
        public async Task RegisterAsync(string url, string username, string email, object password)
        {
            // Call the server and attempt to log in with credentials
            var result = await WebRequests.PostAsync<ApiResponse<RegisterResultApiModel>>(
                url,
                new RegisterCredentialsApiModel
                {
                    Username = username,
                    Email = email,
                    Password = (password as IHavePassword).SecurePassword.Unsecure()
                });

            // Check the web request result for any possible errors
            var errors = await result.DisplayErrorIfFailedAsync<ApiResponse<RegisterResultApiModel>, RegisterResultApiModel>("Register Failed!", "OK");

            // If we encounter any errors
            if (errors)
            {
                // Return
                return;
            }

            //OK successfully registered... now get users data  

            // The user data we just received
            var userData = result.ServerResponse.Response;

            // Pass the users data so that the response of the web request
            // can be handled accordingly 
            await IoC.ApplicationViewModel.OnSuccesfulLoginHandler(userData);
        }

        // TODO: Refactor Login/Register methods in the future...

        // TODO: Add more pages to the app, and subsequent view models to them, so
        //       the app becomes more dynamic
    }
}
