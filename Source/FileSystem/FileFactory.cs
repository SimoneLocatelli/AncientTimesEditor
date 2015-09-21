using Editor.FileSystem.Dependencies;
using Editor.FileSystem.Dependencies.Exceptions;
using Editor.FileSystem.Dependencies.FileEntities;
using Editor.FileSystem.Dependencies.FileManagers;
using Editor.FileSystem.Dependencies.Utils;
using Editor.FileSystem.FileEntities;
using Editor.FileSystem.FileInfo;
using FluentChecker;
using System;
using System.ComponentModel.Composition;
using System.Diagnostics.CodeAnalysis;

namespace Editor.FileSystem
{
    /// <summary>
    ///     Creates IFile instances
    /// </summary>
    public class FileFactory : IFileFactory
    {
        private readonly ExportFactory<IFileOpener<IDirectory>> directoryFileOpenerFactory;
        private readonly IPathUtils pathUtils;
        private readonly ExportFactory<IFileOpener<IProject>> projectFileOpenerFactory;

        /// <summary>
        ///     Initializes a new instance of the <see cref="FileFactory" /> class.
        /// </summary>
        /// <param name="directoryFileOpenerFactory">The directory file opener factory.</param>
        /// <param name="projectFileOpenerFactory">The project file opener factory.</param>
        /// <param name="pathUtils">The path utils.</param>
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        [ImportingConstructor]
        public FileFactory(ExportFactory<IFileOpener<IDirectory>> directoryFileOpenerFactory,
            ExportFactory<IFileOpener<IProject>> projectFileOpenerFactory,
            IPathUtils pathUtils)
        {
            Check.IfIsNull(directoryFileOpenerFactory).Throw<ArgumentNullException>(() => directoryFileOpenerFactory);
            Check.IfIsNull(projectFileOpenerFactory).Throw<ArgumentNullException>(() => projectFileOpenerFactory);
            Check.IfIsNull(pathUtils).Throw<ArgumentNullException>(() => pathUtils);

            this.directoryFileOpenerFactory = directoryFileOpenerFactory;
            this.projectFileOpenerFactory = projectFileOpenerFactory;
            this.pathUtils = pathUtils;
        }

        /// <summary>
        ///     Reads the file stored at the specified input path and converts it into an Editor File.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns></returns>
        public IFile ConvertToFile(string filePath)
        {
            Check.IfIsNullOrWhiteSpace(filePath).Throw<ArgumentException>(() => filePath);

            var extension = pathUtils.GetExtensionWithoutStartingDot(filePath);

            if (CheckExtension<DirectoryFileInfo>(extension))
            {
                return directoryFileOpenerFactory.CreateExport().Value.Open(filePath);
            }

            if (CheckExtension<ProjectFileInfo>(extension))
            {
                return projectFileOpenerFactory.CreateExport().Value.Open(filePath);
            }

            throw new FileNotImportableException(filePath);
        }

        public IFile CreateFile<TFile>() where TFile : IFile
        {
            var fileType = typeof (TFile);

            if (fileType == typeof (IProject))
            {
                return new Project();
            }

            throw new FileTypeNotRecognizedException(typeof (TFile));
        }

        /// <summary>
        ///     Checks if the extension match with the one stored inside the specified IFileInfo.
        /// </summary>
        /// <typeparam name="TFileInfo">The information of the file type.</typeparam>
        /// <param name="extension">The extension.</param>
        /// <returns>Returns true if the extension match, otherwise false.</returns>
        private static bool CheckExtension<TFileInfo>(string extension) where TFileInfo : IFileInfo, new()
        {
            var fileInfo = new TFileInfo();

            return fileInfo.Extension.Equals(extension, StringComparison.CurrentCultureIgnoreCase);
        }
    }
}