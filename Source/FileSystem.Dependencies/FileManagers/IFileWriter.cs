using System.ComponentModel.Composition;

namespace Editor.FileSystem.Dependencies.FileManagers
{
    /// <summary>
    ///     Manages the write operations on a file
    /// </summary>
    [InheritedExport]
    public interface IFileWriter
    {
        /// <summary>
        ///     Writes the contents in the specified file. If the file doesn't exist it will be created,
        ///     if it does the contents will be overriden
        /// </summary>
        /// <param name="contents"> The contents. </param>
        /// <param name="filePath"> The file path. </param>
        void Write(string contents, string filePath);
    }
}