using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Fasseto.Word.Core
{
    ///<sumary>
    ///
    ///</sumary>
    public class SettingsViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// The current users name
        /// </summary>
        public TextEntryViewModel Name { get; set; }

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
            LogoutCommand = new RelayCommand(() => Logout());
            ClearUserDataCommand = new RelayCommand(() => ClearUserData());
            LoadCommand = new RelayCommand(async () => await LoadAsync());
            SaveNameCommand = new RelayCommand(async () => await SaveNameAsync(Name));
            SaveUsernameCommand = new RelayCommand(async () => await SaveUsernameAsync(UserName));
            SaveEmailCommand = new RelayCommand(async () => await SaveEmailAsync(Email));
            SavePasswordCommand = new RelayCommand(async () => await SavePasswordAsync(Password));

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
        private void Logout()
        {
            //TOTO: Confirm the user wants to log out

            //TODO: Clear any user data/chace

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
           
            var storedCredentials = await IoC.ClientDataStore.GetLoginCredentialsAsync();

            Name = new TextEntryViewModel
            {
                Label = "Name",
                OriginalText = $"{ storedCredentials?.FirstName } { storedCredentials?.LastName } { DateTime.UtcNow.ToLocalTime() }",
                CommitAction = SaveNameAsync
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
        public async Task<bool> SaveNameAsync(TextEntryViewModel self)
        {
            // TODO: Update with server
            await Task.Delay(3000);

            // Return true
            return true;
        }

        /// <summary>
        /// Saves the new email to the server
        /// </summary>
        /// <param name="self">The details of the view model</param>
        /// <returns>Returns true if successful, false otherwise</returns>
        public async Task<bool> SaveEmailAsync(TextEntryViewModel self)
        {
            // TODO: Update with server
            await Task.Delay(3000);

            // Return true
            return false;
        }

        /// <summary>
        /// Saves the new username to the server
        /// </summary>
        /// <param name="self">The details of the view model</param>
        /// <returns>Returns true if successful, false otherwise</returns>
        public async Task<bool> SaveUsernameAsync(TextEntryViewModel self)
        {
            // TODO: Update with server
            await Task.Delay(3000);

            // Return true
            return true;
        }


        /// <summary>
        /// Saves the new password to the server
        /// </summary>
        /// <param name="self">The details of the view model</param>
        /// <returns>Returns true if successful, false otherwise</returns>
        public async Task<bool> SavePasswordAsync(PasswordEntryViewModel self)
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
