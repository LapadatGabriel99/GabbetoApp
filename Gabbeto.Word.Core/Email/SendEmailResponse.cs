using System;
using System.Collections.Generic;

namespace Fasseto.Word.Core
{
    ///<sumary>
    /// A response from a SendEmail call from a <see cref="IEmailSender"/>
    ///</sumary>
    public class SendEmailResponse
    {
        #region Public Properties

        /// <summary>
        /// True if we don't have any error messages
        /// </summary>
        public bool Succesful
        {
            get
            {
                if (ErrorMessages == null)
                    return true;
                else
                {
                    if(ErrorMessages.Count <= 0)
                    {
                        return true;
                    }

                    return false;
                }
            }
        }

        /// <summary>
        /// The error message if the sending failed
        /// </summary>
        public List<string> ErrorMessages { get; set; }

        #endregion

        #region Constructors

        ///<sumary>
        ///Default Constructor
        ///</sumary>
        public SendEmailResponse()
        {

        }

        #endregion
    }
}
