using Editor.FileSystem.Dependencies.FileEntities;

namespace Editor.FileSystem.Dependencies.FileManagers
{
    /// <summary>
    /// Factory class associated to a specific file type.
    /// </summary>
    /// <typeparam name="TFile">The type of the file.</typeparam>
    public interface IFileFactory<TFile> where TFile : IFile
    {
        /// <summary>
        ///     Creates a file based on provided file information.
        /// </summary>
        /// <param name="file"> The file to create.</param>
        TFile Create(TFile file);

        /// <summary>
        ///     Creates a file extracting the path and the fullname in the
        ///     provided fullname.
        /// </summary>
        /// <param name="fullName">The fullname of the file to create.</param>
        /// <returns></returns>
        TFile Create(string fullName);
    }
}