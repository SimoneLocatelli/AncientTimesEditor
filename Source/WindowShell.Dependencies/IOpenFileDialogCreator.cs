using Editor.FileSystem.Dependencies.FileEntities;
using System.ComponentModel.Composition;

namespace Editor.WindowShell.Dependencies
{
    /// <summary>
    ///     Manage the user interaction with a Dialog to open a file.
    /// </summary>
    [InheritedExport]
    public interface IOpenFileDialogCreator
    {
        ///// <summary>
        ///// Creates a save file dialog based on the specified file information.
        ///// </summary>
        ///// <typeparam name="TFile">The type of the file.</typeparam>
        ///// <returns></returns>
        //IOpenFileDialog Open<TFile>() where TFile : IFile, new();

        IOpenFileDialog Open(string description, string extension);

        IOpenFileDialog Open(IFile file);
    }
}