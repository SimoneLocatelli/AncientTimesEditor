#region Usings

using Editor.FileSystem.Dependencies.FileEntities;
using Editor.FileSystem.Dependencies.FileManagers;
using Editor.FileSystem.FileEntities;
using FluentChecker;
using System;
using System.ComponentModel.Composition;

#endregion Usings

namespace Editor.FileSystem.IO
{
    /// <summary>
    ///     Loads in memory Project files
    /// </summary>
    [Export(typeof (IFileOpener<IProject>))]
    public class ProjectFileOpener : IFileOpener<IProject>
    {
        private readonly IProjectDeserializer projectDeserializer;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ProjectFileOpener" /> class.
        /// </summary>
        /// <param name="projectDeserializer">The project deserializer.</param>
        [ImportingConstructor]
        public ProjectFileOpener(IProjectDeserializer projectDeserializer)
        {
            Check.IfIsNull(projectDeserializer).Throw<ArgumentNullException>(() => projectDeserializer);
            this.projectDeserializer = projectDeserializer;
        }

        /// <summary>
        ///     Loads the file stored at the specified path.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns></returns>
        public IProject Open(string filePath)
        {
            Check.IfIsNullOrWhiteSpace(filePath).Throw<ArgumentException>(() => filePath);

            var projectDeserialized = projectDeserializer.Deserialize(filePath);

            var project = new Project(projectDeserialized, filePath);

            return project;
        }
    }
}