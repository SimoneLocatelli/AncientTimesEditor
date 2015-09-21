using Editor.FileSystem.Dependencies.Facades;
using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace Editor.FileSystem.Facades
{
    public class FileFacade : IFileFacade
    {
        /// <summary>
        ///     Copies an existing file to a new file. Overwriting a file of the same name is not allowed.
        /// </summary>
        /// <param name="originalPath">The file to copy. </param>
        /// <param name="destinationPath">The name of the destination file. This cannot be a directory or an existing file. </param>
        /// <exception cref="T:System.UnauthorizedAccessException">The caller does not have the required permission. </exception>
        /// <exception cref="T:System.ArgumentException">
        ///     <paramref name="originalPath" /> or <paramref name="destinationPath" /> is
        ///     a zero-length string, contains only white space, or contains one or more invalid characters as defined by
        ///     <see cref="F:System.IO.Path.InvalidPathChars" />.-or- <paramref name="originalPath" /> or
        ///     <paramref name="destinationPath" /> specifies a directory.
        /// </exception>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="originalPath" /> or <paramref name="destinationPath" />
        ///     is null.
        /// </exception>
        /// <exception cref="T:System.IO.PathTooLongException">
        ///     The specified path, file name, or both exceed the system-defined
        ///     maximum length. For example, on Windows-based platforms, paths must be less than 248 characters, and file names
        ///     must be less than 260 characters.
        /// </exception>
        /// <exception cref="T:System.IO.DirectoryNotFoundException">
        ///     The path specified in <paramref name="originalPath" /> or
        ///     <paramref name="destinationPath" /> is invalid (for example, it is on an unmapped drive).
        /// </exception>
        /// <exception cref="T:System.IO.FileNotFoundException"><paramref name="originalPath" /> was not found. </exception>
        /// <exception cref="T:System.IO.IOException"><paramref name="destinationPath" /> exists.-or- An I/O error has occurred. </exception>
        /// <exception cref="T:System.NotSupportedException">
        ///     <paramref name="originalPath" /> or <paramref name="destinationPath" />
        ///     is in an invalid format.
        /// </exception>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet>
        ///     <IPermission
        ///         class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
        ///         version="1" Unrestricted="true" />
        /// </PermissionSet>
        [ExcludeFromCodeCoverage]
        public void Copy(string originalPath, string destinationPath)
        {
            File.Copy(originalPath, destinationPath);
        }

        /// <summary>
        ///     Determines whether the specified file exists.
        /// </summary>
        /// <returns>
        ///     true if the caller has the required permissions and <paramref name="fullPath" /> contains the name of an existing
        ///     file; otherwise, false. This method also returns false if <paramref name="path" /> is null, an invalid path, or a
        ///     zero-length string. If the caller does not have sufficient permissions to read the specified file, no exception is
        ///     thrown and the method returns false regardless of the existence of <paramref name="path" />.
        /// </returns>
        /// <param name="fullPath">The file to check. </param>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet>
        ///     <IPermission
        ///         class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
        ///         version="1" Unrestricted="true" />
        /// </PermissionSet>
        [ExcludeFromCodeCoverage]
        public bool Exists(string fullPath)
        {
            return File.Exists(fullPath);
        }

        /// <summary>
        /// Opens an existing UTF-8 encoded text file for reading.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns></returns>
        public StreamReader OpenText(string filePath)
        {
            return File.OpenText(filePath);
        }
    }
}