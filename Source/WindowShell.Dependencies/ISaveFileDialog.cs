using Editor.FileSystem.Dependencies.FileEntities;
using System.ComponentModel.Composition;

namespace Editor.WindowShell.Dependencies
{
    /// <summary>
    ///     A Window that allow to save a file.
    /// </summary>
    [InheritedExport]
    public interface ISaveFileDialog
    {
        /// <summary>
        ///     Gets the name of the file.
        /// </summary>
        /// <value> The name of the file. </value>
        string FileName { get; }

        /// <summary>
        ///     Gets the file filter.
        /// </summary>
        /// <value> The filter. </value>
        string Filter { get; }

        /// <summary>
        ///     Show the Save File Dialog.
        /// </summary>
        /// <returns></returns>
        bool ShowDialog();
    }

    public interface ISaveFileDialog<TFile> : ISaveFileDialog where TFile : IFile
    {
    }
}