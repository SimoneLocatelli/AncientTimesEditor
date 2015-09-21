using System.Windows;
using System.Windows.Media;

namespace Editor.DockSystem.Dependencies
{
    public interface IDockTab
    {
        string ContentId { get; }

        UIElement Control { get; }

        ImageSource Icon { get; }

        bool IsActive { get; }

        bool IsSelected { get; }

        bool IsVisible { get; set; }

        string Title { get; }
    }
}