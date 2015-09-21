using Editor.FileSystem.Dependencies;

namespace Editor.FileSystem.FileInfo
{
    public class GenericFileInfo : IFileInfo
    {
        /// <summary>
        ///     Gets the default name of the file to use when a new item of this type is being created.
        /// </summary>
        /// <value> The default name of the file. </value>
        public string DefaultFileName
        {
            get { return string.Empty; }
        }

        /// <summary>
        ///     Gets the description of the file type.
        /// </summary>
        /// <value> The description. </value>
        public string Description
        {
            get { return string.Empty; }
        }

        /// <summary>
        ///     Gets the file extension.
        /// </summary>
        /// <value> The extension. </value>
        public string Extension { get; private set; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="GenericFileInfo" /> class.
        /// </summary>
        /// <param name="extension">The extension of the generic file.</param>
        public GenericFileInfo(string extension)
        {
            Extension = extension;
        }
    }
}