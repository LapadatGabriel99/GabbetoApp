using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Fasseto.Word.Core
{
    ///<sumary>
    /// The view model for the post register page
    ///</sumary>
    public class PostRegisterViewModel : BaseViewModel
    {
        #region Private Members



        #endregion

        #region Public Properties

        /// <summary>
        /// A flag indicating whether we tried verifying or not
        /// </summary>
        public bool VerifyIsRunning { get; set; }

        #endregion

        #region Commands

        /// <summary>
        /// The command use to verify the email
        /// </summary>
        public ICommand VerifyCommand { get; set; }

        /// <summary>
        /// The command to go back to the login page
        /// </summary>
        public ICommand LoginCommand { get; set; }

        /// <summary>
        /// The command to go to the optional credentials command
        /// </summary>
        public ICommand OptionalCredentialsCommand { get; set; }

        #endregion

        #region Constructors

        ///<sumary>
        /// Default Constructor
        ///</sumary>
        public PostRegisterViewModel()
        {
            // Setup commands
            VerifyCommand = new RelayCommand(async () => await VerifyEmailAsync());
            LoginCommand = new RelayCommand(async () => await GoToLogin());
            OptionalCredentialsCommand = new RelayCommand(async () => await GoToOptionalCredentials());
        }

        #endregion

        #region Private Helpers

        /// <summary>
        /// Opens the default browser of the registered user
        /// and goes to the mail service of the email address that was
        /// used by the user to perform registration
        /// </summary>
        /// <param name="mailService">The mail service as a enum type</param>
        /// <returns>Returns once the process finishes</returns>
        private async Task OpenDefaultBrowserAtMailService(MailServiceType mailService)
        {
            // Use the task manager in case of any errors occurring
            // so that we can log them
            await IoC.Task.Run(() =>
                // Start the process
                Process.Start(mailService.ToMailServiceUrl())
            );            
        }

        #endregion

        #region Command Helpers

        /// <summary>
        /// A function that goes to a mail service
        /// so that the user can verify it's email
        /// </summary>
        /// <returns></returns>
        public async Task VerifyEmailAsync()
        {
            // 
            await RunCommandAsync(() => VerifyIsRunning, async () =>
            {
                // Get the current stored user credentials
                var userCredentials = await IoC.ClientDataStore.GetLoginCredentialsAsync();

                // Get the users email
                var email = userCredentials.Email;

                // Get the mail service of the users email address
                var mailService = email.GetMailServiceString().ToMailService();

                // Go the users default browser so that he can
                // try verifying his email at the given mail service
                await OpenDefaultBrowserAtMailService(mailService);
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

        /// <summary>
        /// Go to optional credentials page
        /// </summary>
        /// <returns></returns>
        public async Task GoToOptionalCredentials()
        {
            // Wait a bit before page swap
            await Task.Delay(1);

            // Change the page
            IoC.ApplicationViewModel.GoToPage(ApplicationPage.OptionalCredentials, new OptionalCredentialsViewModel());
        }

        #endregion
    }
}
