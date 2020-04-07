﻿using System;
using System.Windows.Input;

namespace Fasseto.Word.Core
{
    ///<sumary>
    ///The view model for a text entry to edit a string value
    ///</sumary>
    public class TextEntryViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// The label to identify what this value is for
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// The current saved value
        /// </summary>
        public string OriginalText { get; set; }

        /// <summary>
        /// The current uncommit edited text
        /// </summary>
        public string EditedText { get; set; }

        /// <summary>
        /// A flag that indicates if the current text is in edit mode
        /// </summary>
        public bool Editing { get; set; }

        #endregion

        #region Public Commands

        /// <summary>
        /// The command that puts the control in edit mode
        /// </summary>
        public ICommand EditCommand { get; set; }

        /// <summary>
        /// The command that cancels out of edit mode
        /// </summary>
        public ICommand CancelCommand { get; set; }

        /// <summary>
        /// The command that commits the edits and saves the value
        /// as well as goes back to non-edit mode
        /// </summary>
        public ICommand SaveCommand { get; set; }

        #endregion

        #region Constructors

        ///<sumary>
        ///Default Constructor
        ///</sumary>
        public TextEntryViewModel()
        {
            //Create commands
            EditCommand = new RelayCommand(() => Edit());
            CancelCommand = new RelayCommand(() => Cancel());
            SaveCommand = new RelayCommand(() => Save());
        }

        #endregion

        #region Command Helpers

        /// <summary>
        /// Puts the control in edit mode
        /// </summary>
        private void Edit()
        {
            //Set the edited text to the current value
            EditedText = OriginalText;

            //Go into edit mode
            Editing = true;
        }

        /// <summary>
        /// Cancels out of edit mode
        /// </summary>
        private void Cancel()
        {
            Editing = false;
        }

        /// <summary>
        /// Commits the content and exits out of edit mode
        /// </summary>
        private void Save()
        {
            //TODO Content
            OriginalText = EditedText;

            Editing = false;

            //NOTE: Small bug here, when pressing enter the content of edited text does not change
        }

        #endregion
    }
}