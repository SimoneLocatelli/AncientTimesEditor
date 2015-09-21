using Editor.ProjectExplorer.Dependencies;
using Editor.WpfCommonLibrary.Dependencies.Menu;
using FluentChecker;
using System;
using System.ComponentModel.Composition;

namespace Editor.ProjectExplorer
{
    /// <summary>
    ///     Creates new context menus for the Project Explorer items.
    /// </summary>
    public class ProjectExplorerContextMenuFactory : IProjectExplorerContextMenuFactory
    {
        //private readonly ExportFactory<IContextMenu> exportFactory;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ProjectExplorerContextMenuFactory" /> class.
        /// </summary>
        [ImportingConstructor]
        public ProjectExplorerContextMenuFactory()
        //ExportFactory<IContextMenu> dependencyResolver)
        {
            //Check.IfIsNull(dependencyResolver).Throw<ArgumentNullException>(() => dependencyResolver);

            //exportFactory = dependencyResolver;
        }

        /// <summary>
        ///     Creates the context menu based on the input type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public IContextMenu Create(Type type)
        {
            Check.IfIsNull(type).Throw<ArgumentNullException>(() => type);

            return null; //exportFactory.CreateExport().Value;
        }
    }
}