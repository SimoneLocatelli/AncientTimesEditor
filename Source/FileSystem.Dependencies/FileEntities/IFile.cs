namespace Editor.FileSystem.Dependencies.FileEntities
{
    /// <summary>
    ///     Represents a generic file
    /// </summary>
    public interface IFile
    {
        /// <summary>
        ///     Gets the file information.
        /// </summary>
        /// <value> The file information. </value>
        IFileInfo FileInfo { get; }

        /// <summary>
        ///     Gets the full name, composed by the file name and its extension.
        /// </summary>
        /// <value> The full name. </value>
        string FullName { get; }

        /// <summary>
        ///     Gets the full path, composed by the path and the full name.
        /// </summary>
        /// <value> The full path. </value>
        string FullPath { get; }

        /// <summary>
        ///     Gets the name.
        /// </summary>
        /// <value> The name. </value>
        string Name { get; }

        /// <summary>
        ///     Gets the path.
        /// </summary>
        /// <value> The path. </value>
        string Path { get; }
    }
}