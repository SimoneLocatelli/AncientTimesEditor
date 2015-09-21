using Editor.FileSystem.Dependencies.FileEntities;
using System.Collections.Generic;

namespace Editor.FileSystem.FileEntities
{
    /// <summary>
    ///     Represents a generic file
    /// </summary>
    public interface IFileContainer : IFile
    {
        /// <summary>
        ///     Gets the path where the children will be stored.
        /// </summary>
        /// <value> The children path. </value>
        string ChildrenPath { get; }

        /// <summary>
        ///     Gets the inner files contained by this file.
        /// </summary>
        /// <value> The inner files. </value>
        ICollection<IFile> InnerFiles { get; }
    }
}