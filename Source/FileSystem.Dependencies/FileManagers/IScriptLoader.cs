using Editor.FileSystem.Dependencies.FileEntities;
using System.ComponentModel.Composition;

namespace Editor.FileSystem.Dependencies.FileManagers
{
    /// <summary>
    ///     Interface IScriptLoader used to locate a file on disk and save a script in it.
    /// </summary>
    [InheritedExport]
    public interface IScriptLoader
    {
        /// <summary>
        ///     Reads the content of the specified script file.
        /// </summary>
        /// <param name="file">The file containing the script.</param>
        /// <returns>A string containing the script.</returns>
        string LoadContent(IFile file);
    }
}