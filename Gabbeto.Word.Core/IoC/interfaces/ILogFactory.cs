using System;
using System.Runtime.CompilerServices;

namespace Fasseto.Word.Core
{
    ///<sumary>
    /// Holds a bunch of loggers to log messages for the user
    ///</sumary>
    public interface ILogFactory
    {
        #region Events

        /// <summary>
        /// Fires whenever a new log arrives
        /// </summary>
        event Action<(string Message, LogLevel Level)> NewLog;

        #endregion

        #region Public Properties

        /// <summary>
        /// The level of loggin to output
        /// (For example if we set the level to informative, only informative and below will get loged out)
        /// </summary>
        LogOutputLevel LogOutputLevel { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Adds the specific logger to this factory
        /// </summary>
        /// <param name="logger"> The logger </param>
        void AddLogger(ILogger logger);

        /// <summary>
        /// Removes the specified logger from this factory
        /// </summary>
        /// <param name="logger"> The logger </param>
        void RemoveLogger(ILogger logger);

        /// <summary>
        /// Logs the specific message to all loggers in this factory
        /// </summary>
        /// <param name="message"> The message to log </param>
        /// <param name="level"> The level of the message being logged </param>
        /// <param name="origin"> The method function this message was logged in </param>
        /// <param name="filePath"> The code filename that this message was logged from </param>
        /// <param name="lineNumber"> The line of code in the filename this message was logged from </param>
        void Log(string message,
            LogLevel level = LogLevel.Informative,
            [CallerMemberName] string origin = "",
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int lineNumber = 0);

        #endregion
    }
}
