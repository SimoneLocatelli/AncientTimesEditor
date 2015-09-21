using System.ComponentModel.Composition;

namespace Editor.FileSystem.Dependencies.FileManagers
{
    /// <summary>
    ///     Reads the contents of a file.
    /// </summary>
    [InheritedExport]
    public interface IFileReader
    {
        /// <summary>
        ///     Reads the contents inside the specified file.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns>A string containing all the text inside the file.</returns>
        string Read(string filePath);
    }
}