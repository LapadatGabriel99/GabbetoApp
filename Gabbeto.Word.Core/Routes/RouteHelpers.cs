using System;
using System.Collections.Generic;
using System.Text;
using ProjectUniversal;

namespace Fasseto.Word.Core
{
    /// <summary>
    /// Helper methods for getting and working with web routes
    /// </summary>
    public static class RouteHelpers
    {
        /// <summary>
        /// Gets the absolute route needed for the execution
        /// </summary>
        /// <param name="relativeUrl">The relative url</param>
        /// <returns>Returns the absolute url</returns>
        public static string GetAbsoluteRoute(string relativeUrl)
        {
            // Get the host
            var host = Framework.Configuration["GabbetoWordServer:HostUrl"];

            // If there is no relative url
            if(relativeUrl.IsNullOrEmpty() || relativeUrl.IsNullOrWhitespace())
            {
                return host;
            }

            // If the relative url does not with a '/'
            if(!relativeUrl.StartsWith("/"))
            {
                // Add a '/' in front or the url
                relativeUrl = "/" + relativeUrl;
            }

            // Return combined url
            return host + relativeUrl;
        }
    }
}
