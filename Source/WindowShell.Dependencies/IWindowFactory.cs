using System.ComponentModel.Composition;
using System.Windows;

namespace Editor.WindowShell.Dependencies
{
    /// <summary>
    ///     Factory class used to creates new Window to contain Views.
    /// </summary>
    [InheritedExport]
    public interface IWindowFactory
    {
        /// <summary>
        ///     Creates a new Window initialized with the input Title and View.
        /// </summary>
        /// <param name="title">The title of the Window.</param>
        /// <param name="view">The view to display.</param>
        /// <returns></returns>
        IWindow Create(string title, UIElement view);
    }
}