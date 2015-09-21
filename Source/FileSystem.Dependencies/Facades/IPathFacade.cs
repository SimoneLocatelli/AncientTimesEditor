using System.ComponentModel.Composition;
using System.IO;

namespace Editor.FileSystem.Dependencies.Facades
{
    /// <summary>
    ///     Facade class for the <see cref="Path" /> class from
    ///     the .Net Framework.
    /// </summary>
    [InheritedExport]
    public interface IPathFacade
    {
        /// <summary>
        ///     Combines two strings into a path.
        /// </summary>
        /// <returns>
        ///     The combined paths. If one of the specified paths is a zero-length string, this method returns the other path. If
        ///     <paramref name="path2" /> contains an absolute path, this method returns <paramref name="path2" />.
        /// </returns>
        /// <param name="path1">The first path to combine. </param>
        /// <param name="path2">The second path to combine. </param>
        /// <exception cref="T:System.ArgumentException">
        ///     <paramref name="path1" /> or <paramref name="path2" /> contains one or
        ///     more of the invalid characters defined in <see cref="M:System.IO.Path.GetInvalidPathChars" />.
        /// </exception>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="path1" /> or <paramref name="path2" /> is null. </exception>
        /// <filterpriority>1</filterpriority>
        string Combine(string path1, string path2);

        /// <summary>
        ///     Returns the directory information for the specified path string.
        /// </summary>
        /// <returns>
        ///     Directory information for <paramref name="path" />, or null if <paramref name="path" /> denotes a root directory or
        ///     is null. Returns <see cref="F:System.String.Empty" /> if <paramref name="path" /> does not contain directory
        ///     information.
        /// </returns>
        /// <param name="path">The path of a file or directory. </param>
        /// <exception cref="T:System.ArgumentException">
        ///     The <paramref name="path" /> parameter contains invalid characters, is
        ///     empty, or contains only white spaces.
        /// </exception>
        /// <exception cref="T:System.IO.PathTooLongException">
        ///     NoteIn the .NET for Windows Store apps or the Portable Class
        ///     Library, catch the base class exception, <see cref="T:System.IO.IOException" />, instead.The
        ///     <paramref name="path" /> parameter is longer than the system-defined maximum length.
        /// </exception>
        /// <filterpriority>1</filterpriority>
        string GetDirectoryName(string path);

        /// <summary>
        ///     Returns the extension of the specified path string.
        /// </summary>
        /// <returns>
        ///     The extension of the specified path (including the period ".");, or null, or <see cref="F:System.String.Empty" />.
        ///     If <paramref name="path" /> is null, <see cref="M:System.IO.Path.GetExtension(System.String);" /> returns null. If
        ///     <paramref name="path" /> does not have extension information,
        ///     <see cref="M:System.IO.Path.GetExtension(System.String);" /> returns <see cref="F:System.String.Empty" />.
        /// </returns>
        /// <param name="path">The path string from which to get the extension. </param>
        /// <exception cref="T:System.ArgumentException">
        ///     <paramref name="path" /> contains one or more of the invalid characters
        ///     defined in <see cref="M:System.IO.Path.GetInvalidPathChars" />.
        /// </exception>
        /// <filterpriority>1</filterpriority>
        string GetExtension(string path);

        /// <summary>
        ///     Returns the file name of the specified path string without the extension.
        /// </summary>
        /// <returns>
        ///     The string returned by <see cref="M:System.IO.Path.GetFileName(System.String);" />, minus the last period (.); and
        ///     all characters following it.
        /// </returns>
        /// <param name="path">The path of the file. </param>
        /// <exception cref="T:System.ArgumentException">
        ///     <paramref name="path" /> contains one or more of the invalid characters
        ///     defined in <see cref="M:System.IO.Path.GetInvalidPathChars" />.
        /// </exception>
        /// <filterpriority>1</filterpriority>
        string GetFileNameWithoutExtension(string path);
    }
}