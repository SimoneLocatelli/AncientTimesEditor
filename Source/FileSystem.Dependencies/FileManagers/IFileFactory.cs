#region Usings

using Editor.FileSystem.Dependencies.FileEntities;
using System.ComponentModel.Composition;

#endregion Usings

namespace Editor.FileSystem.Dependencies.FileManagers
{
    /// <summary>
    ///     Creates IFile instances
    /// </summary>
    [InheritedExport]
    public interface IFileFactory
    {
        /// <summary>
        ///     Reads the file stored at the specified input path and converts it into an Editor File.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns></returns>
        IFile ConvertToFile(string filePath);

        /// <summary>
        ///     Creates an instance of the specified file type.
        /// </summary>
        /// <typeparam name="TFile">The type of the file.</typeparam>
        /// <returns></returns>
        IFile CreateFile<TFile>() where TFile : IFile;
    }
}