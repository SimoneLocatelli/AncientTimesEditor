using System.Windows;

namespace Editor.OutputView.Dependencies
{
    /// <summary>
    ///     Interface for the Output View Control View Model
    /// </summary>
    public interface IOutputViewControlViewModel
    {
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