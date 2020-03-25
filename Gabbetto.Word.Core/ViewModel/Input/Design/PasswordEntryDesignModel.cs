using System;
using System.Security;

namespace Fasseto.Word.Core
{
    ///<sumary>
    ///The desing time data for a <see cref="PasswordEntryViewModel"/>
    ///</sumary>
    public class PasswordEntryDesignModel : PasswordEntryViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of this design model
        /// </summary>
        public static PasswordEntryDesignModel Instance => new PasswordEntryDesignModel();

        #endregion

        #region Constructors

        ///<sumary>
        ///Default Constructor
        ///</sumary>
        public PasswordEntryDesignModel()
        {
            Label = "Name";
            FakePassword = "*******";            
        }

        #endregion
    }
}
