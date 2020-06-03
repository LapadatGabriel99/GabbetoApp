using System;
using System.Collections.Generic;
using System.Text;

namespace Fasseto.Word.Core
{
    /// <summary>
    /// A design time view model of <see cref="FriendRequestListItemViewModel"/>
    /// </summary>
    public class FriendRequestListItemDesignModel : FriendRequestListItemViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of this viewModel
        /// </summary>
        public static FriendRequestListItemDesignModel Instance => new FriendRequestListItemDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public FriendRequestListItemDesignModel()
        {
            Initials = "GM";
            NameAndUserName = "Gabi Lapadat (KGUltraz)";            
            ProfilePictureRGB = "3099c5";
        }

        #endregion
    }
}
