using Editor.FileSystem.Dependencies.Facades.Fakes;
using Editor.FileSystem.Dependencies.FileManagers.Fakes;
using Editor.FileSystem.Facades;
using Editor.FileSystem.FileEntities;
using Editor.FileSystem.FileEntities.Serializables;
using Editor.FileSystem.Serializers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Common;

namespace Editor.FileSystem.Tests.Serializers
{
    [TestClass]
    public class
        ProjectDeserializerTest : EditorBaseTestClass
    {
        private const string ProjectName = "TestProject";
        private static readonly Project Project = new Project(ProjectName, "C:\\");

        [TestCleanup]
        public void CleanUp()
        {
            FileBase.PathFacade = new PathFacade();
        }

        [TestInitialize]
        public void Setup()
        {
            FileBase.PathFacade = new StubIPathFacade
            {
                GetFileNameWithoutExtensionString = s => "TestProject",
                GetDirectoryNameString = s => "C:\\"
            };
        }

        [TestMethod]
        public void WhenDeserializeItWillReturnProjectRead()
        {
            var deserializerStub = new StubIXmlDeserializer();
            deserializerStub.DeserializeOf1String(contents => new ProjectSerializable(Project));

            var project = BuildProjectDeserializer(deserializerStub).Deserialize("C:\\TestFilePath");

            Assert.IsNotNull(project);
            Assert.AreEqual(Project.Name, project.Name);
            Assert.AreEqual(Project.Path, project.Path);
        }

        [TestMethod]
        public void WhenDeserializeWithInvalidPathItWillFail()
        {
            const string parameterName = "filePath";

            TestExpectedArgumentException<ArgumentException>(
                () => BuildProjectDeserializer().Deserialize(null), parameterName);
            TestExpectedArgumentException<ArgumentException>(
                () => BuildProjectDeserializer().Deserialize(string.Empty), parameterName);
            TestExpectedArgumentException<ArgumentException>(() => BuildProjectDeserializer().Deserialize(" "),
                parameterName);
        }

        private static ProjectDeserializer BuildProjectDeserializer(StubIXmlDeserializer deserializerStub = null)
        {
            deserializerStub = deserializerStub ?? new StubIXmlDeserializer();

            return new ProjectDeserializer(deserializerStub, new StubIFileReader());
        }
    }
}