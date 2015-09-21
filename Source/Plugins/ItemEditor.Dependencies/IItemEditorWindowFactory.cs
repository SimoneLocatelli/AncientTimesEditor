using Editor.WindowShell.Dependencies;
using System.ComponentModel.Composition;

namespace Editor.ItemEditor.Dependencies
{
    /// <summary>
    ///     Factory class to create ItemEditor windows
    /// </summary>
    [InheritedExport]
    public interface IItemEditorWindowFactory
    {
        /// <summary>
        ///     Creates a new window containing the Item Editor.
        /// </summary>
        /// <returns></returns>
        IWindow Create();
    }
}