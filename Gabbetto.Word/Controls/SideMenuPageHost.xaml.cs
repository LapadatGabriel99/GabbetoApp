using Fasseto.Word.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
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
    /// Interaction logic for SideMenuPageHost.xaml
    /// </summary>
    public partial class SideMenuPageHost : UserControl
    {
        #region Dependency Properties

        /// <summary>
        /// The current side menu page dependency property
        /// </summary>
        public SideMenuPage CurrentSideMenuPage
        {
            get { return (SideMenuPage)GetValue(CurrentSideMenuPageProperty); }
            set { SetValue(CurrentSideMenuPageProperty, value); }
        }

        /// <summary>
        /// Registers a <see cref="CurrentSideMenuPage"/> as a dependency property
        /// </summary>
        public static readonly DependencyProperty CurrentSideMenuPageProperty =
            DependencyProperty.Register(
                nameof(CurrentSideMenuPage), 
                typeof(SideMenuPage), 
                typeof(SideMenuPageHost),                 
                new UIPropertyMetadata(default(SideMenuPage), null, OnCurrentSideMenuPagePropertyChanged));

        /// <summary>
        /// The current side menu page view model dependency property
        /// </summary>
        public BaseViewModel CurrentSideMenuPageViewModel
        {
            get { return (BaseViewModel)GetValue(CurrentSideMenuPageViewModelProperty); }
            set { SetValue(CurrentSideMenuPageViewModelProperty, value); }
        }

        /// <summary>
        /// Registers a <see cref="CurrentSideMenuPageViewModel"/> as a dependency property
        /// </summary>
        public static readonly DependencyProperty CurrentSideMenuPageViewModelProperty =
            DependencyProperty.Register(
                nameof(CurrentSideMenuPageViewModel),
                typeof(BaseViewModel),
                typeof(SideMenuPageHost),
                new UIPropertyMetadata());

        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        public SideMenuPageHost()
        {
            InitializeComponent();

            // If we are in design time, just show the current page
            if (DesignerProperties.GetIsInDesignMode(this))
            {
                NewSideMenuPage.Content = IoC.ApplicationViewModel.CurrentSideMenuPage.ToSideMenuBasePage();
            }
        }

        #endregion

        #region Property Changed Event Handlers

        /// <summary>
        /// Called when the <see cref="CurrentSideMenuPage"/> value has changed
        /// </summary>
        /// <param name="d"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private static object OnCurrentSideMenuPagePropertyChanged(DependencyObject d, object value)
        {
            // Get current values
            var currentPage = (SideMenuPage)d.GetValue(CurrentSideMenuPageProperty);
            var currentPageViewModel = d.GetValue(CurrentSideMenuPageViewModelProperty);

            // Get the frames
            var oldPageFrame = (d as SideMenuPageHost).OldSideMenuPage;
            var newPageFrame = (d as SideMenuPageHost).NewSideMenuPage;

            // If the current side menu pages hasn't changed
            // Just update the view model
            if (newPageFrame.Content is SideMenuBasePage page &&
                page.ToSideMenuPage() == currentPage)
            {
                // Update the view model
                page.ViewModelObject = currentPageViewModel;

                return value;
            }

            // Store the current page content as the old page
            var oldPageContent = newPageFrame.Content;

            //Remove current page from new page frame
            newPageFrame.Content = null;

            // Move the previous page into the old frame page
            oldPageFrame.Content = oldPageContent;

            oldPageFrame.Content = null;

            // Set the new page content
            newPageFrame.Content = currentPage.ToSideMenuBasePage(currentPageViewModel);

            return value;
        }

        #endregion
    }
}
