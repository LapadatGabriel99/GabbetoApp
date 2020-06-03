using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Fasseto.Word.Core
{
    /// <summary>
    /// The view model for the search add list item control
    /// </summary>
    public class SearchAddListItemViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// The display name of the chat list item
        /// </summary>
        public string NameAndUserName { get; set; }

        /// <summary>
        /// The latest message from the chat 
        /// </summary>
        public string Description { get; set; }

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
        /// The command used to add a friend
        /// </summary>
        public ICommand AddFriendCommand { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        public SearchAddListItemViewModel()
        {
            // Setup commands

            AddFriendCommand = new RelayCommand(async () => await AddFriend());
        }

        #endregion

        #region Command Methods

        /// <summary>
        /// Adds a friend to our friend list
        /// </summary>
        /// <returns></returns>
        private async Task AddFriend()
        {
            // TODO: Add web request after server side is done
            await Task.Delay(1000);
        }

        #endregion
    }
}
