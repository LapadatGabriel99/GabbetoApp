using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace Fasseto.Word.Core
{
    /// <summary>
    /// A design time view model of <see cref="FriendRequestListViewModel"/>
    /// </summary>
    public class FriendRequestListDesignModel : FriendRequestListViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of this view model
        /// </summary>
        public static FriendRequestListDesignModel Instance => new FriendRequestListDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public FriendRequestListDesignModel()
        {
            Items = new ObservableCollection<FriendRequestListItemViewModel>
            {
                new FriendRequestListItemViewModel
                {
                    Name = "Gabi",
                    Initials = "GM",
                    Message = "Heeeyaaaaaaaaaa",
                    ProfilePictureRGB = "3099c5",
                    NewContentAvailable = true
                },

                new FriendRequestListItemViewModel
                {
                    Name = "BossBaros",
                    Initials = "BB",
                    Message = "Sa traiasca nasu",
                    ProfilePictureRGB = "ff0000"
                },

                new FriendRequestListItemViewModel
                {
                    Name = "Gabi",
                    Initials = "GM",
                    Message = "Heeeyaaaaaaaaaa",
                    ProfilePictureRGB = "0000ff"
                },

                new FriendRequestListItemViewModel
                {
                    Name = "Gabi",
                    Initials = "GM",
                    Message = "Heeeyaaaaaaaaaa",
                    ProfilePictureRGB = "fe4503",
                    IsSelected = true
                },

                new FriendRequestListItemViewModel
                {
                    Name = "Gabi",
                    Initials = "GM",
                    Message = "Heeeyaaaaaaaaaa",
                    ProfilePictureRGB = "00d405"
                },

                new FriendRequestListItemViewModel
                {
                    Name = "Gabi",
                    Initials = "GM",
                    Message = "Heeeyaaaaaaaaaa",
                    ProfilePictureRGB = "00d455"
                },

                new FriendRequestListItemViewModel
                {
                    Name = "Gabi",
                    Initials = "GM",
                    Message = "Heeeyaaaaaaaaaa",
                    ProfilePictureRGB = "00d450"
                },

                new FriendRequestListItemViewModel
                {
                    Name = "Gabi",
                    Initials = "GM",
                    Message = "Heeeyaaaaaaaaaa",
                    ProfilePictureRGB = "ff55ff"
                },

                new FriendRequestListItemViewModel
                {
                    Name = "Gabi",
                    Initials = "GM",
                    Message = "Heeeyaaaaaaaaaa",
                    ProfilePictureRGB = "ff0045"
                },

                new FriendRequestListItemViewModel
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
