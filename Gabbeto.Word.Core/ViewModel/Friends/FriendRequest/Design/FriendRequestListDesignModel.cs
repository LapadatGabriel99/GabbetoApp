using System;
using System.Collections.Generic;
using System.Text;

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

        }

        #endregion
    }
}
