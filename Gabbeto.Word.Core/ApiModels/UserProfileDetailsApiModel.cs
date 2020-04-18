using System;

namespace Fasseto.Word.Core
{
    ///<sumary>
    /// The current user profile details
    ///</sumary>
    public class UserProfileDetailsApiModel
    {
        #region Public Properties       

        /// <summary>
        /// The users first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// The users last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// The users username
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// The users email
        /// </summary>
        public string Email { get; set; }

        #endregion

        #region Constructors

        ///<sumary>
        ///Default Constructor
        ///</sumary>
        public UserProfileDetailsApiModel()
        {

        }

        #endregion
    }
}
