using System;
using System.Security;
using System.Windows.Input;
using System.Linq;
using System.Threading.Tasks;

namespace Fasseto.Word.Core
{
    ///<sumary>
    ///The view model for a password entry to edit a string value
    ///</sumary>
    public class PasswordEntryViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// The label to identify what this value is for
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// Fake password to display
        /// </summary>
        public string FakePassword { get; set; }

        /// <summary>
        /// The current password hint text
        /// </summary>
        public string CurrentPasswordHintText { get; set; }

        /// <summary>
        /// The new password hint text
        /// </summary>
        public string NewPasswordHintText { get; set; }

        /// <summary>
        /// The cofirm password hint text
        /// </summary>
        public string ConfirmPasswordHintText { get; set; }

        /// <summary>
        /// The current saved password
        /// </summary>
        public SecureString CurrentPassword { get; set; }

        /// <summary>
        /// The current uncommit edited password
        /// </summary>
        public SecureString NewPassword { get; set; }

        /// <summary>
        /// The current non-commited edited confirmed password
        /// </summary>
        public SecureString ConfirmPassword { get; set; }

        /// <summary>
        /// A flag that indicates if the current text is in edit mode
        /// </summary>
        public bool Editing { get; set; }

        /// <summary>
        /// Indicates if the current control is pending an update (in progress)
        /// </summary>
        public bool Pending { get; set; }

        /// <summary>
        /// The action to run when saving the text
        /// Returns true if the commit was successful, or false otherwise
        /// </summary>
        public Func<Task<bool>> CommitAction { get; set; }

        #endregion

        #region Public Commands

        /// <summary>
        /// The command that puts the control in edit mode
        /// </summary>
        public ICommand EditCommand { get; set; }

        /// <summary>
        /// The command that cancels out of edit mode
        /// </summary>
        public ICommand CancelCommand { get; set; }

        /// <summary>
        /// The command that commits the edits and saves the value
        /// as well as goes back to non-edit mode
        /// </summary>
        public ICommand SaveCommand { get; set; }

        #endregion

        #region Constructors

        ///<sumary>
        ///Default Constructor
        ///</sumary>
        public PasswordEntryViewModel()
        {
            //Create commands
            EditCommand = new RelayCommand(() => Edit());
            CancelCommand = new RelayCommand(() => Cancel());
            SaveCommand = new RelayCommand(() => Save());

            //Set default hints
            //TODO: Replace with localization text
            CurrentPasswordHintText = "Current Password";
            NewPasswordHintText = "New Password";
            ConfirmPasswordHintText = "Confirm Password";
        }

        #endregion

        #region Command Helpers

        /// <summary>
        /// Puts the control in edit mode
        /// </summary>
        private void Edit()
        {
            NewPassword = new SecureString();
            ConfirmPassword = new SecureString();            

            //Go into edit mode
            Editing = true;
        }

        /// <summary>
        /// Cancels out of edit mode
        /// </summary>
        private void Cancel()
        {
            Editing = false;
        }

        /// <summary>
        /// Commits the content and exits out of edit mode
        /// </summary>
        private void Save()
        {
            #region Old Password Checks Logic

            ////Make sure current password is corect
            ////TODO this will come from a real back-end store of this users password
            ////     or via asking the web server to confirm it
            //var storedPassword = "Testing";

            ////Confirm the password is a match
            //if (storedPassword != CurrentPassword.Unsecure())
            //{
            //    //Let user know
            //    IoC.UI.ShowMessage(new MessageBoxDialogViewModel()
            //    {
            //        Title = "Wrong password",
            //        OkText = "OK",
            //        Message = "The current password is invalid"
            //    });

            //    return;
            //}

            //if(NewPassword.Unsecure().Length == 0)
            //{
            //    //Let user know
            //    IoC.UI.ShowMessage(new MessageBoxDialogViewModel()
            //    {
            //        Title = "Password to short",
            //        OkText = "OK",
            //        Message = "You must enter a password!"
            //    });

            //    return;
            //}

            ////Now check if edited password is equal to confirmed password
            //if (NewPassword.Unsecure() != ConfirmPassword.Unsecure())
            //{
            //    //Let user know
            //    IoC.UI.ShowMessage(new MessageBoxDialogViewModel()
            //    {
            //        Title = "Password mismatch",
            //        OkText = "OK",
            //        Message = "The new and confirm password do not match"
            //    });

            //    return;
            //}

            ////Set the edited password to the current password
            //CurrentPassword = new SecureString();

            //foreach (var character in NewPassword.Unsecure().ToCharArray())
            //{
            //    CurrentPassword.AppendChar(character);
            //}

            //Editing = false;

            #endregion

            // Store the result of a commit call
            var result = default(bool);            

            RunCommandAsync(() => Pending, async () =>
            {
                // While working come out of edit mode
                Editing = false;               

                // Try to commit the action
                result = CommitAction == null ? true : await CommitAction();

            }).ContinueWith(t =>
            {
                // If we succeeded 
                // Nothing to do
                // If we fail...
                if (!result)
                {                    
                    // Go back into edit mode
                    Editing = true;
                }
            });

            //NOTE: Small bug here, when pressing enter the content of edited text does not change
        }

        #endregion
    }
}
