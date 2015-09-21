using Editor.FileSystem.Dependencies.Events;
using Editor.FileSystem.Dependencies.FileEntities;
using Editor.FileSystem.Dependencies.FileManagers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor.WindowShell.Tests.MockData
{
    public class SpyProjectLoader : IProjectLoader
    {
        public bool HasLoadBeenCalled = false;
        private IProject currentProject;

        public IProject CurrentProject
        {
            get { return currentProject; }
        }

        public event EventHandler<ProjectLoadedEventArgs> ProjectLoaded;

        public void Load(IProject project)
        {
            HasLoadBeenCalled = true;
        }
    }
}