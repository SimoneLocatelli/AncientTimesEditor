#region Usings

using Editor.FileSystem.Dependencies;
using Editor.FileSystem.Dependencies.FileEntities;
using Editor.FileSystem.FileInfo;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Utils;

#endregion Usings

namespace Editor.FileSystem.FileEntities
{
    /// <summary>
    ///     A Directory file
    /// </summary>
    public class Directory : FileBase, IDirectory
    {
        private readonly ObservableCollection<IFile> innerFiles = new ObservableCollection<IFile>();

        /// <summary>
        ///     Gets the path where the children will be stored.
        /// </summary>
        /// <value> The children path. </value>
        public string ChildrenPath
        {
            get { return FullPath; }
        }

        /// <summary>
        ///     Gets the file information.
        /// </summary>
        /// <value> The file information. </value>
        public override IFileInfo FileInfo
        {
            get { return new DirectoryFileInfo(); }
        }

        /// <summary>
        ///     Gets the full name, composed by the file name and its extension.
        /// </summary>
        /// <value> The full name. </value>
        public override string FullName
        {
            get { return Name; }
        }

        /// <summary>
        ///     Gets the inner files contained by this file.
        /// </summary>
        /// <value> The inner files. </value>
        public ICollection<IFile> InnerFiles
        {
            get { return innerFiles; }
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="FileBase" /> class.
        /// </summary>
        /// <param name="name"> The name. </param>
        /// <param name="path"> The path. </param>
        public Directory(string name, string path)
        {
            Name = name;
            Path = path;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="FileBase" /> class.
        /// </summary>
        /// <param name="fullName"> The file full name. </param>
        public Directory(string fullName)
            : this(DirectoryUtils.GetDirectoryName(fullName), DirectoryUtils.GetParentFullName(fullName))
        {
        }
    }
}