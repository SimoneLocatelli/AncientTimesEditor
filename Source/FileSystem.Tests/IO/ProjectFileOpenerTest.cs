using Editor.FileSystem.Dependencies.FileEntities;
using Editor.FileSystem.Dependencies.FileEntities.Fakes;
using Editor.FileSystem.Dependencies.FileManagers.Fakes;
using Editor.FileSystem.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Tests.Common;

namespace Editor.FileSystem.Tests.IO
{
    [TestClass]
    public class ProjectFileOpenerTest : EditorBaseTestClass
    {
        public ProjectFileOpener SetupClass()
        {
            return new ProjectFileOpener(new StubIProjectDeserializer
            {
                DeserializeString = s => new StubIProject
                {
                    InnerFilesGet = () => new List<IFile>()
                }
            });
        }

        [TestMethod]
        public void WhenFilePathIsInvalidItWillFailToOpen()
        {
            TestExpectedArgumentException<ArgumentException>(() => SetupClass().Open(default(string)), "filePath");
            TestExpectedArgumentException<ArgumentException>(() => SetupClass().Open(string.Empty), "filePath");
            TestExpectedArgumentException<ArgumentException>(() => SetupClass().Open("  "), "filePath");
        }

        [TestMethod]
        public void WhenFilePathIsValidItWillReturnProjectFile()
        {
            const string name = "Test";
            const string path = "C:\\";
            const string fullPath = path + name;

            var projectFile = SetupClass().Open(fullPath);

            Assert.IsNotNull(projectFile);
            Assert.AreEqual(name, projectFile.Name);
            Assert.AreEqual(path, projectFile.Path);
        }
    }
}