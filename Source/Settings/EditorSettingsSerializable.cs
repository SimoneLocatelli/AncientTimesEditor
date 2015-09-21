using Editor.Settings.Dependencies;
using Editor.Settings.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace Editor.Settings
{
    [Serializable, XmlRoot("Settings")]
    public class EditorSettingsSerializable
    {
        public List<RecentProject> RecentProjects { get; set; }

        public EditorSettingsSerializable()
        {
            RecentProjects = new List<RecentProject>();
        }

        public EditorSettingsSerializable(IEditorSettings editorSettings)
        {
            RecentProjects = editorSettings.RecentProjects.Select(CreateRecentProject).ToList();
        }

        public IEditorSettings ToEditorSettings()
        {
            return new EditorSettings
            {
                RecentProjects = new RecentProjectsCollection(RecentProjects)
            };
        }

        private static RecentProject CreateRecentProject(IRecentProject p)
        {
            return new RecentProject(p);
        }
    }
}