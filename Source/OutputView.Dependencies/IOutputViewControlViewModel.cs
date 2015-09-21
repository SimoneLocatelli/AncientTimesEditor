using System.ComponentModel;

namespace Editor.OutputView.Dependencies
{
    /// <summary>
    ///     Interface for the Output View Control View Model
    /// </summary>
    public interface IOutputViewControlViewModel
    {
        bool AreCategoriesEnabled { get; }

        /// <summary>
        ///     Gets or sets the current log message.
        /// </summary>
        /// <value> The log message. </value>
        string CurrentLog { get; }

        /// <summary>
        ///     Occurs when a property inside the View Model is being changed.
        /// </summary>
        event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        ///     Clears the completely the current log.
        /// </summary>
        void ClearLog();

        /// <summary>
        ///     Logs the specified message.
        /// </summary>
        /// <param name="category"> The category group of the log message. </param>
        /// <param name="message"> The message to log. </param>
        void Log(string category, string message);
    }
}