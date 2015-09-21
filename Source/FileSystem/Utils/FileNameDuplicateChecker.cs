#region Usings

using Editor.FileSystem.Dependencies.FileEntities;
using Editor.FileSystem.Dependencies.Utils;
using FluentChecker;
using System;
using System.Globalization;
using System.IO;

#endregion Usings

namespace Editor.FileSystem.Utils
{
    /// <summary>
    ///     Check the filenames and creates an alternative one valid
    ///     to use.
    /// </summary>
    public class FileNameDuplicateChecker : IFileNameDuplicateChecker
    {
        /// <summary>
        ///     Checks the name input file name. If it's already used
        ///     it generates a new valid name.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <returns></returns>
        public string CheckNameOrGetValid(IFile file)
        {
            Check.IfIsNull(file).Throw<ArgumentNullException>(() => file);

            if (file is IDirectory)
            {
                return GenerateNewName(file, Directory.Exists);
            }

            return GenerateNewName(file, File.Exists);
        }

        /// <summary>
        ///     Generates new nameS until a valid one is found.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="fileExistCheckFunc">The file exist check function.</param>
        /// <returns></returns>
        private static string GenerateNewName(IFile file, Func<string, bool> fileExistCheckFunc)
        {
            if (!fileExistCheckFunc(file.FullPath))
            {
                return file.FullName;
            }

            var extension = string.IsNullOrWhiteSpace(file.FileInfo.Extension)
                ? string.Empty
                : "." + file.FileInfo.Extension;

            for (var i = 1;; i++)
            {
                var currentFileName = string.Format(CultureInfo.CurrentCulture,
                    "{0} ({1}){2}", file.Name, i, extension);

                if (!fileExistCheckFunc(Path.Combine(file.Path, currentFileName)))
                {
                    return currentFileName;
                }
            }
        }
    }
}