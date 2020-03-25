using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fasseto.Word.Core
{
    /// <summary>
    /// The UI manager that handles any UI interactions in the application
    /// </summary>
    public interface IUIManager
    {
        /// <summary>
        /// Displays a simple message box to the user
        /// </summary>
        /// <param name="viewModel">The view model</param>
        /// <returns></returns>
        Task ShowMessage(MessageBoxDialogViewModel viewModel);        
    }
}
