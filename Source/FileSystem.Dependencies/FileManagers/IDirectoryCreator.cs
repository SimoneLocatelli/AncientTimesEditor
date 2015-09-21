#region Usings

using Editor.FileSystem.Dependencies.FileEntities;

#endregion Usings

namespace Editor.FileSystem.Dependencies.FileManagers
{
    /// <summary>
    ///     It aims to manage the creation of new folders.
    /// </summary>
    public interface IDirectoryFactory : IFileFactory<IDirectory>
    {
        /// <summary>
        ///     Creates the specified file container.
        /// </summary>
        /// <param name="parentDirectory">The parent directory where the new folder is going to be created.</param>
        /// <returns></returns>
        IDirectory CreateWithDefaultName(IFileContainer parentDirectory);
    }
}