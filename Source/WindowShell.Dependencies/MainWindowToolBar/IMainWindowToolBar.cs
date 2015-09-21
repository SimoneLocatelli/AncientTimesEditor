using System.Windows;

namespace Editor.WindowShell.Dependencies.MainWindowToolBar
{
    /// <summary>
    ///     A ToolBar that can be displayed inside the IMainWindow.
    /// </summary>
    public interface IMainWindowToolBar
    {
        /// <summary>
        ///     Gets the ToolBar control.
        /// </summary>
        /// <value>
        ///     The control.
        /// </value>
        UIElement Control { get; }
    }
}