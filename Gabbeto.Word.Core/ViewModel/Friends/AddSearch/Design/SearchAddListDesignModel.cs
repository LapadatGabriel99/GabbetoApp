using System;
using System.Collections.Generic;
using System.Text;

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

        }

        #endregion
    }
}
