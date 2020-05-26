using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Fasseto.Word.Core
{
    /// <summary>
    /// The view model for the search/add friends control
    /// </summary>
    public class SearchAddListViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// The search/add list items for the list control
        /// </summary>
        public ObservableCollection<SearchAddListItemViewModel> Items; 

        #endregion
    }
}
