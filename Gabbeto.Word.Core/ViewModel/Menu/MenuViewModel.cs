using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fasseto.Word.Core
{
    /// <summary>
    /// A view model for a menu
    /// </summary>
    public class MenuViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// A list of MenuItemViewModels
        /// </summary>
        public List<MenuItemViewModel> Items { get; set; }

        #endregion

        #region Consturctor

        /// <summary>
        /// Default Consturctor
        /// </summary>
        public MenuViewModel()
        {

        }

        #endregion
    }
}
