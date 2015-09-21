using System;
using System.ComponentModel.Composition;

namespace Editor.WpfCommonLibrary.Dependencies
{
    /// <summary>
    ///     Listener for Wpf Binding Errors
    /// </summary>
    [InheritedExport]
    public interface IBindingErrorListener
    {
        /// <summary>
        ///     Set the input action as handler when the listeners is being notified.
        /// </summary>
        /// <param name="action"> The action that will handle the event. </param>
        void Listen(Action<string> action);
    }
}