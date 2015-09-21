using Editor.FileSystem.Dependencies;
using Editor.FileSystem.Dependencies.FileEntities;
using Editor.FileSystem.Serializers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Xml.Serialization;
using Tests.Common;

namespace Editor.FileSystem.Tests.Serializers
{
    [TestClass]
    public class XmlDeserializerTest : EditorBaseTestClass
    {
        [TestMethod]
        public void WhenSerializedDirectoryEntityIsPassedItWillBeDeserialized()
        {
            const string serializedFileString =
                "<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n<FakeEntity xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\r\n </FakeEntity>";

            var deserializedDirectory = new XmlDeserializer().Deserialize<FakeEntity>(serializedFileString);

            Assert.IsNotNull(deserializedDirectory);
            Assert.IsInstanceOfType(deserializedDirectory, typeof(FakeEntity));
        }

        [Serializable]
        public class FakeEntity : IFile
        {
            [XmlIgnore]
            public IFileInfo FileInfo { get; set; }

            [XmlIgnore]
            public string FullName { get; set; }

            [XmlIgnore]
            public string FullPath { get; set; }

            [XmlIgnore]
            public string Name { get; set; }

            [XmlIgnore]
            public string Path { get; set; }
        }
    }
}