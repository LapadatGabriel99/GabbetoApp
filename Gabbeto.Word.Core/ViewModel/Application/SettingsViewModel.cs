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
                OriginalText = $"{ storedCredentials?.FirstName } { storedCredentials?.LastName } { DateTime.UtcNow.ToLocalTime() }"
            };

            UserName = new TextEntryViewModel
            {
                Label = "Username",
                OriginalText = $"{ storedCredentials?.Username }"
            };

            Password = new PasswordEntryViewModel
            {
                Label = "Password",
                FakePassword = "*******"
            };

            Email = new TextEntryViewModel
            {
                Label = "Email",
                OriginalText = $"{ storedCredentials?.Email }"
            };            
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
