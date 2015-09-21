using Editor.FileSystem.Dependencies.FileEntities;
using System.Collections;
using System.Collections.Generic;

namespace Editor.Settings.Dependencies
{
    public interface IRecentProjectsCollection : IEnumerable<IRecentProject>
    {
        int MaximumRecentProjects { get; }

        void Add(IProject recentProject);
    }
}