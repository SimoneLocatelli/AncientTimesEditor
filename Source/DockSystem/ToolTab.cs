using Editor.DockSystem.Dependencies;
using System.Windows;

namespace Editor.DockSystem
{
    public class ToolTab : BaseDockTab
    {
        public ToolTab(IDockTab dockTab)
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