using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fasseto.Word.Core
{
    /// <summary>
    /// A design model for a <see cref="MenuItemViewModel"/>
    /// </summary>
    public class MenuItemDesignModel : MenuItemViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of this design model
        /// </summary>
        public static MenuItemDesignModel Instance => new MenuItemDesignModel();

        #endregion

        #region Consturctor

        /// <summary>
        /// Default Consturctor
        /// </summary>
        public MenuItemDesignModel()
        {
            Text = "Hello World";
            Icon = IconType.File;
        }

        #endregion
    }
}
