using System;
using System.Threading.Tasks;
using System.Windows.Input;
using ProjectUniversal;

namespace Fasseto.Word.Core
{
    ///<sumary>
    /// The view model for the optional credentials page
    ///</sumary>
    public class OptionalCredentialsViewModel : BaseViewModel
    {
        #region Private Members



        #endregion

        #region Public Properties

        /// <summary>
        /// A flag indicating whether we are trying to save or not
        /// </summary>
        public bool SaveIsRunning { get; set; }

        /// <summary>
        /// The users first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// The users last name
        /// </summary>
        public string LastName { get; set; }

        #endregion

        #region Commands

        /// <summary>
        /// The command to save the users first and last name
        /// </summary>
        public ICommand SaveCommand { get; set; }

        /// <summary>
        /// The command to take the user back to the login page
        /// </summary>
        public ICommand LoginCommand { get; set; }

        #endregion

        #region Constructors

        ///<sumary>
        ///Default Constructor
        ///</sumary>
        public OptionalCredentialsViewModel()
        {
            // Setup the commands
            SaveCommand = new RelayCommand(async () => await SaveCredentials());
            LoginCommand = new RelayCommand(async () => await GoToLogin());
        }

        #endregion

        #region Private Helpers



        #endregion

        #region Command Helpers

        /// <summary>
        /// Saves and commits the optional credentials to the server
        /// </summary>
        /// <returns></returns>
        public async Task SaveCredentials()
        {
            // Make sure we wait for the command to finish before attempting
            // to start it again
            await RunCommandAsync(() => SaveIsRunning, async () =>
            {
                // Make a post request to the server and get the result
                var result = await WebRequests.PostAsync<ApiResponse<OptionalCredentialsResultApiModel>>(
                    RouteHelpers.GetAbsoluteRoute(ApiRoutes.OptionalCredentials),
                    new OptionalCredentialsApiModel
                    {
                        Email = (await IoC.ClientDataStore.GetLoginCredentialsAsync()).Email,
                        FirstName = this.FirstName,
                        LastName = this.LastName
                    });

                // Check to see if there are any errors in the web response
                var errors = await result.DisplayErrorIfFailedAsync
                    <ApiResponse<OptionalCredentialsResultApiModel>, 
                        OptionalCredentialsResultApiModel>("Save Failed!", "OK");

                // If there are errors
                if(errors)
                {
                    // Return
                    return;
                }

                // We got this far so it means the commit worked

                // Get the response data
                var data = result.ServerResponse.Response;

                // Now update the user's data in the local data store
                await IoC.ClientDataStore.UpdateUserOptionalCredentialsAsync(
                    new OptionalCredentialsDataModel 
                    { 
                        FirstName = data.FirstName, LastName = data.LastName
                    });
            });
        }

        /// <summary>
        /// Go to login page
        /// </summary>
        /// <returns></returns>
        public async Task GoToLogin()
        {
            // Wait a bit before page swap
            await Task.Delay(1);

            // Change the page
            IoC.ApplicationViewModel.GoToPage(ApplicationPage.Login, new LoginViewModel());
        }

        #endregion
    }
}
