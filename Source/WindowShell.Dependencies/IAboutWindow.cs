using System.ComponentModel.Composition;

namespace Editor.WindowShell.Dependencies
{
    /// <summary>
    ///     Represents an About Window
    /// </summary>
    [InheritedExport]
    public interface IAboutWindow : IWindow
    {
    }
}