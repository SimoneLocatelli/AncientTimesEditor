using System;
using System.ComponentModel;

namespace Editor.WindowShell.Dependencies
{
    /// <summary>
    ///     Generic interface for a Window
    /// </summary>
    public interface IWindow
    {
        /// <summary>
        ///     Gets a value that indicates whether this element has been loaded for presentation.
        /// </summary>
        /// <returns>
        ///     true if the current element is attached to an element tree; false if the element has never been attached to a
        ///     loaded element tree.
        /// </returns>
        bool IsLoaded { get; }

        /// <summary>
        ///     Occurs when the Window is being closed.
        /// </summary>
        event EventHandler Closed;

        /// <summary>
        ///     Occurs directly after <see cref="M:System.Windows.Window.Close" /> is called, and can be handled to cancel window
        ///     closure.
        /// </summary>
        /// <exception cref="T:System.InvalidOperationException">
        ///     <see cref="P:System.Windows.UIElement.Visibility" /> is set, or
        ///     <see cref="M:System.Windows.Window.Show" />, <see cref="M:System.Windows.Window.ShowDialog" />, or
        ///     <see cref="M:System.Windows.Window.Close" /> is called while a window is closing.
        /// </exception>
        event CancelEventHandler Closing;

        //
        // Summary:
        //     Manually closes a System.Windows.Window.
        void Close();

        /// <summary>
        ///     Opens a window and returns without waiting for the newly opened window to close.
        /// </summary>
        void Show();

        /// <summary>
        ///     Opens a window and returns only when the newly opened window is closed.
        /// </summary>
        /// <returns>
        ///     A <see cref="T:System.Nullable`1" /> value of type <see cref="T:System.Boolean" /> that
        ///     specifies whether the activity was accepted (true) or canceled (false). The return value
        ///     is the value of the <see cref="P:System.Windows.Window.DialogResult" /> property before
        ///     a window closes.
        /// </returns>
        /// <exception cref="T:System.InvalidOperationException">
        ///     <see cref="M:System.Windows.Window.ShowDialog" /> is called on a
        ///     <see cref="T:System.Windows.Window" /> that is visible-or-
        ///     <see cref="M:System.Windows.Window.ShowDialog" /> is called on a visible
        ///     <see cref="T:System.Windows.Window" /> that was opened by calling <see cref="M:System.Windows.Window.ShowDialog" />
        ///     .
        /// </exception>
        /// <exception cref="T:System.InvalidOperationException">
        ///     <see cref="M:System.Windows.Window.ShowDialog" /> is called on a window that is closing
        ///     ( <see cref="E:System.Windows.Window.Closing" />) or has been closed (
        ///     <see cref="E:System.Windows.Window.Closed" />).
        /// </exception>
        bool? ShowDialog();
    }
}