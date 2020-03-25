using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Fasseto.Word
{
    /// <summary>
    /// The view model for the custom dialog window
    /// </summary>
    public class DialogWindowViewModel : WindowViewModel
    {
        #region Public Properties

        /// <summary>
        /// The title of this dialog window
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The content to use inside the dialog
        /// </summary>
        public Control Content { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="window"></param>
        public DialogWindowViewModel(Window window)
            : base(window)
        {
            //Make window minimum size smaller
            WindowMinimumHeight = 100;
            WindowMinimumWidth = 250;

            //Make title bar smaller
            TitleHeight = 30;
        }

        #endregion
    }
}
