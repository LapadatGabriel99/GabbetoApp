using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fasseto.Word.Core
{
    /// <summary>
    /// The desing time data for a <see cref="ChatListViewModel"/>
    /// </summary>
    public class ChatListDesignModel : ChatListViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static ChatListDesignModel Instance { get { return new ChatListDesignModel(); } }

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public ChatListDesignModel()
        {
            Items = new List<ChatListItemViewModel>
            {
                new ChatListItemViewModel
                {
                    Name = "Gabi",
                    Initials = "GM",
                    Message = "Heeeyaaaaaaaaaa",
                    ProfilePictureRGB = "3099c5",
                    NewContentAvailable = true
                },

                new ChatListItemViewModel
                {
                    Name = "BossBaros",
                    Initials = "BB",
                    Message = "Sa traiasca nasu",
                    ProfilePictureRGB = "ff0000"
                },

                new ChatListItemViewModel
                {
                    Name = "Gabi",
                    Initials = "GM",
                    Message = "Heeeyaaaaaaaaaa",
                    ProfilePictureRGB = "0000ff"
                },

                new ChatListItemViewModel
                {
                    Name = "Gabi",
                    Initials = "GM",
                    Message = "Heeeyaaaaaaaaaa",
                    ProfilePictureRGB = "fe4503",
                    IsSelected = true
                },

                new ChatListItemViewModel
                {
                    Name = "Gabi",
                    Initials = "GM",
                    Message = "Heeeyaaaaaaaaaa",
                    ProfilePictureRGB = "00d405"
                },

                new ChatListItemViewModel
                {
                    Name = "Gabi",
                    Initials = "GM",
                    Message = "Heeeyaaaaaaaaaa",
                    ProfilePictureRGB = "00d455"
                },

                new ChatListItemViewModel
                {
                    Name = "Gabi",
                    Initials = "GM",
                    Message = "Heeeyaaaaaaaaaa",
                    ProfilePictureRGB = "00d450"
                },

                new ChatListItemViewModel
                {
                    Name = "Gabi",
                    Initials = "GM",
                    Message = "Heeeyaaaaaaaaaa",
                    ProfilePictureRGB = "ff55ff"
                },

                new ChatListItemViewModel
                {
                    Name = "Gabi",
                    Initials = "GM",
                    Message = "Heeeyaaaaaaaaaa",
                    ProfilePictureRGB = "ff0045"
                },

                new ChatListItemViewModel
                {
                    Name = "Gabi",
                    Initials = "GM",
                    Message = "Heeeyaaaaaaaaaa",
                    ProfilePictureRGB = "00d045"
                }
            };
        }

        #endregion
    }
}
