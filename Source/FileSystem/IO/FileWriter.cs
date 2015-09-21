using Editor.FileSystem.Dependencies.FileManagers;
using FluentChecker;
using System;
using System.IO;

namespace Editor.FileSystem.IO
{
    /// <summary>
    ///     Manages the write operations on a file
    /// </summary>
    public class FileWriter : IFileWriter
    {
        /// <summary>
        ///     Writes the contents in the specified file. If the file doesn't exist it will be created,
        ///     if it does the contents will be overriden
        /// </summary>
        /// <param name="contents"> The contents. </param>
        /// <param name="filePath"> The file path. </param>
        public void Write(string contents, string filePath)
        {
            Check.IfIsNull(contents).Throw<ArgumentNullException>(() => contents);
            Check.IfIsNullOrWhiteSpace(filePath).Throw<ArgumentException>(() => filePath);

            File.WriteAllText(filePath, contents);
        }
    }
}