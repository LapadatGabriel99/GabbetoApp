using System;
using System.Collections.Generic;
using System.Text;

namespace Fasseto.Word.Core
{
    /// <summary>
    /// The design time view model for the <see cref="SearchItemViewModel"/>
    /// </summary>
    public class SearchItemDesignModel : SearchItemViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of this class
        /// </summary>
        public static SearchItemDesignModel Instance => new SearchItemDesignModel();

        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        public SearchItemDesignModel()
        {

        }

        #endregion
    }
}
