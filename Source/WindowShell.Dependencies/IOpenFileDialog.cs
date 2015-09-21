using Editor.FileSystem.Dependencies.FileEntities;
using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace
    Editor.WindowShell.Dependencies
{
    /// <summary>
    ///     A Window that allow to save a file.
    /// </summary>
    [InheritedExport]
    public interface IOpenFileDialog
    {
        /// <summary>
        ///     Gets the name of the file.
        /// </summary>
        /// <value> The name of the file. </value>
        string FileName { get; }

        /// <summary>
        ///     Gets or sets the all the names of the selected files.
        /// </summary>
        /// <value>
        ///     The file names.
        /// </value>
        IEnumerable<string> FileNames { get; }

        /// <summary>
        ///     Gets the file filter.
        /// </summary>
        /// <value> The filter. </value>
        string Filter { get; }

        /// <summary>
        ///     Gets or sets a value indicating whether this <see cref="IOpenFileDialog" /> should allow to select an indefinite
        ///     number of files.
        /// </summary>
        /// <value>
        ///     <c>true</c> if allow a multiselection; otherwise, <c>false</c>.
        /// </value>
        bool Multiselect { get; set; }

        /// <summary>
        ///     Show the Save File Dialog.
        /// </summary>
        /// <returns></returns>
        bool ShowDialog();
    }

    /// <summary>
    ///     Allows to the user to select a specific type of file.
    /// </summary>
    public interface IOpenFileDialog<TFile> where TFile : IFile
    {
        /// <summary>
        ///     Allows the user to select multiple files.
        /// </summary>
        /// <returns></returns>
        IEnumerable<string> ShowSelectFileDialog();
    }
}