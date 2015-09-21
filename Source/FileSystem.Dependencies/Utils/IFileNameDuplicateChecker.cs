using Editor.FileSystem.Dependencies.FileEntities;
using System.ComponentModel.Composition;

namespace Editor.FileSystem.Dependencies.Utils
{
    /// <summary>
    ///     Check the filenames and creates an alternative one valid
    ///     to use.
    /// </summary>
    [InheritedExport]
    public interface IFileNameDuplicateChecker
    {
        /// <summary>
        ///     Checks the name input file name. If it's already used
        ///     it generates a new valid name.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <returns></returns>
        string CheckNameOrGetValid(IFile file);
    }
}