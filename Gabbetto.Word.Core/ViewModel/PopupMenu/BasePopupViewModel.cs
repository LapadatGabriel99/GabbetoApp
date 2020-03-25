using Fasseto.Word.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Fasseto.Word
{
    /// <summary>
    /// A view model any popup menus
    /// </summary>
    public class BasePopupViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// The background color of the bubble, in ARGB value
        /// </summary>
        public string BubbleBackground { get; set; }
        
        /// <summary>
        /// The alignment for the bubble arrow
        /// </summary>
        public ElementHorizontalAlignment ArrowAlignment { get; set; }

        /// <summary>
        /// The menu for this popup menu
        /// </summary>
        public BaseViewModel Content { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        public BasePopupViewModel()
        {
            //Set default values
            BubbleBackground = "ffffff";
            ArrowAlignment = ElementHorizontalAlignment.Left;
        }

        #endregion
    }
}
