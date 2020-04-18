using Fasseto.Word.Core;
using Gabbeto.Word.Relational;
using ProjectUniversal;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Fasseto.Word
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Custom startup so we load our IoC immediately before anything else
        /// </summary>
        /// <param name="e"></param>
        protected override async void OnStartup(StartupEventArgs e)
        {
            //Let the base app do what it needs
            base.OnStartup(e);

            //Setup main application
            await ApplicationSetup();

            // Log it            
            IoC.Logger.Log("This is Informative", LogLevel.Informative);

            // Set the application view model based on if we are logged in...
            if (await IoC.ClientDataStore.HasCredentialsAsync())
            {
                // If we are logged in...
                // Go to chat page
                IoC.ApplicationViewModel.GoToPage(ApplicationPage.Chat);

                // Load the initial user profile settings
                await IoC.SettingsViewModel.LoadAsync();
            }
            else
            {
                // If there is no current user on the local store...
                // Go to login page
                IoC.ApplicationViewModel.GoToPage(ApplicationPage.Login);
            }                      

            //Show the main window
            Current.MainWindow = new MainWindow();
            Current.MainWindow.Show();
        }

        /// <summary>
        /// Configures our application ready for use
        /// </summary>
        private async Task ApplicationSetup()
        {
            // Setup of ProjectUniversal framework
            new DefaultFrameworkConstruction()
                .UseFileLogger()
                .UseDataClientStore()
                .Build();            

            //Setup IoC
            IoC.Setup();

            //Bind a logger
            IoC.Kernel.Bind<ILogFactory>().ToConstant(new BaseLogFactory(new[]
            { 
                //TODO: Add application settings so we can add/edit a log location
                //      For now just log to the path where this app is running
                new Core.FileLogger("log.txt")
            }));

            //Bind a task manager
            IoC.Kernel.Bind<ITaskManager>().ToConstant(new TaskManager());

            //Bind a file manager
            IoC.Kernel.Bind<IFileManager>().ToConstant(new FileManager());

            //Bind UI Manager
            IoC.Kernel.Bind<IUIManager>().ToConstant(new UIManager());

            // Ensure the client data store
            await IoC.ClientDataStore.EnsureDataStoreAsync();
        }        
    }
}
