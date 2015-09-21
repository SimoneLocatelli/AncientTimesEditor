using Editor.FileSystem.Dependencies.FileEntities;
using Editor.ProjectExplorer.Dependencies;
using FluentChecker;
using System;
using System.ComponentModel.Composition;

namespace Editor.ProjectExplorer
{
    /// <summary>
    ///     Creates new items for the Project Explorer control.
    /// </summary>
    public class ProjectExplorerItemFactory : IProjectExplorerItemFactory
    {
        /// <summary>
        ///     The project explorer context menu factory
        /// </summary>
        private readonly IProjectExplorerContextMenuFactory projectExplorerContextMenuFactory;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ProjectExplorerItemFactory" /> class.
        /// </summary>
        /// <param name="projectExplorerContextMenuFactory">The project explorer context menu factory.</param>
        [ImportingConstructor]
        public ProjectExplorerItemFactory(IProjectExplorerContextMenuFactory projectExplorerContextMenuFactory)
        {
            Check.IfIsNull(projectExplorerContextMenuFactory).Throw<ArgumentNullException>(() => projectExplorerContextMenuFactory);
            this.projectExplorerContextMenuFactory = projectExplorerContextMenuFactory;
        }

        /// <summary>
        ///     Creates the specified file.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <returns></returns>
        public IProjectExplorerItem Create(IFile file)
        {
            Check.IfIsNull(file).Throw<ArgumentNullException>(() => file);

            var contextMenu = projectExplorerContextMenuFactory.Create(file.GetType());

            return new ProjectExplorerItem(file, contextMenu);
        }
    }
}