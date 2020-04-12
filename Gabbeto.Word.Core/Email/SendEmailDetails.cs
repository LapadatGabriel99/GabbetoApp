using System;

namespace Fasseto.Word.Core
{
    ///<sumary>
    /// The details about the email we send
    ///</sumary>
    public class SendEmailDetails
    {
        #region Public Properties

        /// <summary>
        /// The name of the sender
        /// </summary>
        public string FromName { get; set; }

        /// <summary>
        /// The name of the sender
        /// </summary>
        public string FromEmail { get; set; }

        /// <summary>
        /// The name of the receiver
        /// </summary>
        public string ToName { get; set; }

        /// <summary>
        /// The name of the receiver
        /// </summary>
        public string ToEmail { get; set; }

        /// <summary>
        /// The email subject
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// The body of the content
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Indicates if the content is an Html email
        /// </summary>
        public bool IsHtml { get; set; }

        #endregion

        #region Constructors

        ///<sumary>
        /// Default Constructor
        ///</sumary>
        public SendEmailDetails()
        {

        }

        #endregion
    }
}
