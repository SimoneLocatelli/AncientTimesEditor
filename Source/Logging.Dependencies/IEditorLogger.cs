using System;
using System.ComponentModel;

namespace Editor.Logging.Dependencies
{
    /// <summary>
    ///     Defines the features that a generic logger
    ///     will provide.
    /// </summary>
    public interface IEditorLogger
    {
        /// <summary>
        ///     Occurs when a message is being logged.
        /// </summary>
        event EventHandler<MessageLoggerEventArgs> MessageLogged;

        /// <summary>
        ///     Append a message in the log, identified by a category.
        /// </summary>
        /// <param name="category">The category where the message belongs.</param>
        /// <param name="message">The message that will be logged.</param>
        void Log(string category, [Localizable(false)] string message);

        /// <summary>
        ///     Append a message in the log, identified by a category.
        /// </summary>
        /// <param name="category">The category where the message belongs.</param>
        /// <param name="message">The message that will be logged.</param>
        /// <param name="placeholderValues">The placeholder values.</param>
        void Log(string category, [Localizable(false)] string message, params object[] placeholderValues);

        /// <summary>
        ///     Retrieve the full set of logged messages.
        /// </summary>
        /// <returns>A string containing the logged messages</returns>
        string RetrieveLog();
    }
}