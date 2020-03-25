using Fasseto.Word.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Fasseto.Word
{
    /// <summary>
    /// The base class for any content that is being used inside of a <see cref="DialogWindow"/>
    /// </summary>
    public class BaseDialogUserControl : UserControl
    {
        #region Private Members

        /// <summary>
        /// The dialog window that will be cotained within
        /// </summary>
        private DialogWindow _dialogWindow;

        #endregion

        #region Public Commands

        /// <summary>
        /// The command to close the dialog
        /// </summary>
        public ICommand CloseCommand { get; private set; }

        #endregion

        #region Public Properties

        /// <summary>
        /// The minimum width of this dialog
        /// </summary>
        public int WindowMinimumWidth { get; set; } = 250;

        /// <summary>
        /// The minimum height of this dialog
        /// </summary>
        public int WindowMinimumHeight { get; set; } = 100;

        /// <summary>
        /// The height of the title bar
        /// </summary>
        public int TitleHeight { get; set; } = 30;

        /// <summary>
        /// The title for this dialog
        /// </summary>
        public string Title { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        public BaseDialogUserControl()
        {
            //Create a new dialog window
            _dialogWindow = new DialogWindow();

            //Setup its viewModel
            _dialogWindow.ViewModel = new DialogWindowViewModel(_dialogWindow);

            // Create close command
            CloseCommand = new RelayCommand(() => _dialogWindow.Close());
        }

        #endregion

        #region Public Dialog Show Methods

        /// <summary>
        /// Displays a single message box for the user
        /// </summary>
        /// <param name="viewModel">The view model</param>
        /// <param name="T">The view model type for this control</param>
        /// <returns></returns>
        public Task ShowDialog<T>(T viewModel)
            where T : BaseDialogViewModel
        {
            //Create a task to await the dialog closing
            var taskCompletionSource = new TaskCompletionSource<bool>();

            Application.Current.Dispatcher.Invoke(() =>
            {
                try
                {
                    //Match controls expected sizes to the dialog windows view model
                    _dialogWindow.ViewModel.WindowMinimumHeight = WindowMinimumHeight;
                    _dialogWindow.ViewModel.WindowMinimumWidth = WindowMinimumWidth;
                    _dialogWindow.ViewModel.TitleHeight = TitleHeight;
                    _dialogWindow.ViewModel.Title = string.IsNullOrEmpty(viewModel.Title) ? Title : viewModel.Title;

                    //Set this control to the dialog window content
                    _dialogWindow.ViewModel.Content = this;

                    //Setup this controls data context binding to the view model
                    DataContext = viewModel;

                    //Set the owner as the main window
                    _dialogWindow.Owner = Application.Current.MainWindow;

                    //Show in the center of the parent
                    _dialogWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;

                    //Show the dialog
                    _dialogWindow.ShowDialog();
                }
                finally
                {
                    // Let the caller know we finished
                    taskCompletionSource.TrySetResult(true);
                }
            });

            //Return a task
            return taskCompletionSource.Task;
        }

        #endregion
    }
}
