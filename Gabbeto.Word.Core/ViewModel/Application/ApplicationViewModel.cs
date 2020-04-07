﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fasseto.Word.Core
{
    /// <summary>
    /// The app state as a view model
    /// </summary>
    public class ApplicationViewModel : BaseViewModel
    {
        /// <summary>
        /// The current page of the application
        /// </summary>
        public ApplicationPage CurrentPage { get; private set; } = ApplicationPage.Login;

        /// <summary>
        /// The view model to use for the current page when the CurrentPage changes
        /// NOTE: This is not a live up-to-date view model of the current page
        ///       it is simply used to set the view model of the current page
        ///       at the time it changes
        /// </summary>
        public BaseViewModel CurrentPageViewModel { get; set; }

        /// <summary>
        /// True if the side menu should be shown
        /// </summary>
        public bool SideMenuVisible { get; set; } = false;

        /// <summary>
        /// True if the settings menu should be shown
        /// </summary>
        public bool SettingsMenuVisible { get; set; } = false;

        /// <summary>
        /// Navigate to the specified page
        /// </summary>
        /// <param name="page">The page to go to</param>
        public void GoToPage(ApplicationPage page, BaseViewModel viewModel = null)
        {
            //Always hide settings menu when going to different page
            SettingsMenuVisible = false;

            //Set the view model
            CurrentPageViewModel = viewModel;

            //Set the current page to the passed value
            CurrentPage = page;

            //Fire off a CurrentPage changed event
            OnPropertyChanged(nameof(CurrentPage));

            //Show menu or not?
            if (page == ApplicationPage.Chat)
                SideMenuVisible = true;
            else
                SideMenuVisible = false;
        }
    }
}