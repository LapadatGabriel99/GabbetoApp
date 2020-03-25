using System;

namespace Fasseto.Word.Core
{
    ///<sumary>
    ///The design time data for a <see cref="SettingsViewModel/>
    ///</sumary>
    public class SettingsDesignModel : SettingsViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of this design model
        /// </summary>
        public static SettingsDesignModel Instance => new SettingsDesignModel();

        #endregion

        #region Constructors

        ///<sumary>
        ///Default Constructor
        ///</sumary>
        public SettingsDesignModel()
        {
            Name = new TextEntryViewModel { Label = "Name", OriginalText = "Gabi Lapadat" };
            UserName = new TextEntryViewModel { Label = "UserName", OriginalText = "gabi" };
            Password = new PasswordEntryDesignModel { Label = "Password", FakePassword = "*******" };
            Email = new TextEntryViewModel { Label = "Email", OriginalText = "blabla@gmail.com" };
        }

        #endregion
    }
}
