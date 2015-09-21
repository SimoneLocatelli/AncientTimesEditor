using Editor.FileSystem.Dependencies.Facades;
using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace Editor.FileSystem.Facades
{
    public class DirectoryFacade : IDirectoryFacade
    {
        /// <summary>
        ///     Creates all directories and subdirectories in the specified path unless they already exist.
        /// </summary>
        /// <param name="fullPath">The full path.</param>
        /// <exception cref="T:System.IO.IOException">
        ///     The directory specified by <paramref name="fullPath" /> is a file.-or-The
        ///     network name is not known.
        /// </exception>
        /// <exception cref="T:System.UnauthorizedAccessException">The caller does not have the required permission.</exception>
        /// <exception cref="T:System.ArgumentException">
        ///     <paramref name="fullPath" /> is a zero-length string, contains only white
        ///     space, or contains one or more invalid characters. You can query for invalid characters by using the
        ///     <see cref="M:System.IO.Path.GetInvalidPathChars" /> method.-or-<paramref name="fullPath" /> is prefixed with, or
        ///     contains, only a colon character (:).
        /// </exception>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="fullPath" /> is null.</exception>
        /// <exception cref="T:System.IO.PathTooLongException">
        ///     The specified path, file name, or both exceed the system-defined
        ///     maximum length. For example, on Windows-based platforms, paths must be less than 248 characters and file names must
        ///     be less than 260 characters.
        /// </exception>
        /// <exception cref="T:System.IO.DirectoryNotFoundException">
        ///     The specified path is invalid (for example, it is on an
        ///     unmapped drive).
        /// </exception>
        /// <exception cref="T:System.NotSupportedException">
        ///     <paramref name="fullPath" /> contains a colon character (:) that is
        ///     not part of a drive label ("C:\").
        /// </exception>
        /// <PermissionSet>
        ///     <IPermission
        ///         class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
        ///         version="1" Unrestricted="true" />
        /// </PermissionSet>
        [ExcludeFromCodeCoverage]
        public void CreateDirectory(string fullPath)
        {
            Directory.CreateDirectory(fullPath);
        }

        /// <summary>
        ///     Determines whether the given path refers to an existing directory on disk.
        /// </summary>
        /// <returns>
        ///     true if <paramref name="fullPath" /> refers to an existing directory; false if the directory does not exist or an
        ///     error occurs when trying to determine if the specified file exists.true if <paramref name="path" /> refers to an
        ///     existing directory; otherwise, false.
        /// </returns>
        /// <param name="fullPath">The path to test. </param>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet>
        ///     <IPermission
        ///         class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
        ///         version="1" Unrestricted="true" />
        /// </PermissionSet>
        [ExcludeFromCodeCoverage]
        public bool Exists(string fullPath)
        {
            return Directory.Exists(fullPath);
        }
    }
}