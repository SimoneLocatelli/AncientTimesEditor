using Editor.FileSystem.Dependencies;
using Editor.FileSystem.Dependencies.FileEntities;
using Editor.FileSystem.FileInfo;

namespace Editor.FileSystem.FileEntities
{
    /// <summary>
    ///     Represents an unindentified file type.
    /// </summary>
    public class GenericFile : FileBase, IGenericFile
    {
        private readonly GenericFileInfo genericFileInfo;

        /// <summary>
        ///     Gets the file information.
        /// </summary>
        /// <value> The file information. </value>
        public override IFileInfo FileInfo
        {
            get { return genericFileInfo; }
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="GenericFile" /> class.
        /// </summary>
        /// <param name="fullName">The file path.</param>
        public GenericFile(string fullName)
            : base(fullName)
        {
            genericFileInfo = new GenericFileInfo(PathUtils.GetExtensionWithoutStartingDot(fullName));
        }
    }
}