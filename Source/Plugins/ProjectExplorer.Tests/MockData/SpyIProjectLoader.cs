using System;
using System.Collections.Generic;
using Editor.FileSystem.Dependencies.Events;
using Editor.FileSystem.Dependencies.FileEntities;
using Editor.FileSystem.Dependencies.FileManagers;

namespace Editor.ProjectExplorer.Tests.MockData
{
    public class SpyIProjectLoader : IProjectLoader
    {
        private readonly List<EventHandler<ProjectLoadedEventArgs>> attachedListeners =
            new List<EventHandler<ProjectLoadedEventArgs>>();

        private IProject currentProject;

        public IEnumerable<EventHandler<ProjectLoadedEventArgs>> AttachedListeners
        {
            get { return attachedListeners; }
        }

        public IProject CurrentProject
        {
            get { return currentProject; }
        }

        public event EventHandler<ProjectLoadedEventArgs> ProjectLoaded
        {
            add { attachedListeners.Add(value); }
            remove { throw new NotImplementedException(); }
        }

        public void Load(IProject project)
        {
            throw new NotImplementedException();
        }

        public void RaiseProjectLoadedEvent(IProject project)
        {
            attachedListeners.ForEach(l => l(this, new ProjectLoadedEventArgs(project)));
        }
    }
}