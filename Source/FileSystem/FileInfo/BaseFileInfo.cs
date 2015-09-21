using Editor.FileSystem.Dependencies;

namespace Editor.FileSystem.FileInfo
{
    public abstract class BaseFileInfo<TFileInfo> : IFileInfo where TFileInfo : new()
    {
        /// <summary>
        ///     Gets the default name of the file to use when a new item of this type is being created.
        /// </summary>
        /// <value> The default name of the file. </value>
        public abstract string DefaultFileName { get; }

        /// <summary>
        ///     Gets the description of the file type.
        /// </summary>
        /// <value> The description. </value>
        public abstract string Description { get; }

        /// <summary>
        ///     Gets the file extension.
        /// </summary>
        /// <value> The extension. </value>
        public abstract string Extension { get; }
    }
}