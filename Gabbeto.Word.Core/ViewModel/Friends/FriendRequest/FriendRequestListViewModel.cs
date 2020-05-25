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

        public ObservableCollection<FriendRequestListItemViewModel> Items;

        #endregion
    }
}
