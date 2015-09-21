#region Usings

using Editor.FileSystem.Dependencies.FileManagers;
using FluentChecker;
using System;
using System.IO;

#endregion Usings

namespace Editor.FileSystem.Serializers
{
    public class XmlDeserializer : IXmlDeserializer
    {
        /// <summary>
        ///     Deserializes the input string into an object.
        /// </summary>
        /// <param name="serializedFileContents">The contents of the serialized file.</param>
        /// <returns></returns>
        public TEntitySerialized Deserialize<TEntitySerialized>(string serializedFileContents)
        {
            Check.IfIsNullOrWhiteSpace(serializedFileContents)
                .Throw<ArgumentNullException>(() => serializedFileContents);

            var serializer = new System.Xml.Serialization.XmlSerializer(typeof (TEntitySerialized));

            using (TextReader reader = new StringReader(serializedFileContents))
            {
                return (TEntitySerialized) serializer.Deserialize(reader);
            }
        }
    }
}