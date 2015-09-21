using Editor.FileSystem.Dependencies.Facades;
using Editor.FileSystem.Dependencies.FileManagers;
using FluentChecker;
using System;
using System.ComponentModel.Composition;

namespace Editor.FileSystem.IO
{
    /// <summary>
    ///     Reads the contents of a file.
    /// </summary>
    public class FileReader : IFileReader
    {
        private IFileFacade fileFacade;

        [Import]
        public IFileFacade FileFacade
        {
            get { return fileFacade; }
            set
            {
                Check.IfIsNull(value).Throw<ArgumentNullException>(() => FileFacade);
                fileFacade = value;
            }
        }

        /// <summary>
        ///     Reads the contents inside the specified file.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns>A string containing all the text inside the file.</returns>
        public string Read(string filePath)
        {
            Check.IfIsNullOrWhiteSpace(filePath).Throw<ArgumentException>(() => filePath);
            Check.If(!FileFacade.Exists(filePath))
                .Throw<InvalidOperationException>(Resources.FileReaderFileNotFoundExceptionMessage);

            using (var streamReader = FileFacade.OpenText(filePath))
            {
                return streamReader.ReadToEnd();
            }
        }
    }
}