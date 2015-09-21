#region Usings

using Editor.FileSystem.Dependencies.FileEntities;
using System.ComponentModel.Composition;

#endregion Usings

namespace Editor.FileSystem.Dependencies.FileManagers
{
    /// <summary>
    ///     A deserializator for the <see cref="IProject" /> file type.
    /// </summary>
    [InheritedExport]
    public interface IProjectDeserializer
    {
        /// <summary>
        ///     Deserializes the input project reading it from the location where is stored.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns></returns>
        IProject Deserialize(string filePath);
    }
}