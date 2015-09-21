using Editor.WindowShell.Dependencies;
using System.ComponentModel.Composition;

namespace Editor.WindowShell.ViewModels
{
    [InheritedExport]
    public interface IStartupWindowViewModel
    {
        IWindow ParentWindow { get; set; }

        void OpenSelectedProject();
    }
}