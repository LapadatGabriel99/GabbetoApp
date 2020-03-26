using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fasseto.Word.Core
{
    public class ChatAttachmentPopupMenuViewModel : BasePopupViewModel
    {
        #region Public Properties


        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        public ChatAttachmentPopupMenuViewModel()
        {
            Content = new MenuViewModel
            {
                Items = new List<MenuItemViewModel>
                {
                         new MenuItemViewModel
                    {
                        Type = MenuItemType.Header,
                        Text = "Attach a file...",
                        Icon = IconType.File
                    },

                    new MenuItemViewModel
                    {
                        Text = "From Computer",
                        Icon = IconType.File,
                    },

                    new MenuItemViewModel
                    {
                        Text = "From Pictures",
                        Icon = IconType.Picture
                    },
                }
            };
        }

        #endregion
    }
}
