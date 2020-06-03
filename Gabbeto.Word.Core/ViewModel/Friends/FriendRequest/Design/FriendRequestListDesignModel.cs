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
                    NameAndUserName = "Gabi",
                    Initials = "GM",                    
                    ProfilePictureRGB = "3099c5",                    
                },

                new FriendRequestListItemViewModel
                {
                    NameAndUserName = "BossBaros",
                    Initials = "BB",                    
                    ProfilePictureRGB = "ff0000"
                },

                new FriendRequestListItemViewModel
                {
                    NameAndUserName = "Gabi",
                    Initials = "GM",                    
                    ProfilePictureRGB = "0000ff"
                },

                new FriendRequestListItemViewModel
                {
                    NameAndUserName = "Gabi",
                    Initials = "GM",                    
                    ProfilePictureRGB = "fe4503",
                    IsSelected = true
                },

                new FriendRequestListItemViewModel
                {
                    NameAndUserName = "Gabi",
                    Initials = "GM",                    
                    ProfilePictureRGB = "00d405"
                },

                new FriendRequestListItemViewModel
                {
                    NameAndUserName = "Gabi",
                    Initials = "GM",                    
                    ProfilePictureRGB = "00d455"
                },

                new FriendRequestListItemViewModel
                {
                    NameAndUserName = "Gabi",
                    Initials = "GM",                    
                    ProfilePictureRGB = "00d450"
                },

                new FriendRequestListItemViewModel
                {
                    NameAndUserName = "Gabi",
                    Initials = "GM",                    
                    ProfilePictureRGB = "ff55ff"
                },

                new FriendRequestListItemViewModel
                {
                    NameAndUserName = "Gabi",
                    Initials = "GM",                    
                    ProfilePictureRGB = "ff0045"
                },

                new FriendRequestListItemViewModel
                {
                    NameAndUserName = "Gabi",
                    Initials = "GM",                    
                    ProfilePictureRGB = "00d045"
                }
            };
        }

        #endregion
    }
}
