using Editor.WpfCommonLibrary.Dependencies.Menu;
using System;
using System.ComponentModel.Composition;

namespace Editor.ProjectExplorer.Dependencies
{
    /// <summary>
    ///     Creates new context menus for the Project Explorer items.
    /// </summary>
    [InheritedExport]
    public interface IProjectExplorerContextMenuFactory
    {
        /// <summary>
        ///     Creates the context menu based on the input type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        IContextMenu Create(Type type);
    }
}