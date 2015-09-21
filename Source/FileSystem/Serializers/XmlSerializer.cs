using Editor.FileSystem.Dependencies.FileManagers;
using FluentChecker;
using System;
using System.Globalization;
using System.IO;

namespace Editor.FileSystem.Serializers
{
    public class XmlSerializer : IXmlSerializer
    {
        public string Serialize(object serializable)
        {
            Check.IfIsNull(serializable).Throw<ArgumentNullException>(() => serializable);

            var stringwriter = new StringWriter(CultureInfo.CurrentCulture);

            var serializer = new System.Xml.Serialization.XmlSerializer(serializable.GetType());

            serializer.Serialize(stringwriter, serializable);

            return stringwriter.ToString();
        }
    }
}