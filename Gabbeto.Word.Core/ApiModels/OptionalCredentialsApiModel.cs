using System;

namespace Fasseto.Word.Core
{
    ///<sumary>
    /// The credentials for an API client to commit the optional credentials to the server
    ///</sumary>
    public class OptionalCredentialsApiModel
    {
        #region Public Properties

        /// <summary>
        /// The users email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// The users first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// The users last name
        /// </summary>
        public string LastName { get; set; }

        #endregion

        #region Constructors

        ///<sumary>
        ///Default Constructor
        ///</sumary>
        public OptionalCredentialsApiModel()
        {

        }

        #endregion
    }
}
