using System;

namespace Fasseto.Word.Core
{
    ///<sumary>
    /// The result of a successful save request via API
    ///</sumary>
    public class OptionalCredentialsResultApiModel
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

        #endregion

        #region Constructors

        ///<sumary>
        ///Default Constructor
        ///</sumary>
        public OptionalCredentialsResultApiModel()
        {

        }

        #endregion
    }
}
