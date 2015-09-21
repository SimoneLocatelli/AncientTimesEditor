using Editor.Logging.Dependencies;
using FluentChecker;
using System;
using System.ComponentModel.Composition;
using System.Globalization;
using System.Text;

namespace Editor.Logging
{
    /// <summary>
    ///     A simple logger that stores all the messages
    ///     inside the Memory
    /// </summary>
    [Export(typeof(IEditorLogger))]
    public class MemoryLogger : IEditorLogger
    {
        private readonly StringBuilder log = new StringBuilder();
        private readonly ILogFormatter logFormatter;

        /// <summary>
        ///     Initializes a new instance of the <see cref="MemoryLogger" /> class.
        /// </summary>
        /// <param name="logFormatter">The log formatter.</param>
        [ImportingConstructor]
        public MemoryLogger(ILogFormatter logFormatter)
        {
            Check.IfIsNull(logFormatter).Throw<ArgumentNullException>(() => logFormatter);

            this.logFormatter = logFormatter;
        }

        /// <summary>
        ///     Occurs when a message is being logged.
        /// </summary>
        public event EventHandler<MessageLoggerEventArgs> MessageLogged;

        /// <summary>
        ///     Append a message in the log, identified by a category.
        /// </summary>
        /// <param name="category">The category where the message belongs.</param>
        /// <param name="message">The message that will be logged.</param>
        public void Log(string category, string message)
        {
            Check.IfIsNullOrWhiteSpace(category).Throw<ArgumentException>(() => category);
            Check.IfIsNull(message).Throw<ArgumentException>(() => message);

            log.Append(logFormatter.Format(category, message));

            NotifyLogSubscribers(category, message);
        }

        /// <summary>
        ///     Append a message in the log, identified by a category.
        /// </summary>
        /// <param name="category">The category where the message belongs.</param>
        /// <param name="message">The message that will be logged.</param>
        /// <param name="placeholderValues">The place holder values to use to fill the input message.</param>
        public void Log(string category, string message, params object[] placeholderValues)
        {
            Log(category, string.Format(CultureInfo.CurrentCulture, message, placeholderValues));
        }

        /// <summary>
        ///     Retrieve the full set of logged messages.
        /// </summary>
        /// <returns>
        ///     A string containing the logged messages
        /// </returns>
        public string RetrieveLog()
        {
            return log.ToString();
        }

        private void NotifyLogSubscribers(string category, string message)
        {
            if (MessageLogged == null) return;

            MessageLogged(this, new MessageLoggerEventArgs(category, message));
        }
    }
}