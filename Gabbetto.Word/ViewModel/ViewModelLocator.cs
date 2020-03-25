using Fasseto.Word.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fasseto.Word
{
    /// <summary>
    /// Locates view models from the IoC for use in binding in xaml files
    /// </summary>
    public class ViewModelLocator
    {
        #region Public Properties

        /// <summary>
        /// The singleton instance of the locator
        /// </summary>
        public static ViewModelLocator Instance { get; private set; } = new ViewModelLocator();

        /// <summary>
        /// The application view model
        /// </summary>
        public static ApplicationViewModel ApplicationViewModel => IoC.Get<ApplicationViewModel>();

        /// <summary>
        /// The settings view model
        /// </summary>
        public static SettingsViewModel SettingsViewModel => IoC.SettingsViewModel;

        #endregion
    }
}
