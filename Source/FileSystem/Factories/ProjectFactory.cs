using Editor.FileSystem.Dependencies.FileEntities;
using Editor.FileSystem.Dependencies.FileManagers;
using Editor.FileSystem.FileEntities;
using FluentChecker;
using System;
using System.ComponentModel.Composition;

namespace Editor.FileSystem.Creators
{
    /// <summary>
    ///     Factory class for the Project File element.
    /// </summary>
    [Export(typeof (IFileFactory<IProject>))]
    public class ProjectFactory : IProjectFactory
    {
        private readonly IProjectLoader projectLoader;
        private readonly IProjectSerializer projectSerializer;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ProjectFactory" /> class.
        /// </summary>
        /// <param name="projectSerializer">The project serializer.</param>
        /// <param name="projectLoader">The project loader.</param>
        [ImportingConstructor]
        public ProjectFactory(IProjectSerializer projectSerializer, IProjectLoader projectLoader)
        {
            Check.IfIsNull(projectSerializer).Throw<ArgumentNullException>(() => projectSerializer);
            Check.IfIsNull(projectLoader).Throw<ArgumentNullException>(() => projectLoader);

            this.projectSerializer = projectSerializer;
            this.projectLoader = projectLoader;
        }

        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns></returns>
        public IProject Create(IProject file)
        {
            Check.IfIsNull(file).Throw<ArgumentNullException>(() => file);

            projectSerializer.Serialize(file);

            projectLoader.Load(file);

            return file;
        }

        public IProject Create(string fullName)
        {
            Check.IfIsNullOrWhiteSpace(fullName).Throw<ArgumentException>(() => fullName);

            return Create(new Project(fullName));
        }
    }
}