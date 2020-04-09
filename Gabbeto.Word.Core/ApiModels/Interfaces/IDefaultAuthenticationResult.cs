using System;
using System.Collections.Generic;
using System.Text;

namespace Fasseto.Word.Core
{
    /// <summary>
    /// Represents a basic API result from an authentication API
    /// It contains very generic, non specific data 
    /// </summary>
    public interface IDefaultAuthenticationResult
    {
        /// <summary>
        /// The authentication token used to stay authenticated through future requests
        /// </summary>
        string Token { get; set; }

        /// <summary>
        /// The users first name
        /// </summary>
        string FirstName { get; set; }

        /// <summary>
        /// The users last name
        /// </summary>
        string LastName { get; set; }

        /// <summary>
        /// The users user name
        /// </summary>
        string Username { get; set; }

        /// <summary>
        /// The users email
        /// </summary>
        string Email { get; set; }        
    }
}
