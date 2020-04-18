using System;

namespace Fasseto.Word.Core
{
    ///<sumary>
    /// The details to change for a user profile from an API client call
    ///</sumary>
    public class UpdateUserProfileApiModel
    {
        #region Public Properties

        /// <summary>
        /// The new first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// The new last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// The new email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// The new username
        /// </summary>
        public string Username { get; set; }

        #endregion

        #region Constructors

        ///<sumary>
        ///Default Constructor
        ///</sumary>
        public UpdateUserProfileApiModel()
        {

        }

        #endregion
    }
}
