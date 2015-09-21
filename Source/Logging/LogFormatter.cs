#region Usings

using Editor.Logging.Dependencies;
using FluentChecker;
using System;
using System.Globalization;

#endregion Usings

namespace Editor.Logging
{
    /// <summary>
    ///     Processes and formats the messages before
    ///     they get logged.
    /// </summary>
    public class LogFormatter : ILogFormatter
    {
        /// <summary>
        ///     Formats into a unique string the message and the category.
        /// </summary>
        /// <param name="category">The category where the message belongs.</param>
        /// <param name="message">The input message to log.</param>
        /// <returns>
        ///     A string containing the formatted message.
        /// </returns>
        public string Format(string category, string message)
        {
            Check.IfIsNull(category).Throw<ArgumentNullException>(() => category);
            Check.IfIsNull(message).Throw<ArgumentNullException>(() => message);

            return string.Format(CultureInfo.CurrentCulture, "{0} - {1}\n", category, message);
        }
    }
}