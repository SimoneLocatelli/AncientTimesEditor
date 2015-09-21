using Editor.FileSystem.Dependencies.FileEntities;
using System.ComponentModel.Composition;
using System.Windows;

namespace Editor.WindowShell.Dependencies
{
    /// <summary>
    ///     Container for one or more tab items
    /// </summary>
    [InheritedExport]
    public interface ITabControl
    {
        /// <summary>
        ///     Gets the Tab Control interface element.
        /// </summary>
        /// <value>
        ///     The control.
        /// </value>
        UIElement Control { get; }

        //void DeleteTab(object sender, RoutedEventArgs e);

        /// <summary>
        ///     Create a new Tab and then add it to the Tab Control.
        /// </summary>
        /// <param name="file">The file which contents will be displayed in the Tab</param>
        void CreateTab(IFile file);
    }
}