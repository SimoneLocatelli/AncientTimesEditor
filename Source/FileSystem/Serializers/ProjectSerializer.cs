using Editor.FileSystem.Dependencies.FileEntities;
using Editor.FileSystem.Dependencies.FileManagers;
using Editor.FileSystem.FileEntities.Serializables;
using FluentChecker;
using System;
using System.ComponentModel.Composition;

namespace Editor.FileSystem.Serializers
{
    /// <summary>
    ///     A serializator for the <see cref="IProject" /> entity
    /// </summary>
    public class ProjectSerializer : IProjectSerializer
    {
        private readonly IFileWriter fileWriter;
        private readonly IXmlSerializer serializer;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ProjectSerializer" /> class.
        /// </summary>
        /// <param name="serializer">The serializer.</param>
        /// <param name="fileWriter">The file writer.</param>
        [ImportingConstructor]
        public ProjectSerializer(IXmlSerializer serializer, IFileWriter fileWriter)
        {
            this.serializer = serializer;
            this.fileWriter = fileWriter;
        }

        /// <summary>
        ///     Serializes the specified project saving it on disk.
        /// </summary>
        /// <param name="project"> The project. </param>
        public void Serialize(IProject project)
        {
            Check.IfIsNull(project).Throw<ArgumentNullException>(() => project);
            Check.IfIsNullOrWhiteSpace(project.FullPath).Throw<ArgumentException>(() => project.FullPath);

            var projectSerializable = new ProjectSerializable(project);

            var projectSerialized = serializer.Serialize(projectSerializable);

            fileWriter.Write(projectSerialized, project.FullPath);
        }
    }
}