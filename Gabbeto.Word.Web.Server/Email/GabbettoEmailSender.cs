using Fasseto.Word.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gabbetto.Word.Web.Server
{
    /// <summary>
    /// Handles sending specific emails to the server
    /// </summary>
    public static class GabbettoEmailSender
    {
        /// <summary>
        /// Sends a verification email to the specified user
        /// </summary>
        /// <param name="displayName">The users display name( the first name)</param>
        /// <param name="email">The email address to send to</param>
        /// <param name="verificationUrl">The URL the user needs to click to verify their email</param>
        /// <returns></returns>
        public static async Task<SendEmailResponse> SendUserVerificationEmailAsync(string displayName, string email, string verificationUrl)
        {
            return await IoC.EmailSender.SendEmailAsync(new Fasseto.Word.Core.SendEmailDetails
            {                
                IsHtml = true,
                FromEmail = IoC.Configuration["GabbetoEmailSettings:SendEmailFromEmail"],
                FromName = IoC.Configuration["GabbetoEmailSettings:SendEmailFromName"],
                ToEmail = email,
                ToName = displayName,
                Subject = "Verify Your Email - Gabbeto Word"
            }, new VerificationEmailObjectTemplate
            {
                Title = "Verify Email",
                Content1 = $"Hi { displayName ?? "stranger"}",
                Content2 = "Please click the link below in order to verify",
                ButtonText = "Verify Email",
                ButtonUrl = verificationUrl
            },
            IoC.Configuration["EmailTemplates:VerificationTemplateId"]);
        }
    }
}
