using System.ComponentModel.Composition;
using System.Windows;

namespace Editor.OutputView.Dependencies
{
    /// <summary>
    ///     Represents the Output View control used to log messages on the Main Window.
    /// </summary>
    [InheritedExport]
    public interface IOutputViewControl
    {
        /// <summary>
        ///     Gets the <see cref="UIElement" /> instance.
        /// </summary>
        /// <value> The UIElement instance. </value>
        UIElement Control { get; }

        /// <summary>
        ///     Logs the specified message.
        /// </summary>
        /// <param name="category"> The category group of the log message. </param>
        /// <param name="message"> The message to log. </param>
        void Log(string category, string message);

        /// <summary>
        ///     Logs a message under the General Information category.
        /// </summary>
        /// <param name="message">The message to log.</param>
        void LogGeneralInfo(string message);
    }
}