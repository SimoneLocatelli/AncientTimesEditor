namespace Editor.FileSystem.Dependencies
{
    /// <summary>
    ///     Contains the information about a File Type.
    /// </summary>
    public interface IFileInfo
    {
        /// <summary>
        ///     Gets the default name of the file to use when a new item of this type is being created.
        /// </summary>
        /// <value> The default name of the file. </value>
        string DefaultFileName { get; }

        /// <summary>
        ///     Gets the description of the file type.
        /// </summary>
        /// <value> The description. </value>
        string Description { get; }

        /// <summary>
        ///     Gets the file extension.
        /// </summary>
        /// <value> The extension. </value>
        string Extension { get; }
    }
}