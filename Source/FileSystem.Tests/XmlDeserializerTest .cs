namespace Editor.FileSystem.Tests
{
    #region Usings

    using FileEntities;
    using global::FileSystem.Dependencies.FileEntities;
    using global::Tests.Common;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Serializers;

    #endregion Usings

    [TestClass]
    public class XmlDeserializerTest : EditorBaseTestClass<XmlDeserializer>
    {
        #region Methods

        [TestMethod]
        public void ShouldDeserializable()
        {
            const string toBeDeserializedXml =
                "<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n<Directory xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\r\n </Directory>";

            Test(resolver =>
            {
                var deserializedDirectory = ResolveClassToTest(resolver).Deserialize<Directory>(toBeDeserializedXml);

                Assert.IsNotNull(deserializedDirectory);
                Assert.IsInstanceOfType(deserializedDirectory, typeof(Directory));
            });
        }

        #endregion Methods
    }
}