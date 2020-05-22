using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Fasseto.Word.Core
{
    /// <summary>
    /// The view model for the side menu control
    /// </summary>
    public class SideMenuViewModel : BaseViewModel
    {
        #region Public Properties



        #endregion

        #region Commands

        /// <summary>
        /// The command that goes to the friend request control
        /// </summary>
        public ICommand GoToFriendRequestPageCommand { get; set; }

        /// <summary>
        /// The command that goes to the search/add friend control
        /// </summary>
        public ICommand GoToSearchAddPageCommand { get; set; }

        /// <summary>
        /// The command that goes to the chat list control
        /// </summary>
        public ICommand GoToChatListPageCommand { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        public SideMenuViewModel()
        {
            // Setup the commands
            GoToChatListPageCommand = new RelayCommand(GoToChatListPage);
            GoToSearchAddPageCommand = new RelayCommand(GoToSearchAddFriendPage);
            GoToFriendRequestPageCommand = new RelayCommand(GoToFriendRequestPage);
        }

        #endregion

        #region Command Methods

        /// <summary>
        /// Goes to the chat list page
        /// </summary>
        public void GoToChatListPage()
        {

        }

        /// <summary>
        /// Goes to the search/add page
        /// </summary>
        public void GoToSearchAddFriendPage()
        {

        }

        /// <summary>
        /// Goes to the friend request page
        /// </summary>
        public void GoToFriendRequestPage()
        {

        }

        #endregion
    }
}
