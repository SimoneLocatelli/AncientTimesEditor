using Editor.FileSystem.Dependencies.Facades;
using Editor.FileSystem.Dependencies.FileEntities;
using Editor.FileSystem.Dependencies.FileManagers;
using FluentChecker;
using System;
using System.ComponentModel.Composition;
using System.IO;
using Directory = Editor.FileSystem.FileEntities.Directory;

namespace Editor.FileSystem.IO
{
    /// <summary>
    ///     Loads in memory a Directory file
    /// </summary>
    [Export(typeof(IFileOpener<IDirectory>))]
    public class DirectoryFileOpener : IFileOpener<IDirectory>
    {
        private IDirectoryFacade directoryFacade;

        [Import]
        public IDirectoryFacade DirectoryFacade
        {
            get { return directoryFacade; }
            set
            {
                Check.IfIsNull(value).Throw<ArgumentNullException>(() => DirectoryFacade);
                directoryFacade = value;
            }
        }

        /// <summary>
        ///     Loads the file stored at the specified path.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns></returns>
        public IDirectory Open(string filePath)
        {
            Check.IfIsNullOrWhiteSpace(filePath).Throw<ArgumentException>(() => filePath);

            Check.If(!DirectoryFacade.Exists(filePath))
                .Throw<IOException>(Resources.DirectoryFileOpenerDirectoryNotExistingException);

            return new Directory(filePath);
        }
    }
}