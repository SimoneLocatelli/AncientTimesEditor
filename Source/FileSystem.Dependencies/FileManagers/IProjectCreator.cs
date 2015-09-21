using Editor.FileSystem.Dependencies.FileEntities;

namespace Editor.FileSystem.Dependencies.FileManagers
{
    /// <summary>
    /// A factory class to create <see cref="IProject"/> instance
    /// </summary>
    public interface IProjectFactory : IFileFactory<IProject>
    {
    }
}