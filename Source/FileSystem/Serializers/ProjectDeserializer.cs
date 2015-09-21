#region Usings

using Editor.FileSystem.Dependencies.FileEntities;
using Editor.FileSystem.Dependencies.FileManagers;
using Editor.FileSystem.FileEntities.Serializables;
using FluentChecker;
using System;
using System.ComponentModel.Composition;

#endregion Usings

namespace Editor.FileSystem.Serializers
{
    /// <summary>
    ///     A deserializator for the <see cref="IProject" /> entity
    /// </summary>
    public class ProjectDeserializer : IProjectDeserializer
    {
        private readonly IXmlDeserializer deserializer;
        private readonly IFileReader fileReader;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ProjectDeserializer" /> class.
        /// </summary>
        /// <param name="deserializer">The deserializer.</param>
        /// <param name="fileReader">The file reader.</param>
        [ImportingConstructor]
        public ProjectDeserializer(IXmlDeserializer deserializer, IFileReader fileReader)
        {
            this.deserializer = deserializer;
            this.fileReader = fileReader;
        }

        /// <summary>
        ///     Deserializes the input project reading it from the location where is stored.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns></returns>
        public IProject Deserialize(string filePath)
        {
            Check.IfIsNullOrWhiteSpace(filePath).Throw<ArgumentException>(() => filePath);

            var contents = fileReader.Read(filePath);

            var projectDeserialized = deserializer.Deserialize<ProjectSerializable>(contents);

            return projectDeserialized.ToIProject(filePath);
        }
    }
}