using Editor.FileSystem.Dependencies.FileEntities;
using Editor.FileSystem.Dependencies.FileManagers;
using Editor.FileSystem.FileEntities;
using FluentChecker;
using System;
using System.ComponentModel.Composition;

namespace Editor.FileSystem.IO
{
    /// <summary>
    ///     Loads in memory an unindentified file type
    /// </summary>
    [Export(typeof(IFileOpener<IGenericFile>))]
    public class GenericFileOpener : IFileOpener<IGenericFile>
    {
        /// <summary>
        ///     Loads the file stored at the specified path.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns></returns>
        public IGenericFile Open(string filePath)
        {
            Check.IfIsNullOrWhiteSpace(filePath).Throw<ArgumentException>(() => filePath);

            return new GenericFile(filePath);
        }
    }
}