using System.ComponentModel;
using System.ComponentModel.Composition;

namespace Editor.Logging.Dependencies
{
    /// <summary>
    ///     Processes and formats the messages before
    ///     they get logged.
    /// </summary>
    [InheritedExport]
    public interface ILogFormatter
    {
        /// <summary>
        ///     Formats into a unique string the message and the category.
        /// </summary>
        /// <param name="category">The category where the message belongs.</param>
        /// <param name="message">The input message to log.</param>
        /// <returns>A string containing the formatted message.</returns>
        string Format(string category, [Localizable(false)] string message);
    }
}