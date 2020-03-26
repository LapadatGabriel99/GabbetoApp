using System;

namespace Fasseto.Word.Core
{
    ///<sumary>
    ///The desing time data for a <see cref="TextEntryViewModel"/>
    ///</sumary>
    public class TextEntryDesignModel : TextEntryViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of this design model
        /// </summary>
        public static TextEntryDesignModel Instance => new TextEntryDesignModel();

        #endregion

        #region Constructors

        ///<sumary>
        ///Default Constructor
        ///</sumary>
        public TextEntryDesignModel()
        {
            Label = "Name";
            OriginalText = "Gabi Lapadat";
            EditedText = "Editing :)";
        }

        #endregion
    }
}
