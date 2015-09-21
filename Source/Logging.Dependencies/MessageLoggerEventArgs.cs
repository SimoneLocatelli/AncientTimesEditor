#region Usings

using System;

#endregion Usings

namespace Editor.Logging.Dependencies
{
    /// <summary>
    ///     Contains the information related to message that has been logged
    /// </summary>
    public class MessageLoggerEventArgs : EventArgs
    {
        /// <summary>
        ///     Gets the category where the message belongs.
        /// </summary>
        /// <value>
        ///     The category.
        /// </value>
        public string Category { get; private set; }

        /// <summary>
        ///     Gets the logged message.
        /// </summary>
        /// <value>
        ///     The message.
        /// </value>
        public string Message { get; private set; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="MessageLoggerEventArgs" /> class.
        /// </summary>
        /// <param name="category">The category.</param>
        /// <param name="message">The message.</param>
        public MessageLoggerEventArgs(string category, string message)
        {
            Category = category;
            Message = message;
        }
    }
}