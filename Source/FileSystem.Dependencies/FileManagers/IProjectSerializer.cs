#region Usings

using Editor.FileSystem.Dependencies.FileEntities;
using System.ComponentModel.Composition;

#endregion Usings

namespace Editor.FileSystem.Dependencies.FileManagers
{
    /// <summary>
    ///     A serializator for the <see cref="IProject" /> entity
    /// </summary>
    [InheritedExport]
    public interface IProjectSerializer
    {
        /// <summary>
        ///     Serializes the specified project saving it on disk.
        /// </summary>
        /// <param name="project"> The project. </param>
        void Serialize(IProject project);
    }
}