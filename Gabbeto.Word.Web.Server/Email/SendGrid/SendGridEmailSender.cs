using Fasseto.Word.Core;
using Newtonsoft.Json;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Gabbetto.Word.Web.Server
{
    /// <summary>
    /// Sends emails using the SendGrid service
    /// </summary>
    public class SendGridEmailSender : IEmailSender
    {
        public SendGridEmailSender()
        {

        }

        /// <summary>
        /// Sends an email with the given information
        /// </summary>
        /// <param name="details">The details about the email we send</param>
        /// <returns></returns>
        public async Task<SendEmailResponse> SendEmailAsync(SendEmailDetails details, object templateObject, string templateKey)
        {
            // Get the sender key
            var apiKey = IoC.Configuration["SendGridKey"];

            // Get a new grid client
            var client = new SendGridClient(apiKey);

            // Set the from details
            var from = new EmailAddress(details.FromEmail, details.FromName);

            // Set subject
            var subject = details.Subject;

            // Set to details
            var to = new EmailAddress(details.ToEmail, details.ToName);

            // Set the content
            var plainTextContent = details.Content;

            // Set the html content
            var htmlContent = details.Content;

            // Create the message
            var message = MailHelper.CreateSingleEmail(from, to, subject, details.IsHtml ? null : plainTextContent, details.IsHtml ? htmlContent : null);

            message.TemplateId = templateKey;            

            message.SetTemplateData(templateObject);

            // Sent the message
            var response = await client.SendEmailAsync(message);

            // If we succeeded
            if(response.StatusCode == System.Net.HttpStatusCode.Accepted)
            {
                // Return a successful response
                return new SendEmailResponse();
            }

            // If we get so far, it means we failed...

            try
            {
                // Get the result of the body
                var bodyResult = await response.Body.ReadAsStringAsync();

                // Deserialize the body result
                var sendGridResponse = JsonConvert.DeserializeObject<SendGridResponse>(bodyResult);

                // Add any errors to the response
                var errorResponse = new SendEmailResponse
                {
                    ErrorMessages = sendGridResponse.Errors.Select(e => e.Message).ToList()
                };

                // Make sure we have at least one error
                if(errorResponse.Succesful)
                {
                    errorResponse.ErrorMessages = new List<string> { "Unknown error from email service. Please contact us." };
                }

                return errorResponse;
            }
            catch(Exception ex)
            {
                // Break if we are debugging
                if(Debugger.IsAttached)
                {
                    var error = ex;
                    Debugger.Break();
                }

                // If something unexpected happened, return message
                return new SendEmailResponse
                {
                    ErrorMessages = new List<string> { "Unknown error occured" }
                };
            }            
        }
    }
}
