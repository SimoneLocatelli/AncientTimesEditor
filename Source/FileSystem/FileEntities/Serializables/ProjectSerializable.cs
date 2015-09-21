#region Usings

using Editor.FileSystem.Dependencies.FileEntities;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;

#endregion Usings

namespace Editor.FileSystem.FileEntities.Serializables
{
    [Serializable]
    [XmlRoot("Project")]
    public class ProjectSerializable
    {
        public ProjectSerializable(IProject project)
        {
        }

        [ExcludeFromCodeCoverage]
        private ProjectSerializable()
        {
            // Required by the .Net Xml Serialzator
        }

        public IProject ToIProject(string fullPath)
        {
            var project = new Project(fullPath);
            project.AddToInnerFiles(new List<IFile>());
            return project;
        }
    }
}