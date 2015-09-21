using Editor.FileSystem.Dependencies.Facades;
using Editor.FileSystem.Dependencies.FileManagers;
using FluentChecker;
using System;
using System.ComponentModel.Composition;
using System.Diagnostics.CodeAnalysis;

namespace Editor.FileSystem.Utils
{
    /// <summary>
    ///     Manage the location of an existing file.
    /// </summary>
    [Export(typeof (IFileLocationManager))]
    public class FileLocationManager : IFileLocationManager
    {
        private IDirectoryFacade directoryFacade;
        private IFileFacade fileFacade;
        private IPathFacade pathFacade;

        [ExcludeFromCodeCoverage, Import]
        public IDirectoryFacade DirectoryFacade
        {
            get { return directoryFacade; }
            set
            {
                Check.IfIsNull(value).Throw<ArgumentNullException>("DirectoryFacade");
                directoryFacade = value;
            }
        }

        /// <summary>
        ///     Gets or sets the file facade.
        /// </summary>
        /// <value>
        ///     The file facade.
        /// </value>
        [ExcludeFromCodeCoverage, Import]
        public IFileFacade FileFacade
        {
            get { return fileFacade; }
            set
            {
                Check.IfIsNull(value).Throw<ArgumentNullException>("FileFacade");
                fileFacade = value;
            }
        }

        /// <summary>
        ///     Gets or sets the path facade.
        /// </summary>
        /// <value>
        ///     The path facade.
        /// </value>
        [ExcludeFromCodeCoverage, Import]
        public IPathFacade PathFacade
        {
            get { return pathFacade; }
            set
            {
                Check.IfIsNull(value).Throw<ArgumentNullException>("PathFacade");
                pathFacade = value;
            }
        }

        /// <summary>
        ///     Combines the input paths.
        /// </summary>
        /// <param name="path1">The first path.</param>
        /// <param name="path2">The second path.</param>
        /// <returns></returns>
        [ExcludeFromCodeCoverage]
        public string Combine(string path1, string path2)
        {
            return PathFacade.Combine(path1, path2);
        }

        /// <summary>
        ///     Copies a file into the specified destination path.
        /// </summary>
        /// <param name="originalPath">The original path.</param>
        /// <param name="destinationPath">The destination path.</param>
        [ExcludeFromCodeCoverage]
        public void Copy(string originalPath, string destinationPath)
        {
            FileFacade.Copy(originalPath, destinationPath);
        }

        /// <summary>
        ///     Check if the input file or directory path already exists.
        /// </summary>
        /// <param name="fullPath">The full path.</param>
        /// <returns></returns>
        [ExcludeFromCodeCoverage]
        public bool Exists(string fullPath)
        {
            Check.IfIsNullOrWhiteSpace(fullPath).Throw<ArgumentNullException>();
            return FileFacade.Exists(fullPath) || DirectoryFacade.Exists(fullPath);
        }
    }
}