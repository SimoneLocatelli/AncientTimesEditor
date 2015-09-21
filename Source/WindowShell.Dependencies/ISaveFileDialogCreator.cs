#region Usings

using Editor.FileSystem.Dependencies.FileEntities;
using System.ComponentModel.Composition;

#endregion Usings

namespace Editor.WindowShell.Dependencies
{
    /// <summary>
    ///     Manage the user interaction with a Dialog to save a file.
    /// </summary>
    [InheritedExport]
    public interface ISaveFileDialogCreator
    {
        ISaveFileDialog Create(string description, string extension);

        ISaveFileDialog Create(IFile file);
    }
}