using System;

namespace Fasseto.Word.Core
{
    ///<sumary>
    /// The credentials for an API client to log into the server and receive a token back
    ///</sumary>
    public class LoginCredentialsApiModel
    {
        #region Public Properties

        /// <summary>
        /// The users username
        /// </summary>
        public string UsernameOrEmail { get; set; }

        /// <summary>
        /// The users password
        /// </summary>
        public string Password { get; set; }

        #endregion

        #region Constructors

        ///<sumary>
        ///Default Constructor
        ///</sumary>
        public LoginCredentialsApiModel()
        {

        }

        #endregion
    }
}
