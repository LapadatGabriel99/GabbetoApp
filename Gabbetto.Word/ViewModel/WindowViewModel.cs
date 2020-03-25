using Fasetto.Word;
using Fasseto.Word.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Fasseto.Word
{
    /// <summary>
    /// The view model for the custom flat window
    /// </summary>
    public class WindowViewModel : BaseViewModel
    {
        #region Private Members

        private Window _window;

        /// <summary>
        /// The margin around the window to allow a drop shadow
        /// </summary>
        private int _outerMarginSize = 10;

        /// <summary>
        /// The radius of the edges of the window
        /// </summary>
        private int _windowRadius = 10;

        /// <summary>
        /// The dock position of the current window
        /// </summary>
        private WindowDockPosition _dockPosition = WindowDockPosition.Undocked;

        #endregion

        #region Public Properties

        /// <summary>
        /// The smallest width the window can have 
        /// </summary>
        public double WindowMinimumWidth { get; set; } = 800;

        /// <summary>
        /// The smalled height the window can have
        /// </summary>
        public double WindowMinimumHeight { get; set; } = 500;

        /// <summary>
        /// The padding of the inner content of the main window
        /// </summary>
        public Thickness InnerContentPadding { get; set; } = new Thickness(0);

        public bool Borderless { get { return (_window.WindowState == WindowState.Maximized || _dockPosition == WindowDockPosition.Undocked); } }

        /// <summary>
        /// The size of the resize border around the window
        /// </summary>
        //public int ResizeBorder { get; set; } = 6;//This reffers to the two sided arrow from when we hover around the edge of a window
        public int ResizeBorder { get { return Borderless ? 0 : 6; } }

        /// <summary>
        /// The size of the resize border around the window, taking into account the outer margin
        /// </summary>
        public Thickness ResizeBorderThickness { get { return new Thickness(ResizeBorder + OuterMarginSize); } }

        public Thickness OuterMarginSizeThickness { get { return new Thickness(OuterMarginSize); } }

        /// <summary>
        /// Returns the "default" windowOuterMargin unless the windows state is maximized
        /// </summary>
        public int OuterMarginSize
        {
            get
            {
                if (_window.WindowState == WindowState.Maximized)
                {
                    return 0;
                }
                else
                {
                    return _outerMarginSize;
                }
            }

            set
            {
                _outerMarginSize = value;
            }
        }

        public CornerRadius WindowCornerRadius { get { return new CornerRadius(WindowRadius); } }

        /// <summary>
        /// The height of the title/caption of the window
        /// </summary>
        public int TitleHeight { get; set; } = 42;

        public GridLength TitleHeightGridLenght { get { return new GridLength(TitleHeight + ResizeBorder); } }

        /// <summary>
        /// True if we should have a dimmed overlay on the window
        /// such as when a popup is visible or the window is not focused
        /// </summary>
        public bool DimmableOverlayVisible { get; set; }

        /// <summary>
        /// Returns the "default" windowRadius unless the windows state is maximized
        /// </summary>
        public int WindowRadius
        {
            get
            {
                if (_window.WindowState == WindowState.Maximized)
                {
                    return 0;
                }
                else
                {
                    return _windowRadius;
                }
            }

            set
            {
                _windowRadius = value;
            }
        }

        #endregion

        #region Commands

        /// <summary>
        /// The command to minimize the window
        /// </summary>
        public ICommand MinimizeCommand { get; set; }

        /// <summary>
        /// The command to maximize the window
        /// </summary>
        public ICommand MaximizeCommand { get; set; }

        /// <summary>
        /// The comand to close the window
        /// </summary>
        public ICommand CloseCommand { get; set; }

        /// <summary>
        /// The command to show the system menu of the window
        /// </summary>
        public ICommand MenuCommand { get; set; }

        #endregion

        #region Constructor
        /// <summary>
        /// Constructor that sets <see cref="Window"/> object
        /// </summary>
        public WindowViewModel(Window window)
        {
            _window = window;

            //Adding an event handler to our state-changed event
            _window.StateChanged += _window_StateChanged;

            //Create commands
            MinimizeCommand = new RelayCommand(() => ChangeWindowsToMinimizedState());
            MaximizeCommand = new RelayCommand(() => ChangeWindowsToMaximizedState());
            CloseCommand = new RelayCommand(() => CloseWindow());
            MenuCommand = new RelayCommand(() => ShowMenu());

            //Fix window resize issue
            WindowResizer windowResizer = new WindowResizer(_window);
        }

        #endregion

        #region EventHandlers

        /// <summary>
        /// This eventhandler is raised whenever the state of the windows is changed
        /// Ex: If we change from a normal state to a maximized state
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _window_StateChanged(object sender, EventArgs e)
        {
            //Fire off events for all properties that are affected by a resize
            OnPropertyChanged(nameof(Borderless));
            OnPropertyChanged(nameof(ResizeBorderThickness));
            OnPropertyChanged(nameof(OuterMarginSize));
            OnPropertyChanged(nameof(OuterMarginSizeThickness));
            OnPropertyChanged(nameof(WindowRadius));
            OnPropertyChanged(nameof(WindowCornerRadius));
        }

        #endregion

        #region Private Helpers

        /// <summary>
        /// Helper function that sets the windows state to minimized
        /// </summary>
        private void ChangeWindowsToMinimizedState()
        {
            _window.WindowState = WindowState.Minimized;
        }

        /// <summary>
        /// Helper function that sets the windows state to normal/maximized
        /// </summary>
        private void ChangeWindowsToMaximizedState()
        {
            if (_window.WindowState == WindowState.Normal)
            {
                _window.WindowState = WindowState.Maximized;
            }
            else if (_window.WindowState == WindowState.Maximized)
            {
                _window.WindowState = WindowState.Normal;
            }
        }

        private void CloseWindow()
        {
            _window.Close();
        }

        /// <summary>
        /// Gets the current mouse position of the screen
        /// </summary>
        /// <returns></returns>
        private Point GetMousePosition()
        {
            // Position of the mouse relative to the window
            var position = Mouse.GetPosition(_window);

            return new Point(position.X + _window.Left, position.Y + _window.Top);
        }

        private void ShowMenu()
        {
            SystemCommands.ShowSystemMenu(_window, GetMousePosition());
        }

        /// <summary>
        /// If the window resizes to a special position (docked or maximized)
        /// this will update all required property change events to set the borders and radius values
        /// </summary>
        private void WindowResized()
        {
            // Fire off events for all properties that are affected by a resize
            OnPropertyChanged(nameof(Borderless));
            //OnPropertyChanged(nameof(FlatBorderThickness));
            OnPropertyChanged(nameof(ResizeBorderThickness));
            OnPropertyChanged(nameof(OuterMarginSize));
            OnPropertyChanged(nameof(WindowRadius));
            OnPropertyChanged(nameof(WindowCornerRadius));
        }

        #endregion
    }
}
