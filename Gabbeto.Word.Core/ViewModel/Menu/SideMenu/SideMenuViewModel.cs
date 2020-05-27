using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
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
            GoToChatListPageCommand = new RelayCommand(async () => await GoToChatListPage());
            GoToSearchAddPageCommand = new RelayCommand(async () => await GoToSearchAddFriendPage());
            GoToFriendRequestPageCommand = new RelayCommand(async () => await GoToFriendRequestPage());
        }

        #endregion

        #region Command Methods

        /// <summary>
        /// Goes to the chat list page
        /// </summary>
        public async Task GoToChatListPage()
        {
            IoC.ApplicationViewModel.GoToSideMenuPage(SideMenuPage.ChatList, new ChatListViewModel());

            await Task.Delay(1);
        }

        /// <summary>
        /// Goes to the search/add page
        /// </summary>
        public async Task GoToSearchAddFriendPage()
        {
            IoC.ApplicationViewModel.GoToSideMenuPage(SideMenuPage.AddSearch, new SearchAddListViewModel());

            await Task.Delay(1);
        }

        /// <summary>
        /// Goes to the friend request page
        /// </summary>
        public async Task GoToFriendRequestPage()
        {
            IoC.ApplicationViewModel.GoToSideMenuPage(SideMenuPage.FriendshipRequest, new FriendRequestListViewModel());

            await Task.Delay(1);
        }

        #endregion
    }
}
