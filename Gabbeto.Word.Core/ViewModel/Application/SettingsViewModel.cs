using System;
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

            //TODO: Remove this in fhe future( when we have a real back-end )
            Name = new TextEntryViewModel { Label = "Name", OriginalText = "Gabi Lapadat" };
            UserName = new TextEntryViewModel { Label = "UserName", OriginalText = "gabi" };
            Password = new PasswordEntryViewModel { Label = "Password", FakePassword = "*******" };
            Email = new TextEntryViewModel { Label = "Email", OriginalText = "blabla@gmail.com" };

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

            //Clean all aplication level view models that contain
            //any information about this current user
            ClearUserData();

            //Go to login page
            IoC.ApplicationViewModel.GoToPage(ApplicationPage.Login);
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
