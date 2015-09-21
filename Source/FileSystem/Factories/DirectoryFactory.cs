using Editor.FileSystem.Dependencies;
using Editor.FileSystem.Dependencies.Facades;
using Editor.FileSystem.Dependencies.FileEntities;
using Editor.FileSystem.Dependencies.FileManagers;
using Editor.FileSystem.Dependencies.Utils;
using Editor.FileSystem.FileEntities;
using Editor.FileSystem.FileInfo;
using FluentChecker;
using System;
using System.ComponentModel.Composition;
using System.Diagnostics.CodeAnalysis;
using IFileContainer = Editor.FileSystem.Dependencies.FileEntities.IFileContainer;

namespace Editor.FileSystem.Factories
{
    [Export(typeof (IFileFactory<IDirectory>))]
    public class DirectoryFactory : IDirectoryFactory
    {
        private readonly IFileNameDuplicateChecker fileNameDuplicateChecker;
        private IDirectoryFacade directoryFacade;
        private IFileInfo directoryInfo = new DirectoryFileInfo();

        [Import]
        public IDirectoryFacade DirectoryFacade
        {
            get { return directoryFacade; }
            set
            {
                Check.IfIsNull(value).Throw<ArgumentNullException>("DirectoryFacade");
                directoryFacade = value;
            }
        }

        public IFileInfo DirectoryInfo
        {
            [ExcludeFromCodeCoverage] get { return directoryInfo; }
            set
            {
                Check.IfIsNull(value).Throw<ArgumentNullException>("DirectoryInfo");
                directoryInfo = value;
            }
        }

        [ImportingConstructor]
        public DirectoryFactory(IFileNameDuplicateChecker fileNameDuplicateChecker)
        {
            Check.IfIsNull(fileNameDuplicateChecker).Throw<ArgumentNullException>(() => fileNameDuplicateChecker);
            this.fileNameDuplicateChecker = fileNameDuplicateChecker;
        }

        /// <summary>
        ///     Creates the specified directory.
        /// </summary>
        /// <param name="directory"> The directory. </param>
        public IDirectory Create(IDirectory directory)
        {
            Check.IfIsNull(directory).Throw<ArgumentNullException>(() => directory);
            Check.IfIsNullOrWhiteSpace(directory.Name).Throw<ArgumentException>(() => directory.Name);
            Check.IfIsNullOrWhiteSpace(directory.Path).Throw<ArgumentException>(() => directory.Path);

            var name = fileNameDuplicateChecker.CheckNameOrGetValid(directory);

            var createdDirectory = new Directory(name, directory.Path);

            DirectoryFacade.CreateDirectory(createdDirectory.FullPath);

            return createdDirectory;
        }

        /// <summary>
        ///     Creates a file extracting the path and the fullname in the
        ///     provided fullname.
        /// </summary>
        /// <param name="fullName">The fullname of the file to create.</param>
        /// <returns></returns>
        public IDirectory Create(string fullName)
        {
            Check.IfIsNullOrWhiteSpace(fullName).Throw<ArgumentException>(() => fullName);

            return Create(new Directory(fullName));
        }

        /// <summary>
        ///     Creates the specified file container.
        /// </summary>
        /// <param name="parentDirectory">The parent directory where the new folder is going to be created.</param>
        /// <returns></returns>
        public IDirectory CreateWithDefaultName(IFileContainer parentDirectory)
        {
            Check.IfIsNull(parentDirectory).Throw<ArgumentNullException>(() => parentDirectory);

            var directory = new Directory(directoryInfo.DefaultFileName, parentDirectory.ChildrenPath);

            return Create(directory);
        }
    }
}