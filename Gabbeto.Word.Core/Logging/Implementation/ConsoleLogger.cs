using System;

namespace Fasseto.Word.Core
{
    ///<sumary>
    /// Logs the messages to the console
    ///</sumary>
    public class ConsoleLogger : ILogger
    {
        /// <summary>
        /// Logs the given message to the system console
        /// </summary>
        /// <param name="message">The message to log</param>
        /// <param name="level">The level of the message</param>
        public void Log(string message, LogLevel level)
        {
            // Save old color
            var oldConsoleColor = Console.ForegroundColor;

            // Default console color
            var consoleColor = ConsoleColor.White;

            // Color console based on level
            switch (level)
            {
                // Debug is blue
                case LogLevel.Debug:
                    consoleColor = ConsoleColor.Blue;
                    break;

                // Verbose is gray
                case LogLevel.Verbose:
                    consoleColor = ConsoleColor.Gray;
                    break;

                // Informative is 
                case LogLevel.Informative:
                    break;                

                // Warning is yellow
                case LogLevel.Warning:
                    consoleColor = ConsoleColor.DarkYellow;
                    break;

                // Error is red
                case LogLevel.Error:
                    consoleColor = ConsoleColor.Red;
                    break;

                case LogLevel.Success:
                    consoleColor = ConsoleColor.Green;
                    break;               
            }

            // Write message to console
            Console.WriteLine($"[{ level }]".PadRight(13, ' ') + message);

            // Reset color
            Console.ForegroundColor = oldConsoleColor;
        }
    }
}
