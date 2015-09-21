#region Usings

using Editor.FileSystem.Dependencies.FileEntities;
using FluentChecker;
using System;
using System.Diagnostics.CodeAnalysis;

#endregion Usings

namespace Editor.FileSystem.Dependencies.Events
{
    /// <summary>
    ///     Contains the information for the event raised when a File has been changed
    /// </summary>
    public class FileChangedEventArgs : EventArgs
    {
        /// <summary>
        ///     Gets or sets the current file.
        /// </summary>
        /// <value>The current file.</value>
        public IFile CurrentFile { get; set; }

        /// <summary>
        ///     Gets or sets the being replaced.
        /// </summary>
        /// <value>The file being replaced.</value>
        public IFile PreviousFile { get; set; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="FileChangedEventArgs" /> class.
        /// </summary>
        /// <param name="previousFile"> The file being replaced. Null is considered an accepted value. </param>
        /// <param name="currentFile"> The new file. If there's no previous file, null is a valid value. </param>
        public FileChangedEventArgs(IFile previousFile, IFile currentFile)
        {
            ThrowExceptionIfPreviousFileIsBeingReplacedByAnInvalidFile(previousFile, currentFile);
            PreviousFile = previousFile;
            CurrentFile = currentFile;
        }

        [ExcludeFromCodeCoverage]
        private static void ThrowExceptionIfPreviousFileIsBeingReplacedByAnInvalidFile(IFile previousFile,
            IFile currentFile)
        {
            Check.If(previousFile != null && currentFile == null).Throw<ArgumentNullException>(() => currentFile);
        }
    }
}