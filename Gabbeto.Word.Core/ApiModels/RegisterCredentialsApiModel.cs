using System;

namespace Fasseto.Word.Core
{
    ///<sumary>
    /// The credentials for an API client to register on the server
    ///</sumary>
    public class RegisterCredentialsApiModel
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
        /// The users user name
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// The users email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// The users password
        /// </summary>
        public string Password { get; set; }

        #endregion

        #region Constructors

        ///<sumary>
        ///Default Constructor
        ///</sumary>
        public RegisterCredentialsApiModel()
        {

        }

        #endregion
    }
}
