using System.ComponentModel.Composition;

namespace Editor.Settings.Dependencies
{
    [InheritedExport]
    public interface IEditorSettings
    {
        IRecentProjectsCollection RecentProjects { get; set; }
    }
}