using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace Fasseto.Word.Core
{
    /// <summary>
    /// A view model for each chat list item in the overview list chat
    /// </summary>
    public class ChatListItemViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// The display name of the chat list item
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The latest message from the chat 
        /// </summary>
        public string Message { get; set; }

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
        /// True if there are unread messages in this chat
        /// </summary>
        public bool NewContentAvailable { get; set; }

        /// <summary>
        /// True if this item is selected
        /// </summary>
        public bool IsSelected { get; set; }

        #endregion

        #region Commands

        /// <summary>
        /// The command to open a chat message
        /// </summary>
        public ICommand OpenMessageCommand { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        public ChatListItemViewModel()
        {
            OpenMessageCommand = new RelayCommand(() => OpenMessage());
        }

        #endregion

        #region Command Methods

        private void OpenMessage()
        {           
            IoC.ApplicationViewModel.GoToPage(ApplicationPage.Chat, new ChatMessageListViewModel
            {
                DisplayTitle = "Mister Boss Baros",

                Items = new ObservableCollection<ChatMessageListItemViewModel>()
                {                    
                    new ChatMessageListItemViewModel
                    {
                        Message = this.Message,
                        Initials = this.Initials,
                        MessageSentTime = DateTime.UtcNow,
                        ProfilePictureRGB = "FF00FF",
                        SenderName = "Gabi",
                        SentByMe = true
                    },

                    new ChatMessageListItemViewModel
                    {
                        Message = "A received message",
                        Initials = this.Initials,
                        MessageSentTime = DateTime.UtcNow,
                        ProfilePictureRGB = "FF0000",
                        SenderName = "Boss Baros",
                        SentByMe = false
                    },

                    new ChatMessageListItemViewModel
                    {
                        Message = "Nice Man!!!!!!!!",
                        Initials = this.Initials,
                        MessageSentTime = DateTime.UtcNow,
                        ProfilePictureRGB = "FF00FF",
                        SenderName = "Gabi",
                        SentByMe = true
                    },

                    new ChatMessageListItemViewModel
                    {
                        Message = this.Message,
                        Initials = this.Initials,
                        MessageSentTime = DateTime.UtcNow,
                        ProfilePictureRGB = "FF00FF",
                        SenderName = "Gabi",
                        SentByMe = true
                    },

                    new ChatMessageListItemViewModel
                    {
                        Message = "A received message",
                        Initials = this.Initials,
                        MessageSentTime = DateTime.UtcNow,
                        ProfilePictureRGB = "FF0000",
                        SenderName = "Boss Baros",
                        SentByMe = false
                    },

                    new ChatMessageListItemViewModel
                    {
                        Message = "Nice Man!!!!!!!!",
                        ImageAttachment = new ChatMessageListItemImageAttachmentViewModel
                        {
                            ThumbnailUrl = "http://anywhere"
                        },                        
                        Initials = this.Initials,
                        MessageSentTime = DateTime.UtcNow,
                        ProfilePictureRGB = "FF00FF",
                        SenderName = "Gabi",
                        SentByMe = true
                    },
                }
            }); 
        }

        #endregion
    }
}
