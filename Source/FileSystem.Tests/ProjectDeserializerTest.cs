namespace Editor.FileSystem.Tests
{
    #region Usings

    using FileEntities;
    using global::FileSystem.Dependencies.FileManagers.Fakes;
    using global::Tests.Common;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Serializers;
    using System;

    #endregion Usings

    [TestClass]
    public class ProjectDeserializerTest : EditorBaseTestClass<ProjectDeserializer>
    {
        [TestMethod]
        public void ShouldHaveDefaultValues()
        {
            Test(resolver => ResolveClassToTest(resolver));
        }

        [TestMethod]
        public void ShouldDeserializable()
        {
            Test(resolver =>
            {
                resolver.RegisterInstance(new StubIFileReader
                {
                    ReadString = filePath => "<project />"
                });

                var deserializerStub = new StubIXmlDeserializer();
                deserializerStub.DeserializeOf1String(contents => new Project("TestProject", "C:\\"));

                resolver.RegisterInstance(deserializerStub);

                var instance = ResolveClassToTest(resolver);
                var project = instance.Deserialize("TestFilePath");

                Assert.IsNotNull(project);
                Assert.AreEqual("TestProject", project.Name);
            });
        }

        [TestMethod]
        public void DeserializeWithInvalidFilePath()
        {
            TestExpectedArgumentException<ArgumentException>(resolver =>
            {
                var instance = ResolveClassToTest(resolver);

                instance.Deserialize(null);
            }, "filePath");

            TestExpectedArgumentException<ArgumentException>(resolver =>
            {
                var instance = ResolveClassToTest(resolver);

                instance.Deserialize("");
            }, "filePath");

            TestExpectedArgumentException<ArgumentException>(resolver =>
            {
                var instance = ResolveClassToTest(resolver);

                instance.Deserialize(" ");
            }, "filePath");
        }
    }
}