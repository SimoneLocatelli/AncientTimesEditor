using System.ComponentModel.Composition;

namespace Editor.WindowShell.Dependencies
{
    [InheritedExport]
    public interface IStartupWindow : IWindow
    {
    }
}