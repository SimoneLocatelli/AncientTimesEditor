namespace Editor.FileSystem.Dependencies.FileManagers
{
    /// <summary>
    ///     Loads in memory a specific file type.
    /// </summary>
    /// <typeparam name="TFile">The type of the file.</typeparam>
    public interface IFileOpener<out TFile>
    {
        /// <summary>
        ///     Loads the file stored at the specified path.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns></returns>
        TFile Open(string filePath);
    }
}