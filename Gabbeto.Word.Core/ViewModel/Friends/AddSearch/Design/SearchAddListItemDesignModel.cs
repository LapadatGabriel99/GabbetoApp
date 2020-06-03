using System;
using System.Collections.Generic;
using System.Text;

namespace Fasseto.Word.Core
{
    /// <summary>
    /// A design time viewModel of <see cref="SearchAddListItemViewModel"/>
    /// </summary>
    public class SearchAddListItemDesignModel : SearchAddListItemViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of this view model
        /// </summary>
        public static SearchAddListItemDesignModel Instance => new SearchAddListItemDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public SearchAddListItemDesignModel()
        {
            Initials = "GM";
            NameAndUserName = "Gabi Lapadat (KGUltraz)";
            Description = "Hi there, I'm using Gabetto!";
            ProfilePictureRGB = "3099c5";
        }

        #endregion
    }
}
