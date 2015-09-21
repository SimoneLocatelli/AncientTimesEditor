using Editor.FileSystem.Serializers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Common;

namespace Editor.FileSystem.Tests.Serializers
{
    public class FakeSerializable
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

    [TestClass]
    public class XmlSerializerTest : EditorBaseTestClass
    {
        [TestMethod]
        public void Serialize()
        {
            const string expectedResult =
                "<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n<FakeSerializable xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\r\n  <Id>0</Id>\r\n</FakeSerializable>";

            var result = new XmlSerializer().Serialize(new FakeSerializable());

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(string));
            Assert.AreEqual(expectedResult, result);
        }
    }
}