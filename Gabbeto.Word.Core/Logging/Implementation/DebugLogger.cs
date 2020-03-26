using System;
using System.Diagnostics;

namespace Fasseto.Word.Core
{
    ///<sumary>
    ///Logs the messages to the debug console
    ///</sumary>
    public class DebugLogger : ILogger
    {
        /// <summary>
        /// Logs the given message to the system debug console
        /// </summary>
        /// <param name="message">The message to log</param>
        /// <param name="level">The level of the message</param>
        public void Log(string message, LogLevel level)
        {
            // The default category
            var category = default(string);

            // NOTE: The native Debug output has no color
            //       However if you install the VS extension VSColorOutput
            //       then this style will color the outputs nicely
            //
            //       https://github.com/mike-ward/VSColorOutput
            //

            // Color console based on level
            switch (level)
            {
                // Debug is blue
                case LogLevel.Debug:
                    category = "information";
                    break;

                // Verbose is orange
                case LogLevel.Verbose:
                    category = "+++>";
                    break;

                // Warning is olive yellow
                case LogLevel.Warning:
                    category = "warning";
                    break;

                // Error is red
                case LogLevel.Error:
                    category = "error";
                    break;

                // Success is green
                case LogLevel.Success:
                    category = "-----";
                    break;
            }

            // Write message to console
            Debug.WriteLine(message, category);
        }
    }
}
