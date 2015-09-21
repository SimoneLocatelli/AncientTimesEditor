using Editor.FileSystem.Dependencies;

namespace Editor.FileSystem.FileInfo
{
    /// <summary>
    ///     Represents the file information to indicate any type of File.
    /// </summary>
    public class AnyFileInfo : IFileInfo
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
            get { return Resources.EntityAnyFileDescription; }
        }

        /// <summary>
        ///     Gets the file extension.
        /// </summary>
        /// <value> The extension. </value>
        public string Extension
        {
            get { return "*"; }
        }
    }
}