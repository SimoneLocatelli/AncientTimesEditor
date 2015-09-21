using Editor.FileSystem.Dependencies.Facades;
using Editor.FileSystem.Dependencies.FileEntities;
using Editor.FileSystem.Facades;
using Editor.Settings.Dependencies;
using FluentChecker;
using System;
using System.Xml.Serialization;

namespace Editor.Settings.Items
{
    [Serializable]
    public class RecentProject : IRecentProject
    {
        private string name;
        private IPathFacade pathFacade = new PathFacade();

        [XmlAttribute]
        public string FullPath { get; set; }

        public string Name
        {
            get { return PathFacade.GetFileNameWithoutExtension(FullPath); }
        }

        [XmlIgnore]
        public IPathFacade PathFacade
        {
            get { return pathFacade; }
            set
            {
                Check.IfIsNull(pathFacade).Throw<ArgumentNullException>(() => PathFacade);
                pathFacade = value;
            }
        }

        public RecentProject(string fullPath)
        {
            Check.IfIsNullOrWhiteSpace(fullPath).Throw<ArgumentNullException>(() => fullPath);

            FullPath = fullPath;
        }

        public RecentProject(IProject project)
        {
            Check.IfIsNull(project).Throw<ArgumentNullException>(() => project);
            Check.IfIsNullOrWhiteSpace(project.Path).Throw<ArgumentNullException>(() => project.Path);

            FullPath = project.FullPath;
        }

        public RecentProject(IRecentProject project)
        {
            Check.IfIsNull(project).Throw<ArgumentNullException>(() => project);
            Check.IfIsNullOrWhiteSpace(project.FullPath).Throw<ArgumentNullException>(() => project.FullPath);

            FullPath = project.FullPath;
        }

        private RecentProject()
        {
            // Required by .Net xml serialization
        }
    }
}