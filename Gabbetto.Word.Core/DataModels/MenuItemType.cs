using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fasseto.Word.Core
{
    /// <summary>
    /// The types of items for a menu
    /// </summary>
    public enum MenuItemType
    {
        /// <summary>
        /// Shows the menu and icon
        /// </summary>
        TextAndIcon = 0,

        /// <summary>
        /// Shows a simple divider between the menu items
        /// </summary>
        Divider = 1,

        /// <summary>
        /// Shows the menu text asa a header
        /// </summary>
        Header = 2
    }
}
