using FluentChecker;
using System;
using System.IO;

namespace Utils
{
    /// <summary>
    ///     Utils method collections about the System Directories
    /// </summary>
    public static class DirectoryUtils
    {
        /// <summary>
        ///     Gets the name of the directory from a fullpath.
        /// </summary>
        /// <param name="fullName"> The full name. </param>
        /// <returns></returns>
        public static string GetDirectoryName(string fullName)
        {
            Check.IfIsNullOrWhiteSpace(fullName).Throw<ArgumentException>();
            return new DirectoryInfo(fullName).Name;
        }

        /// <summary>
        ///     Gets the fullname of the parent folder. If there's no parent, the input string is returned.
        /// </summary>
        /// <param name="fullName"> The full name. </param>
        /// <returns></returns>
        public static string GetParentFullName(string fullName)
        {
            Check.IfIsNullOrWhiteSpace(fullName).Throw<ArgumentException>();

            var directoryInfo = new DirectoryInfo(fullName);

            return directoryInfo.Parent == null ? fullName : directoryInfo.Parent.FullName;
        }
    }
}