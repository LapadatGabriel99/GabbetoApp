using Ninject;
using ProjectUniversal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fasseto.Word.Core
{
    public static class IoC
    {
        #region Public Properties

        /// <summary>
        /// The kernal for our IoC container
        /// </summary>
        public static IKernel Kernel { get; private set; } = new StandardKernel();

        /// <summary>
        /// A shotcut to access the <see cref="IUIManager"/>
        /// </summary>
        public static IUIManager UI => IoC.Get<IUIManager>();

        /// <summary>
        /// A shortcut to access the <see cref="ILogFactory"/>
        /// </summary>
        public static ILogFactory Logger => IoC.Get<ILogFactory>();

        /// <summary>
        /// A shortcut to acces the <see cref="IFileManager"/>
        /// </summary>
        public static IFileManager File => IoC.Get<IFileManager>();

        /// <summary>
        /// A shortcut to access the <see cref="ITaskManager"/>
        /// </summary>
        public static ITaskManager Task => IoC.Get<ITaskManager>();

        /// <summary>
        /// A shortcut to access the <see cref="Fasseto.Word.Core.ApplicationViewModel"/>
        /// </summary>
        public static ApplicationViewModel ApplicationViewModel => IoC.Get<ApplicationViewModel>();

        /// <summary>
        /// A shortcut to access the <see cref="Fasseto.Word.Core.SettingsViewModel"/>
        /// </summary>
        public static SettingsViewModel SettingsViewModel => IoC.Get<SettingsViewModel>();

        /// <summary>
        /// A shortcut to access the <see cref="Fasseto.Word.Core.SideMenuViewModel"/>
        /// </summary>
        public static SideMenuViewModel SideMenuViewModel => IoC.Get<SideMenuViewModel>();

        /// <summary>
        /// A shortcut to access the <see cref="IClientDataStore"/> service
        /// </summary>
        public static IClientDataStore ClientDataStore => (IClientDataStore)Framework.Provider.GetService(typeof(IClientDataStore));

        #endregion


        #region Construction

        /// <summary>
        /// Setups the IoC container, binds all information required
        /// NOTE: Must be called as soon as your application starts up to ensure all
        ///       services can be found
        /// </summary>       
        public static void Setup()
        {
            //Bind all required view models
            BindViewModels();
        }

        /// <summary>
        /// Binds all singleton view models
        /// </summary>
        private static void BindViewModels()
        {
            //Bind to a single instance of ApplicationViewModel
            Kernel.Bind<ApplicationViewModel>().ToConstant(new ApplicationViewModel());

            //Bind to a single instance of SettingsViewModel
            Kernel.Bind<SettingsViewModel>().ToConstant(new SettingsViewModel());

            //Bind to a single instance of SideMenuViewModel
            Kernel.Bind<SideMenuViewModel>().ToConstant(new SideMenuViewModel());
        }

        #endregion


        /// <summary>
        /// Get a service from the IoC of the specified type
        /// </summary>
        /// <typeparam name="T"> Type to get </typeparam>
        /// <returns></returns>
        public static T Get<T>()
        {
            return Kernel.Get<T>();
        }        
    }
}
