using System.ComponentModel.Composition;

namespace Editor.WindowShell.Dependencies
{
    [InheritedExport]
    public interface IDefaultContentsTemplate
    {
        string BottomSection { get; }

        string MainContents { get; }

        string TopSection { get; }
    }
}