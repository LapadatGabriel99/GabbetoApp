using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media.Animation;
using Fasseto.Word.Core;
using System.ComponentModel;

namespace Fasseto.Word
{
    /// <summary>
    /// The base page for all pages to gain basic functionality
    /// </summary>
    public class BasePage : UserControl
    {
        #region Private Members

        /// <summary>
        /// The view model associated to this page
        /// </summary>
        private object _viewModel;

        #endregion

        #region Public Properties

        /// <summary>
        /// The view model associated to this page
        /// </summary>
        public object ViewModelObject
        {
            get { return _viewModel; }
            set
            {
                //if nothing changes return
                if (_viewModel == value)
                    return;

                //Update the viewModel
                _viewModel = value;

                // Fire the view model changed method
                OnViewModelChanged();

                //Set the data context for this page
                DataContext = _viewModel;
            }
        }

        /// <summary>
        /// The animation to play when the page is first loaded
        /// </summary>
        public PageAnimation PageLoadAnimation { get; set; } = PageAnimation.SlideAndFadeInFromRight;

        /// <summary>
        /// The animation to play when the page is unloaded
        /// </summary>
        public PageAnimation PageUnloadAnimation { get; set; } = PageAnimation.SlideAndFadeOutToLeft;

        /// <summary>
        /// The time any slide animation takes to complete
        /// </summary>
        public float SlideSeconds { get; set; } = 0.5f;

        /// <summary>
        /// A flag to indicate that we should animate out on load.
        /// Useful when we are moving a page to another frame
        /// </summary>
        public bool ShouldAnimateOut { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public BasePage()
        {
            //Don't animate in design time
            if (DesignerProperties.GetIsInDesignMode(this))
                return;

            //If we are animating in, hide to begin with 
            if (this.PageLoadAnimation != PageAnimation.None)
                this.Visibility = Visibility.Collapsed;

            //Listen out for the page loading
            this.Loaded += BasePage_Loaded;
        }

        #endregion

        #region Animation Load / UnLoad

        /// <summary>
        /// Once the page is loaded, perform an animation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BasePage_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            //If we are setup to animate out on load
            if (ShouldAnimateOut)
                //Animate out
                await AnimateOutAsync();
            //Otherwise...
            else
                //Animate the page in
                await AnimateInAsync();
        }

        /// <summary>
        /// Animates the page in
        /// </summary>
        /// <returns></returns>
        public async Task AnimateInAsync()
        {
            //Make sure we have something to animate
            if (this.PageLoadAnimation == PageAnimation.None)
                return;

            switch (this.PageLoadAnimation)
            {
                //If it is a slide in from right animation...
                case PageAnimation.SlideAndFadeInFromRight:

                    //we execute it async and wait for it to finish
                    await this.SlideAndFadeInAsync(AnimationSlideInDirection.Right, false, SlideSeconds, size: (int)Application.Current.MainWindow.Width);

                    break;
            }
        }

        /// <summary>
        /// Animates the page in
        /// </summary>
        /// <returns></returns>
        public async Task AnimateOutAsync()
        {
            ////Make sure we have something to animate
            if (this.PageUnloadAnimation == PageAnimation.None)
                return;

            switch (this.PageUnloadAnimation)
            {
                //If it is a slide out to left animation...
                case PageAnimation.SlideAndFadeOutToLeft:

                    //we execute it async and wait for it to finish
                    await this.SlideAndFadeOutAsync(AnimationSlideInDirection.Left, SlideSeconds);

                    break;
            }
        }

        #endregion

        #region Virtual Methods

        /// <summary>
        /// Fired when the current view model changes
        /// </summary>
        public virtual void OnViewModelChanged()
        {

        }

        #endregion
    }

    /// <summary>
    /// A base page with additional ViewModel support
    /// </summary>
    public class BasePage<TViewModel> : BasePage
        where TViewModel : BaseViewModel, new()
    {
        #region Public Properties        

        /// <summary>
        /// The view model associated to this page
        /// </summary>
        public TViewModel ViewModel
        {
            get => (TViewModel)ViewModelObject;
            set => ViewModelObject = value;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public BasePage() : base()
        {
            //Create a default view model
            this.ViewModel = IoC.Get<TViewModel>();

            this.DataContext = ViewModel;
        }

        /// <summary>
        /// Parameterize constructor
        /// </summary>
        /// <param name="specificViewModel">The specific view model to use, if any</param>
        public BasePage(TViewModel specificViewModel = null) : base()
        {
            //Set specific view model
            if (specificViewModel != null)
                ViewModel = specificViewModel;
            else
                //Create default view model
                ViewModel = IoC.Get<TViewModel>();

            this.DataContext = ViewModel;
        }

        #endregion       
    }
}
