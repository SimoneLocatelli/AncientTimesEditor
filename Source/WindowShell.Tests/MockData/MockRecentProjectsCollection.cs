using System;
using System.Collections.Generic;
using Editor.FileSystem.Dependencies.FileEntities;
using Editor.Settings.Dependencies;

namespace Editor.WindowShell.Tests.MockData
{
    public class MockRecentProjectsCollection : List<IRecentProject>, IRecentProjectsCollection
    {
        private int maximumRecentProjects;

        public int MaximumRecentProjects
        {
            get { return maximumRecentProjects; }
        }

        public void Add(IProject recentProject)
        {
            throw new NotImplementedException();
        }
    }
}