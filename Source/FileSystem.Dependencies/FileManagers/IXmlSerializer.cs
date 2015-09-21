using System.ComponentModel.Composition;

namespace Editor.FileSystem.Dependencies.FileManagers
{
    /// <summary>
    ///     A generic Xml serializer
    /// </summary>
    [InheritedExport]
    public interface IXmlSerializer
    {
        /// <summary>
        ///     Serializes the input object into an xml string.
        /// </summary>
        /// <param name="serializable"> The serializable. </param>
        /// <returns></returns>
        string Serialize(object serializable);
    }
}