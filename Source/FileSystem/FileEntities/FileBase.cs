using Editor.FileSystem.Dependencies;
using Editor.FileSystem.Dependencies.Facades;
using Editor.FileSystem.Dependencies.FileEntities;
using Editor.FileSystem.Facades;
using FluentChecker;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace Editor.FileSystem.FileEntities
{
    /// <summary>
    ///     A common base class for the files
    /// </summary>
    public abstract class FileBase : IFile
    {
        private static IPathFacade pathFacade = new PathFacade();
        private string name;
        private string path;

        /// <summary>
        ///     Gets or sets the path utilities facade.
        /// </summary>
        /// <value>
        ///     The path facade.
        /// </value>
        public static IPathFacade PathFacade
        {
            get { return pathFacade; }
            set
            {
                Check.IfIsNull(value).Throw<ArgumentNullException>(() => PathFacade);
                pathFacade = value;
            }
        }

        /// <summary>
        ///     Gets the file information.
        /// </summary>
        /// <value> The file information. </value>
        public abstract IFileInfo FileInfo { get; }

        /// <summary>
        ///     Gets the full name, composed by the file name and its extension.
        /// </summary>
        /// <value> The full name. </value>
        public virtual string FullName
        {
            get { return string.Format(CultureInfo.CurrentCulture, "{0}.{1}", Name, FileInfo.Extension); }
        }

        /// <summary>
        ///     Gets the full path, composed by the path and the full name.
        /// </summary>
        /// <value> The full path. </value>
        public virtual string FullPath
        {
            get { return PathFacade.Combine(Path, FullName); }
        }

        /// <summary>
        ///     Gets the name.
        /// </summary>
        /// <value> The name. </value>
        public string Name
        {
            get { return name; }
            protected set
            {
                Check.IfIsNullOrWhiteSpace(value).Throw<ArgumentException>(() => name);
                name = value;
            }
        }

        /// <summary>
        ///     Gets the path.
        /// </summary>
        /// <value> The path. </value>
        public string Path
        {
            get { return path; }
            protected set
            {
                Check.IfIsNullOrWhiteSpace(value).Throw<ArgumentException>(() => path);
                path = value;
            }
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="FileBase" /> class.
        /// </summary>
        /// <param name="name"> The name. </param>
        /// <param name="path"> The path. </param>
        protected FileBase(string name, string path)
        {
            Check.IfIsNullOrWhiteSpace(name).Throw<ArgumentException>(() => name);
            Check.IfIsNullOrWhiteSpace(path).Throw<ArgumentException>(() => path);

            Name = name;
            Path = path;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="FileBase" /> class.
        /// </summary>
        /// <param name="fullName"> The file full name. </param>
        protected FileBase(string fullName)
        {
            Check.IfIsNullOrWhiteSpace(fullName).Throw<ArgumentException>(() => fullName);

            Name = PathFacade.GetFileNameWithoutExtension(fullName);
            Path = PathFacade.GetDirectoryName(fullName);
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="FileBase" /> class. This constructor should
        ///     be used only by the serialization process
        /// </summary>
        [ExcludeFromCodeCoverage]
        protected FileBase()
        {
            Name = FileInfo.DefaultFileName;
        }

        /// <summary>
        ///     Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        ///     A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return FullName;
        }
    }
}