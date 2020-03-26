using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fasseto.Word.Core
{
    /// <summary>
    /// A design model for a <see cref="MenuViewModel"/>
    /// </summary>
    public class MenuDesignModel : MenuViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of this design model
        /// </summary>
        public static MenuDesignModel Instance => new MenuDesignModel();

        #endregion

        #region Consturctor

        /// <summary>
        /// Default Consturctor
        /// </summary>
        public MenuDesignModel()
        {
            Items = new List<MenuItemViewModel>
            {
                new MenuItemViewModel
                {
                    Type = MenuItemType.Header,
                    Text = "Design time header...",
                    Icon = IconType.File
                },

                new MenuItemViewModel
                {
                    Text = "Menu Item 1",
                    Icon = IconType.File,
                },

                new MenuItemViewModel
                {
                    Text = "Menu Item 2",
                    Icon = IconType.Picture
                },
            };
        }

        #endregion
    }
}
