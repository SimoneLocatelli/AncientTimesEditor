using System.ComponentModel.Composition;
using System.Windows;

namespace Editor.ProjectExplorer.Dependencies
{
    /// <summary>
    ///     The Project Explorer control
    /// </summary>
    [InheritedExport]
    public interface IProjectExplorerView
    {
        /// <summary>
        ///     Gets the <see cref="UIElement" /> control.
        /// </summary>
        /// <value> The control. </value>
        UIElement Control { get; }
    }
}