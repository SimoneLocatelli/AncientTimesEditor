using System;
using System.Windows;

namespace Editor.Bootstrapper
{
    /// <summary>
    ///     Contains logic for Unhandled exception
    /// </summary>
    public static class ExceptionHandler
    {
        /// <summary>
        ///     Called when an unhandled exception.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="UnhandledExceptionEventArgs" /> instance containing the event data.</param>
        public static void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var ex = (Exception) e.ExceptionObject;
            var message = string.Format("{0} \r\nStacktrace - {1}", ExtractMessage(ex), ex.StackTrace);
            MessageBox.Show(message);
        }

        private static string ExtractMessage(Exception ex)
        {
            var message = string.Format("Message - {0}\r\n", ex.Message);

            message = message + ((ex.InnerException != null) ? ExtractMessage(ex.InnerException) : string.Empty);

            return message;
        }
    }
}