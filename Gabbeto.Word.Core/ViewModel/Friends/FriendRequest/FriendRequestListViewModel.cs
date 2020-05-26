using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Fasseto.Word.Core
{
    /// <summary>
    /// The view model for the friend request control
    /// </summary>
    public class FriendRequestListViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// The friend request list items for the list control
        /// </summary>
        public ObservableCollection<FriendRequestListItemViewModel> Items;

        #endregion
    }
}
