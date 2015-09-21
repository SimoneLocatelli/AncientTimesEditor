using Editor.FileSystem.Dependencies;
using Editor.FileSystem.Dependencies.FileEntities;
using Editor.FileSystem.FileInfo;
using FluentChecker;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Editor.FileSystem.FileEntities
{
    /// <summary>
    ///     A project file.
    /// </summary>
    public class Project : FileBase, IProject
    {
        private readonly ObservableCollection<IFile> innerFiles = new ObservableCollection<IFile>();
        private readonly IFileInfo projectFileInfo = new ProjectFileInfo();

        /// <summary>
        ///     Gets the path where the children will be stored.
        /// </summary>
        /// <value> The children path. </value>
        public string ChildrenPath
        {
            get { return Path; }
        }

        /// <summary>
        ///     Gets the file information.
        /// </summary>
        /// <value> The file information. </value>
        public override IFileInfo FileInfo
        {
            get { return projectFileInfo; }
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
        ///     Initializes a new instance of the <see cref="Project" /> class.
        /// </summary>
        /// <param name="name"> The name. </param>
        /// <param name="path"> The path. </param>
        public Project(string name, string path)
            : base(name, path)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Project" /> class.
        /// </summary>
        /// <param name="fullName"> The file full name. </param>
        public Project(string fullName)
            : base(fullName)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Project" /> class.
        /// </summary>
        /// <param name="project">The project.</param>
        /// <param name="fullName">The project full name.</param>
        public Project(IProject project, string fullName)
            : this(fullName)
        {
            Check.IfIsNull(project).Throw<ArgumentNullException>(() => project);

            innerFiles = new ObservableCollection<IFile>(project.InnerFiles);
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Project" /> class.
        /// </summary>
        internal Project()
        {
        }

        /// <summary>
        /// Adds the file to the InnerFiles collection.
        /// </summary>
        /// <param name="file">The file.</param>
        public void AddToInnerFiles(IFile file)
        {
            Check.IfIsNull(file).Throw<ArgumentNullException>(() => file);
            InnerFiles.Add(file);
        }

        /// <summary>
        /// Adds the files contained in the collection inside the
        /// InnerFiles list.
        /// </summary>
        /// <param name="files">The files.</param>
        public void AddToInnerFiles(IEnumerable<IFile> files)
        {
            Check.IfIsNull(files).Throw<ArgumentNullException>(() => files);

            files.ToList().ForEach(AddToInnerFiles);
        }
    }
}