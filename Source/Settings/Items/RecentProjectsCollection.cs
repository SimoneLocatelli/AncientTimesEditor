using Editor.FileSystem.Dependencies.FileEntities;
using Editor.Settings.Dependencies;
using FluentChecker;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace Editor.Settings.Items
{
    [Serializable, XmlRoot("RecentProjects")]
    public class RecentProjectsCollection : ConcurrentQueue<IRecentProject>, IRecentProjectsCollection
    {
        private int maximumRecentProjects;

        public int MaximumRecentProjects
        {
            get { return 6; }
        }

        public RecentProjectsCollection()
        {
        }

        public RecentProjectsCollection(IEnumerable<IRecentProject> collection)
            : base(collection)
        {
        }

        public void Add(IProject project)
        {
            Check.IfIsNull(project).Throw<ArgumentNullException>(() => project);

            if (this.Any(p => p.FullPath == project.FullPath))
            {
                return;
            }

            Enqueue(new RecentProject(project));
            lock (this)
            {
                IRecentProject overflow;
                while (Count > MaximumRecentProjects && TryDequeue(out overflow))
                {
                }
            }
        }
    }
}