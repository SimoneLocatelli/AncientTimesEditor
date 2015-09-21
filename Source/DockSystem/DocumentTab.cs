#region Usings

using Editor.DockSystem.Dependencies;

#endregion Usings

namespace Editor.DockSystem
{
    public class DocumentTab : BaseDockTab
    {
        public DocumentTab(IDockTab dockTab)
        {
            Control = dockTab.Control;
            Icon = dockTab.Icon;
            IsActive = dockTab.IsActive;
            IsSelected = dockTab.IsSelected;
            IsVisible = dockTab.IsVisible;
            Title = dockTab.Title;
        }
    }
}