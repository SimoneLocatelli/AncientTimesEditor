using Editor.FileSystem.Dependencies.FileEntities;
using System.ComponentModel.Composition;

namespace Editor.FileSystem.Dependencies.FileManagers
{
    /// <summary>
    ///     A generic Xml deserializer
    /// </summary>
    [InheritedExport]
    public interface IXmlDeserializer
    {
        /// <summary>
        /// Deserializes the input string into an object.
        /// </summary>
        /// <typeparam name="TEntitySerialized">The type of the entity serialized.</typeparam>
        /// <param name="serializedFileContents">The contents of the serialized file.</param>
        /// <returns></returns>
        TEntitySerialized Deserialize<TEntitySerialized>(string serializedFileContents);
    }
}