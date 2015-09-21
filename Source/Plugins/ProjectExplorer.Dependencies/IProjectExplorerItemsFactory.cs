using Editor.FileSystem.Dependencies.FileEntities;
using System.ComponentModel.Composition;

namespace Editor.ProjectExplorer.Dependencies
{
    /// <summary>
    ///     Creates new items for the Project Explorer control.
    /// </summary>
    [InheritedExport]
    public interface IProjectExplorerItemFactory
    {
        /// <summary>
        ///     Creates a Project Explorer item based on the file type.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <returns></returns>
        IProjectExplorerItem Create(IFile file);
    }
}