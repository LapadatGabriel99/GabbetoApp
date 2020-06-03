using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Fasseto.Word.Core
{
    /// <summary>
    /// The view model for the friend request list item control
    /// </summary>
    public class FriendRequestListItemViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// The display name of the chat list item
        /// </summary>
        public string NameAndUserName { get; set; }        

        /// <summary>
        /// The initials for the profile picture background
        /// </summary>
        public string Initials { get; set; }

        /// <summary>
        /// The RGB values, in hex, for the background color of the profile picture
        /// For example FF00FF for red and blue mixed
        /// </summary>
        public string ProfilePictureRGB { get; set; }        

        /// <summary>
        /// True if this item is selected
        /// </summary>
        public bool IsSelected { get; set; }

        #endregion

        #region Commands

        /// <summary>
        /// The command when an user accepts a friend request
        /// </summary>
        public ICommand AcceptFriendRequestCommand { get; set; }

        /// <summary>
        /// The command when an user declines a friend request
        /// </summary>
        public ICommand DeclineFriendRequestCommand { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        public FriendRequestListItemViewModel()
        {
            // Setup commands
            AcceptFriendRequestCommand = new RelayCommand(async () => await AcceptFriendRequest());
            DeclineFriendRequestCommand = new RelayCommand(async () => await DeclineFriendRequest());
        }

        #endregion

        #region Command Methods

        /// <summary>
        /// Accepts a friend request that the current user received
        /// </summary>
        /// <returns></returns>
        private async Task AcceptFriendRequest()
        {
            await Task.Delay(1000);
        }

        /// <summary>
        /// Declines a friend request that the current user received
        /// </summary>
        /// <returns></returns>
        private async Task DeclineFriendRequest()
        {
            await Task.Delay(1000);
        }

        #endregion
    }
}
