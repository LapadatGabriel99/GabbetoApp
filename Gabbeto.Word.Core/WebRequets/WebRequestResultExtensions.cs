using System;
using System.Threading.Tasks;
using ProjectUniversal;

namespace Fasseto.Word.Core
{
    /// <summary>
    /// Extension methods for <see cref="WebRequestResult{T}"/>
    /// </summary>
    public static class WebRequestResultExtensions
    {
        /// <summary>
        /// Checks the web request for any errors, displays them if there are any
        /// </summary>
        /// <typeparam name="T">The type of WebRequestResult</typeparam>
        /// <typeparam name="U">The result contained in a ApiResponse</typeparam>
        /// <param name="response">The web request result response</param>
        /// <param name="title">The title of the error dialog, if there are any</param>
        /// <param name="okText">The text for the error dialog button, if there are any</param>
        /// <returns>Returns true if there was an error</returns>
        public static async Task<bool> DisplayErrorIfFailedAsync<T, U>(this WebRequestResult<T> response, string title, string okText)
            where T : ApiResponse<U>            
        {
            // If there was no result, bad data, or a response with a error message...
            if (response == null || response.ServerResponse == null || !response.ServerResponse.Successful)
            {
                // Default message
                // TODO: Localize strings
                var message = "Unknown error from server call";

                // If got a response from the server
                if (response?.ServerResponse != null)
                {
                    // Set the message to the server response error message
                    message = response.ServerResponse.ErrorMessage;
                }
                // If we have a result, but deserialization failed
                else if (!response.RawServerResponse.IsNullOrWhitespace())
                {
                    message = $"Unexpected response from server. { response.RawServerResponse }";
                }
                // If we have a result, but no server response details
                else if (response != null)
                {
                    // Set message to standard HTTP server response details
                    message = $"Failed to communicate with server. Status code { response.StatusCode }. { response.StatusDescription }";
                }

                // Display error call
                await IoC.UI.ShowMessage(new MessageBoxDialogViewModel
                {
                    // TODO: Localize strings
                    Title = title,
                    OkText = okText,
                    Message = message
                });

                // Return true if there was an error
                return true;
            }

            // Return false if everything was ok
            return false;
        }
    }
}
