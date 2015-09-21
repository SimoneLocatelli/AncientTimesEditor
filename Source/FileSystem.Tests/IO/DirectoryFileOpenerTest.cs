using Editor.FileSystem.Dependencies.Facades;
using Editor.FileSystem.Dependencies.Facades.Fakes;
using Editor.FileSystem.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using Tests.Common;

namespace Editor.FileSystem.Tests.IO
{
    [TestClass]
    public class DirectoryFileOpenerTest : EditorBaseTestClass
    {
        [TestMethod, ExpectedException(typeof (IOException))]
        public void WhenFileDoesntExistItWillFailToOpen()
        {
            var directoryFacade = new StubIDirectoryFacade
            {
                ExistsString = s => false
            };

            SetupClass(directoryFacade).Open("Test");
        }

        [TestMethod]
        public void WhenFilePathIsInvalidItWillFailToOpen()
        {
            TestExpectedArgumentException<ArgumentException>(() => SetupClass().Open(default(string)), "filePath");
            TestExpectedArgumentException<ArgumentException>(() => SetupClass().Open(string.Empty), "filePath");
            TestExpectedArgumentException<ArgumentException>(() => SetupClass().Open("  "), "filePath");
        }

        [TestMethod]
        public void WhenFilePathIsValidItWillReturnDirectoryInfo()
        {
            const string name = "Test";
            const string path = "C:\\";
            const string filePath = path + name;
            var directory = SetupClass().Open(filePath);

            Assert.IsNotNull(directory);
            Assert.AreEqual(name, directory.Name);
            Assert.AreEqual(path, directory.Path);
        }

        private static DirectoryFileOpener SetupClass(IDirectoryFacade directoryFacade = null)
        {
            directoryFacade = directoryFacade ?? new StubIDirectoryFacade
            {
                ExistsString = s => true
            };

            var a = new DirectoryFileOpener();

            return new DirectoryFileOpener
            {
                DirectoryFacade = directoryFacade
            };
        }
    }
}