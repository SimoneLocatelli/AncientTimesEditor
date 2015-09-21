using System.ComponentModel.Composition;

namespace Editor.FileSystem.Dependencies.FileManagers
{
    /// <summary>
    ///     Manage the location of an existing file.
    /// </summary>
    [InheritedExport]
    public interface IFileLocationManager
    {
        /// <summary>
        ///     Combines the input paths.
        /// </summary>
        /// <param name="path1">The first path.</param>
        /// <param name="path2">The second path.</param>
        /// <returns></returns>
        string Combine(string path1, string path2);

        /// <summary>
        ///     Copies a file into the specified destination path.
        /// </summary>
        /// <param name="originalPath">The original path.</param>
        /// <param name="destinationPath">The destination path.</param>
        void Copy(string originalPath, string destinationPath);

        /// <summary>
        ///     Check if the input file or directory path already exists.
        /// </summary>
        /// <param name="fullPath">The full path.</param>
        /// <returns></returns>
        bool Exists(string fullPath);
    }
}