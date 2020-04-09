using Fasseto.Word.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Fasseto.Word
{
    /// <summary>
    /// Interaction logic for PageHost.xaml
    /// </summary>
    public partial class PageHost : UserControl
    {

        #region Dependency Properties

        public ApplicationPage CurrentPage
        {
            get { return (ApplicationPage)GetValue(CurrentPageProperty); }
            set { SetValue(CurrentPageProperty, value); }
        }

        /// <summary>
        /// Registers a <see cref="CurrentPage"/> as a dependency property
        /// </summary>
        public static readonly DependencyProperty CurrentPageProperty =
            DependencyProperty.Register(
                nameof(CurrentPage), 
                typeof(ApplicationPage), 
                typeof(PageHost), 
                new UIPropertyMetadata(default(ApplicationPage), null, OnCurrentPagePropertyChanged));

        public BaseViewModel CurrentPageViewModel
        {
            get { return (BaseViewModel)GetValue(CurrentPageViewModelProperty); }
            set { SetValue(CurrentPageViewModelProperty, value); }
        }

        /// <summary>
        /// Registers a <see cref="CurrentPage"/> as a dependency property
        /// </summary>
        public static readonly DependencyProperty CurrentPageViewModelProperty =
            DependencyProperty.Register(
                nameof(CurrentPageViewModel), 
                typeof(BaseViewModel), 
                typeof(PageHost), 
                new UIPropertyMetadata());


        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public PageHost()
        {
            InitializeComponent();

            //If we are in Design time, then show the current page
            //as the dependency property does not fire
            if (DesignerProperties.GetIsInDesignMode(this))
            {
                NewPage.Content = IoC.ApplicationViewModel.CurrentPage.ToBasePage();
            }
        }

        #endregion

        #region Property Changed Event Handlers

        /// <summary>
        /// Called when the <see cref="CurrentPage"/> value has changed
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static object OnCurrentPagePropertyChanged(DependencyObject d, object value)
        {           
            //Get current values
            var currentPage = (ApplicationPage)d.GetValue(CurrentPageProperty);           
            var currentPageViewModel = d.GetValue(CurrentPageViewModelProperty);

            //Get the frames
            var newPageFrame = (d as PageHost).NewPage;
            var oldPageFrame = (d as PageHost).OldPage;

            // If the current page hasn't changed
            // just update the view model
            if (newPageFrame.Content is BasePage page &&
                page.ToApplicationPage() == currentPage)
            {
                //Update the view model
                page.ViewModelObject = currentPageViewModel;

                return value;
            }

            //Store the current page content as the old page
            var oldPageContent = newPageFrame.Content;

            //Remove current page from new page frame
            newPageFrame.Content = null;

            //Move the previous page into the old page frame
            oldPageFrame.Content = oldPageContent;

            // Animate out previous page
            if (oldPageContent is BasePage oldPage && oldPage != null)
            {
                //Tell old page to animate out
                oldPage.ShouldAnimateOut = true;

                Task.Delay((int)(oldPage.SlideSeconds * 1000)).ContinueWith(t =>
                {
                    Application.Current.Dispatcher.Invoke(() => oldPageFrame.Content = null);
                });
            }

            //Set the new page content
            newPageFrame.Content = currentPage.ToBasePage(currentPageViewModel);

            return value;
        }

        /// <summary>
        /// Called when the <see cref="CurrentPageViewModel"/> value has changed
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void OnCurrentPageViewModelPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

        }

        #endregion
    }
}
