namespace Editor.FileSystem.Tests
{
    #region Usings

    using global::Tests.Common;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Serializers;

    #endregion Usings

    public class FakeSerializable
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

    [TestClass]
    public class XmlSerializerTest : EditorBaseTestClass<XmlSerializer>
    {
        #region Methods

        [TestMethod]
        public void Serialize()
        {
            const string expectedResult =
                "<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n<FakeSerializable xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\r\n  <Id>0</Id>\r\n</FakeSerializable>";

            Test(resolver =>
            {
                var result = ResolveClassToTest(resolver).Serialize(new FakeSerializable());

                Assert.IsNotNull(result);
                Assert.IsInstanceOfType(result, typeof (string));
                Assert.AreEqual(expectedResult, result);
            });
        }

        #endregion Methods
    }
}