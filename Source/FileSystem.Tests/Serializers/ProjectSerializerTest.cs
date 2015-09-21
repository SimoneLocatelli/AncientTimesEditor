#region Usings

using Editor.FileSystem.Dependencies.FileEntities;
using Editor.FileSystem.Dependencies.FileEntities.Fakes;
using Editor.FileSystem.Dependencies.FileManagers.Fakes;
using Editor.FileSystem.Serializers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Common;

#endregion Usings

namespace Editor.FileSystem.Tests.Serializers
{
    [TestClass]
    public class ProjectSerializerTest : EditorBaseTestClass
    {
        private readonly IProject project = new StubIProject
        {
            NameGet = () => "Test",
            FullPathGet = () => "C:\\Test",
            PathGet = () => "C:\\"
        };

        [TestMethod]
        public void WhenAProjectFullPathIsInvalidItWillCallDependencies()
        {
            var xmlSerializerIsCalled = false;
            var xmlSerializerSpy = new StubIXmlSerializer
            {
                SerializeObject = o =>
                {
                    xmlSerializerIsCalled = true;
                    return "Result";
                }
            };

            var fileWriterIsCalled = false;
            var fileWriterSpy = new StubIFileWriter
            {
                WriteStringString = (s, s1) => { fileWriterIsCalled = true; }
            };

            var projectSerializer = new ProjectSerializer(xmlSerializerSpy, fileWriterSpy);

            projectSerializer.Serialize(project);

            Assert.IsTrue(xmlSerializerIsCalled);
            Assert.IsTrue(fileWriterIsCalled);
        }

        [TestMethod]
        public void WhenProjectIsInvalidItWillFail()
        {
            TestExpectedArgumentException<ArgumentNullException>(
                () => BuildProjectSerializer().Serialize(null), "project");
        }

        private ProjectSerializer BuildProjectSerializer()
        {
            return new ProjectSerializer(new StubIXmlSerializer(), new StubIFileWriter());
        }
    }
}