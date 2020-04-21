using System;
using System.Collections.Generic;
using System.Text;

namespace Fasseto.Word.Core
{
    /// <summary>
    /// The details to change for a users password from an API call
    /// </summary>
    public class UpdateUserPasswordApiModel
    {
        #region Public Properties

        /// <summary>
        /// The users current password
        /// </summary>
        public string CurrentPassword { get; set; }

        /// <summary>
        /// The users new password
        /// </summary>
        public string NewPassword { get; set; }

        #endregion

        #region Constructor

        public UpdateUserPasswordApiModel()
        {

        } 

        #endregion
    }
}
