using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fasseto.Word.Core
{
    /// <summary>
    /// Handles sending emails
    /// </summary>
    public interface IEmailSender
    {
        /// <summary>
        /// Sends an email with the given information
        /// </summary>
        /// <param name="details">The details about the email we send</param>
        /// <returns></returns>
        Task<SendEmailResponse> SendEmailAsync(SendEmailDetails details, object templateObject, string templateKey);
    }
}
