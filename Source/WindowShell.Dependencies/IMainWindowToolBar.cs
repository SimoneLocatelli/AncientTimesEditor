using System.ComponentModel.Composition;
using System.Windows;

namespace Editor.WindowShell.Dependencies
{
    /// <summary>
    ///     A ToolBar that can be displayed inside the IMainWindow.
    /// </summary>
    [InheritedExport]
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