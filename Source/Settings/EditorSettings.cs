using Editor.Settings.Dependencies;
using Editor.Settings.Items;

namespace Editor.Settings
{
    public class EditorSettings : IEditorSettings
    {
        public IRecentProjectsCollection RecentProjects { get; set; }

        public EditorSettings()
        {
            RecentProjects = new RecentProjectsCollection();
        }
    }
}