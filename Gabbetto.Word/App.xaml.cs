using Fasseto.Word.Core;
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
        /// Custom startup so we load our IoC immediatly before anything else
        /// </summary>
        /// <param name="e"></param>
        protected override void OnStartup(StartupEventArgs e)
        {
            //Let the base app do what it needs
            base.OnStartup(e);

            //Setup main application
            ApplicationSetup();

            // Log it            
            IoC.Logger.Log("This is Informative", LogLevel.Informative);

            // A small example test to check our IoC.Task.Run()
            // which is a wrapper that logs any possible errors to a file/console/Debug
            //IoC.Task.Run(() =>
            //{
            //    throw new ArgumentNullException("oooopsieeee");
            //});

            //Show the main window
            Current.MainWindow = new MainWindow();
            Current.MainWindow.Show();
        }

        /// <summary>
        /// Configures our application ready for use
        /// </summary>
        private void ApplicationSetup()
        {
            // Setup of ProjectUniversal framework
            new DefaultFrameworkConstruction()
                .UseFileLogger()
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
            IoC.Kernel.Bind<IUIManager>().ToConstant(new UIManager());//TODO: Uncomment this line after port completion
        }
    }
}
