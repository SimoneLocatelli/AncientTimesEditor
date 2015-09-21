using System.ComponentModel.Composition;

namespace Editor.WindowShell.Dependencies
{
    /// <summary>
    ///     Represents the main window of the application.
    /// </summary>
    [InheritedExport]
    public interface IMainWindow : IWindow
    {
        string ContentsRegionName { get; }
    }
}