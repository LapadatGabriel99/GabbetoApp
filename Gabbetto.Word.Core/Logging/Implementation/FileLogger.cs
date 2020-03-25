using System;

namespace Fasseto.Word.Core
{
    ///<sumary>
    /// Logs to a specific file
    ///</sumary>
    public class FileLogger : ILogger
    {
        #region Public Properties

        /// <summary>
        /// The path to write the log file to
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// If true, logs the current time with each message
        /// </summary>
        public bool LogTime { get; set; } = true;

        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        public FileLogger(string filePath)
        {
            // Set the file path
            FilePath = filePath;
        }

        #endregion

        #region Logger Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="level"></param>
        public void Log(string message, LogLevel level)
        {
            // Get the current time
            var currentTime = DateTimeOffset.Now.ToString("yyyy-MM-dd hh:mm:ss");

            // Prefix the time log to the message if desired
            var timeLogString = LogTime ? $"[{currentTime}] " : "";

            // Write the message to the log file
            IoC.File.WriteTextToFileAsync(timeLogString + message + Environment.NewLine, FilePath, true);
        }

        #endregion
    }
}
