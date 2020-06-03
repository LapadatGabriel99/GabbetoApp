using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace Fasseto.Word.Core
{
    /// <summary>
    /// A design time viewModel of <see cref="SearchAddListViewModel"/>
    /// </summary>
    public class SearchAddListDesignModel : SearchAddListViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of this design model
        /// </summary>
        public static SearchAddListDesignModel Instance => new SearchAddListDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public SearchAddListDesignModel()
        {
            Items = new ObservableCollection<SearchAddListItemViewModel>
            {
                new SearchAddListItemViewModel
                {
                    NameAndUserName = "Gabi",
                    Initials = "GM",
                    Description = "Heeeyaaaaaaaaaa",
                    ProfilePictureRGB = "3099c5",                    
                },

                new SearchAddListItemViewModel
                {
                    NameAndUserName = "BossBaros",
                    Initials = "BB",
                    Description = "Sa traiasca nasu",
                    ProfilePictureRGB = "ff0000"
                },

                new SearchAddListItemViewModel
                {
                    NameAndUserName = "Gabi",
                    Initials = "GM",
                    Description = "Heeeyaaaaaaaaaa",
                    ProfilePictureRGB = "0000ff"
                },

                new SearchAddListItemViewModel
                {
                    NameAndUserName = "Gabi",
                    Initials = "GM",
                    Description = "Heeeyaaaaaaaaaa",
                    ProfilePictureRGB = "fe4503",
                    IsSelected = true
                },

                new SearchAddListItemViewModel
                {
                    NameAndUserName = "Gabi",
                    Initials = "GM",
                    Description = "Heeeyaaaaaaaaaa",
                    ProfilePictureRGB = "00d405"
                },

                new SearchAddListItemViewModel
                {
                    NameAndUserName = "Gabi",
                    Initials = "GM",
                    Description = "Heeeyaaaaaaaaaa",
                    ProfilePictureRGB = "00d455"
                },

                new SearchAddListItemViewModel
                {
                    NameAndUserName = "Gabi",
                    Initials = "GM",
                    Description = "Heeeyaaaaaaaaaa",
                    ProfilePictureRGB = "00d450"
                },

                new SearchAddListItemViewModel
                {
                    NameAndUserName = "Gabi",
                    Initials = "GM",
                    Description = "Heeeyaaaaaaaaaa",
                    ProfilePictureRGB = "ff55ff"
                },

                new SearchAddListItemViewModel
                {
                    NameAndUserName = "Gabi",
                    Initials = "GM",
                    Description = "Heeeyaaaaaaaaaa",
                    ProfilePictureRGB = "ff0045"
                },

                new SearchAddListItemViewModel
                {
                    NameAndUserName = "Gabi",
                    Initials = "GM",
                    Description = "Heeeyaaaaaaaaaa",
                    ProfilePictureRGB = "00d045"
                }
            };
        }

        #endregion
    }
}
