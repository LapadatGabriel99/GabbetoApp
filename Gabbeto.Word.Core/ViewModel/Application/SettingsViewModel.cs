using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Fasseto.Word.Core
{
    ///<sumary>
    /// The view model for the settings page
    ///</sumary>
    public class SettingsViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// The current users name
        /// </summary>
        public TextEntryViewModel Name { get; set; }

        /// <summary>
        /// The current users first name
        /// </summary>
        public TextEntryViewModel FirstName { get; set; }

        /// <summary>
        /// The current users last name
        /// </summary>
        public TextEntryViewModel LastName { get; set; }

        /// <summary>
        /// The current users user-name
        /// </summary>
        public TextEntryViewModel UserName { get; set; }

        /// <summary>
        /// The current users password
        /// </summary>
        public PasswordEntryViewModel Password { get; set; }

        /// <summary>
        /// The current users email address
        /// </summary>
        public TextEntryViewModel Email { get; set; }

        /// <summary>
        /// The text for the logout button 
        /// </summary>
        public string LogoutButtonText { get; set; }

        #endregion

        #region Public Commands

        /// <summary>
        /// The command to go back to the chat page
        /// </summary>
        public ICommand GoBackCommand { get; set; }

        /// <summary>
        /// The command to go to the settings page
        /// </summary>
        public ICommand GoToCommand { get; set; }

        /// <summary>
        /// The command to logout of the application
        /// </summary>
        public ICommand LogoutCommand { get; set; }

        /// <summary>
        /// The command to clear the users data from the view model
        /// </summary>
        public ICommand ClearUserDataCommand { get; set; }

        /// <summary>
        /// The command to load the client settings data from the client data store
        /// </summary>
        public ICommand LoadCommand { get; set; }

        /// <summary>
        /// The command to save the current name to the server
        /// </summary>
        public ICommand SaveNameCommand { get; set; }

        /// <summary>
        /// The command to save the current first name to the server
        /// </summary>
        public ICommand SaveFirstNameCommand { get; set; }

        /// <summary>
        /// The command to save the current last name to the server
        /// </summary>
        public ICommand SaveLastNameCommand { get; set; }

        /// <summary>
        /// The command to save the current email to the server
        /// </summary>
        public ICommand SaveEmailCommand { get; set; }

        /// <summary>
        /// The command to save the current username to the server
        /// </summary>
        public ICommand SaveUsernameCommand { get; set; }

        /// <summary>
        /// The command to save the current password to the server
        /// </summary>
        public ICommand SavePasswordCommand { get; set; }

        #endregion

        #region Constructors

        ///<sumary>
        ///Default Constructor
        ///</sumary>
        public SettingsViewModel()
        {
            //Create commands
            GoBackCommand = new RelayCommand(() => GoBackToChatPage());
            GoToCommand = new RelayCommand(() => GoToSettingsPage());
            LogoutCommand = new RelayCommand(async () => await Logout());
            ClearUserDataCommand = new RelayCommand(() => ClearUserData());
            LoadCommand = new RelayCommand(async () => await LoadAsync());
            SaveNameCommand = new RelayCommand(async () => await SaveNameAsync());
            SaveFirstNameCommand = new RelayCommand(async () => await SaveFirstNameAsync());
            SaveLastNameCommand = new RelayCommand(async () => await SaveLastNameAsync());
            SaveUsernameCommand = new RelayCommand(async () => await SaveUsernameAsync());
            SaveEmailCommand = new RelayCommand(async () => await SaveEmailAsync());
            SavePasswordCommand = new RelayCommand(async () => await SavePasswordAsync());

            //TODO: Get from localization
            LogoutButtonText = "Logout";
        }

        #endregion

        #region Command Methods

        /// <summary>
        /// Goes back to the chat page
        /// </summary>
        private void GoBackToChatPage()
        {
            // Closes settings menu
            IoC.ApplicationViewModel.SettingsMenuVisible = false;
        }

        /// <summary>
        /// Goes to the settings page
        /// </summary>
        private void GoToSettingsPage()
        {
            // Opens settings menu
            IoC.ApplicationViewModel.SettingsMenuVisible = true;
        }

        /// <summary>
        /// Logout the current user
        /// </summary>
        private async Task Logout()
        {
            //TOTO: Confirm the user wants to log out

            // Clear any user data/cache
            await IoC.ClientDataStore.ClearAllLoginCredentialsAsync();

            //Clean all application level view models that contain
            //any information about this current user
            ClearUserData();

            //Go to login page
            IoC.ApplicationViewModel.GoToPage(ApplicationPage.Login, new LoginViewModel());
        }

        /// <summary>
        /// Sets the settings view model properties based on the data in the client data store
        /// </summary>
        public async Task LoadAsync()
        {
            // Get the current stored login credentials
            var storedCredentials = await IoC.ClientDataStore.GetLoginCredentialsAsync();

            FirstName = new TextEntryViewModel
            {
                Label = "First Name",
                OriginalText = $"{ storedCredentials?.FirstName }",
                CommitAction = SaveFirstNameAsync
            };

            LastName = new TextEntryViewModel
            {
                Label = "Last Name",
                OriginalText = $"{ storedCredentials?.LastName }",
                CommitAction = SaveLastNameAsync
            };

            UserName = new TextEntryViewModel
            {
                Label = "Username",
                OriginalText = $"{ storedCredentials?.Username }",
                CommitAction = SaveUsernameAsync
            };

            Password = new PasswordEntryViewModel
            {
                Label = "Password",
                FakePassword = "*******",
                CommitAction = SavePasswordAsync
            };

            Email = new TextEntryViewModel
            {
                Label = "Email",
                OriginalText = $"{ storedCredentials?.Email }",
                CommitAction = SaveEmailAsync
            };            
        }

        /// <summary>
        /// Saves the new name to the server
        /// </summary>
        /// <param name="self">The details of the view model</param>
        /// <returns>Returns true if successful, false otherwise</returns>
        public async Task<bool> SaveNameAsync()
        {
            // TODO: Update with server
            await Task.Delay(3000);

            // Return true
            return true;
        }

        /// <summary>
        /// Saves the new first name to the server
        /// </summary>
        /// <param name="self">The details of the view model</param>
        /// <returns>Returns true if successful, false otherwise</returns>
        public async Task<bool> SaveFirstNameAsync()
        {
            // Log message
            IoC.Logger.Log("Saving first name...", LogLevel.Informative);

            // Get the current known credentials
            var credentials = await IoC.ClientDataStore.GetLoginCredentialsAsync();

            // Log message
            IoC.Logger.Log($"First name currently { credentials.FirstName }, updating to { FirstName.OriginalText }", LogLevel.Informative);

            // If the value the user is trying to update is the same...
            if (credentials.FirstName == FirstName.OriginalText)
            {
                // Log message
                IoC.Logger.Log("They are the same, ignoring...", LogLevel.Informative);

                // Just return true
                return true;
            }

            // Set the first name
            credentials.FirstName = FirstName.OriginalText;

            // Update the server with the details
            // TODO: Urls localization
            var result = await ProjectUniversal.WebRequests.PostAsync<ApiResponse>(
                "https://localhost:5001/api/user/profile/update",
                new UpdateUserProfileApiModel
                {
                    FirstName = credentials.FirstName
                }, bearerToken: credentials.Token);

            // Check if there are any errors
            var errors = await result.DisplayErrorIfFailedAsync<ApiResponse>("Update Failed!", "OK");

            // If there are any...
            if(errors)
            {
                IoC.Logger.Log($"Failed to update first name. { result.ErrorMessage }", LogLevel.Informative);

                // Return false
                return false;
            }

            // If we got this far it means the commit was successful
            // Log message
            IoC.Logger.Log("Successfully updated First Name. Saving to local database cache", LogLevel.Informative);

            // Now update the local store
            await IoC.ClientDataStore.SaveLoginCredentialsAsync(credentials);

            // Return true
            return true;
        }

        /// <summary>
        /// Saves the new last name to the server
        /// </summary>
        /// <param name="self">The details of the view model</param>
        /// <returns>Returns true if successful, false otherwise</returns>
        public async Task<bool> SaveLastNameAsync()
        {
            // Get the current known credentials
            var credentials = await IoC.ClientDataStore.GetLoginCredentialsAsync();

            // If the value the user is trying to update is the same...
            if (credentials.LastName == LastName.OriginalText)
            {
                // Just return true
                return true;
            }

            // Set the first name
            credentials.LastName = LastName.OriginalText;

            // Update the server with the details
            // TODO: Urls localization
            var result = await ProjectUniversal.WebRequests.PostAsync<ApiResponse>(
                "https://localhost:5001/api/user/profile/update",
                new UpdateUserProfileApiModel
                {
                    LastName = credentials.LastName
                }, bearerToken: credentials.Token);

            // Check if there are any errors
            var errors = await result.DisplayErrorIfFailedAsync<ApiResponse>("Update Failed!", "OK");

            // If there are any...
            if (errors)
            {
                // Return false
                return false;
            }

            // If we got this far it means the commit was successful

            // Now update the local store
            await IoC.ClientDataStore.SaveLoginCredentialsAsync(credentials);

            // Return true
            return true;            
        }

        /// <summary>
        /// Saves the new email to the server
        /// </summary>
        /// <param name="self">The details of the view model</param>
        /// <returns>Returns true if successful, false otherwise</returns>
        public async Task<bool> SaveEmailAsync()
        {
            // Get the current known credentials
            var credentials = await IoC.ClientDataStore.GetLoginCredentialsAsync();

            // If the value the user is trying to update is the same...
            if (credentials.Email == Email.OriginalText)
            {
                // Just return true
                return true;
            }

            // Set the first name
            credentials.Email = Email.OriginalText;

            // Update the server with the details
            // TODO: Urls localization
            var result = await ProjectUniversal.WebRequests.PostAsync<ApiResponse>(
                "https://localhost:5001/api/user/profile/update",
                new UpdateUserProfileApiModel
                {
                    Email = credentials.Email
                }, bearerToken: credentials.Token);

            // Check if there are any errors
            var errors = await result.DisplayErrorIfFailedAsync<ApiResponse>("Update Failed!", "OK");

            // If there are any...
            if (errors)
            {
                // Return false
                return false;
            }

            // If we got this far it means the commit was successful

            // Now update the local store
            await IoC.ClientDataStore.SaveLoginCredentialsAsync(credentials);

            // Return true
            return true;
        }

        /// <summary>
        /// Saves the new username to the server
        /// </summary>
        /// <param name="self">The details of the view model</param>
        /// <returns>Returns true if successful, false otherwise</returns>
        public async Task<bool> SaveUsernameAsync()
        {
            // Get the current known credentials
            var credentials = await IoC.ClientDataStore.GetLoginCredentialsAsync();

            // If the value the user is trying to update is the same...
            if (credentials.Username == UserName.OriginalText)
            {
                // Just return true
                return true;
            }

            // Set the first name
            credentials.Username = UserName.OriginalText;

            // Update the server with the details
            // TODO: Urls localization
            var result = await ProjectUniversal.WebRequests.PostAsync<ApiResponse>(
                "https://localhost:5001/api/user/profile/update",
                new UpdateUserProfileApiModel
                {
                    Username = credentials.Username
                }, bearerToken: credentials.Token);

            // Check if there are any errors
            var errors = await result.DisplayErrorIfFailedAsync<ApiResponse>("Update Failed!", "OK");

            // If there are any...
            if (errors)
            {
                // Return false
                return false;
            }

            // If we got this far it means the commit was successful

            // Now update the local store
            await IoC.ClientDataStore.SaveLoginCredentialsAsync(credentials);

            // Return true
            return true;
        }

        /// <summary>
        /// Saves the new password to the server
        /// </summary>
        /// <param name="self">The details of the view model</param>
        /// <returns>Returns true if successful, false otherwise</returns>
        public async Task<bool> SavePasswordAsync()
        {
            // TODO: Update with server
            await Task.Delay(3000);

            // Return true
            return false;
        }

        #endregion

        #region Helpers

        /// <summary>
        /// Clears any specific data of the current user
        /// </summary>
        public void ClearUserData()
        {
            Name = null;
            UserName = null;
            Password = null;
            Email = null;
        }        

        #endregion
    }
}
