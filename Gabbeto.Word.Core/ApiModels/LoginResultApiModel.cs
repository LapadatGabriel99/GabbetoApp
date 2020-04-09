using System;

namespace Fasseto.Word.Core
{
    ///<sumary>
    /// The result of a successful login request via API
    ///</sumary>
    public class LoginResultApiModel : IDefaultAuthenticationResult
    {
        #region Public Properties

        /// <summary>
        /// The authentication token used to stay authenticated through future requests
        /// </summary>
        public string Token { get; set; }

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
        public LoginResultApiModel()
        {

        }

        #endregion
    }
}
