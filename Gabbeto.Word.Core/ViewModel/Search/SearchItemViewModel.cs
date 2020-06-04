using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Fasseto.Word.Core
{
    /// <summary>
    /// The view model for the Search Item Control
    /// </summary>
    public class SearchItemViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// The tag displayed inside the search bar
        /// </summary>
        public string SearchBarText { get; set; }

        /// <summary>
        /// The action to run when saving the text
        /// Returns true if the commit was successful, or false otherwise
        /// </summary>
        public Func<Task<bool>> CommitAction { get; set; }

        /// <summary>
        /// The text that the current user enters in the search bar
        /// </summary>
        public string InputText { get; set; }

        #endregion

        #region Commands

        /// <summary>
        /// The command to use when an user is being searched
        /// </summary>
        public ICommand SearchUserCommand { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        public SearchItemViewModel()
        {
            // Setup commands

            SearchUserCommand = new RelayCommand(async () => await SearchUser());

            // TODO: Localize strings, in a static class
            SearchBarText = "Search user...";
        }

        #endregion

        #region Command Methods

        public async Task SearchUser()
        {
            await Task.Delay(1);
        }

        #endregion
    }
}
