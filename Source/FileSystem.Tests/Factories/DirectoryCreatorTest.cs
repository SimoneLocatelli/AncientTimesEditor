using Editor.FileSystem.Dependencies.Facades.Fakes;
using Editor.FileSystem.Dependencies.Fakes;
using Editor.FileSystem.Dependencies.FileEntities;
using Editor.FileSystem.Dependencies.FileEntities.Fakes;
using Editor.FileSystem.Dependencies.Utils.Fakes;
using Editor.FileSystem.Factories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Common;

namespace Editor.FileSystem.Tests.Factories
{
    [TestClass]
    public class DirectoryFactoryTest : EditorBaseTestClass
    {
        private const string DirectoryDefaultName = "DefaultFileName";

        [TestMethod]
        public void WhenDependenciesAreInvalidItWillFail()
        {
            TestExpectedArgumentException<ArgumentNullException>(() => new DirectoryFactory(null),
                "fileNameDuplicateChecker");
        }

        [TestMethod]
        public void WhenDirectoryFacadeIsInvalidItWillFail()
        {
            TestExpectedArgumentException<ArgumentNullException>(() => BuildDirectoryCreator().DirectoryFacade = null,
                "DirectoryFacade");
        }

        [TestMethod]
        public void WhenDirectoryIsInvalidItWillFailToCreate()
        {
            TestExpectedArgumentException<ArgumentNullException>(
                () => BuildDirectoryCreator().Create(default(IDirectory)), "directory");
        }

        [TestMethod]
        public void WhenDirectoryNameIsInvalidItWillFailToCreate()
        {
            var directoryWithNullName = new StubIDirectory { NameGet = () => null };
            var directoryWithEmptyName = new StubIDirectory { NameGet = () => string.Empty };
            var directoryWithWhiteSpaceName = new StubIDirectory { NameGet = () => " " };

            TestExpectedArgumentException<ArgumentException>(
                () => BuildDirectoryCreator().Create(directoryWithNullName), "Name");
            TestExpectedArgumentException<ArgumentException>(
                () => BuildDirectoryCreator().Create(directoryWithEmptyName), "Name");
            TestExpectedArgumentException<ArgumentException>(
                () => BuildDirectoryCreator().Create(directoryWithWhiteSpaceName), "Name");
        }

        [TestMethod]
        public void WhenDirectoryPathIsInvalidItWillFailToCreate()
        {
            var directoryWithNullPath = new StubIDirectory { NameGet = () => "Test", PathGet = () => null };
            var directoryWithEmptyPath = new StubIDirectory { NameGet = () => "Test", PathGet = () => string.Empty };
            var directoryWithWhiteSpacePath = new StubIDirectory { NameGet = () => "Test", PathGet = () => " " };

            TestExpectedArgumentException<ArgumentException>(
                () => BuildDirectoryCreator().Create(directoryWithNullPath), "Path");
            TestExpectedArgumentException<ArgumentException>(
                () => BuildDirectoryCreator().Create(directoryWithEmptyPath), "Path");
            TestExpectedArgumentException<ArgumentException>(
                () => BuildDirectoryCreator().Create(directoryWithWhiteSpacePath), "Path");
        }

        [TestMethod]
        public void WhenFileContainerIsInvalidItWillFailToCreateFolderWithDefaultName()
        {
            TestExpectedArgumentException<ArgumentNullException>(
                () => BuildDirectoryCreator().CreateWithDefaultName(default(IFileContainer)), "parentDirectory");
        }

        [TestMethod]
        public void WhenFileContainerIsValidIWillCreateFolderWithDefaultName()
        {
            const string directoryPath = "C:\\";

            var directoryCreated = BuildDirectoryCreator().CreateWithDefaultName(new StubIFileContainer
            {
                ChildrenPathGet = () => directoryPath
            });

            Assert.IsNotNull(directoryCreated);
            Assert.IsNotNull(DirectoryDefaultName, directoryCreated.Name);
            Assert.IsNotNull(directoryPath, directoryCreated.Path);
        }

        [TestMethod]
        public void WhenPassingInvalidFullNameItWillFail()
        {
            TestExpectedArgumentException<ArgumentException>(() => BuildDirectoryCreator().Create(default(string)),
                "fullName");
            TestExpectedArgumentException<ArgumentException>(() => BuildDirectoryCreator().Create(string.Empty),
                "fullName");
            TestExpectedArgumentException<ArgumentException>(() => BuildDirectoryCreator().Create("  "), "fullName");
        }

        [TestMethod]
        public void WhenPassingValidDirectoryItWillReturnItWithCorrectInformation()
        {
            const string name = "Test";
            const string path = "C:\\";

            var directory = new StubIDirectory { NameGet = () => name, PathGet = () => path };

            var directoryCreated = BuildDirectoryCreator().Create(directory);

            Assert.IsNotNull(directoryCreated);
            Assert.AreEqual(name, directoryCreated.Name);
            Assert.AreEqual(path, directoryCreated.Path);
        }

        [TestMethod]
        public void WhenPassingValidFullNameItWillReturnItWithCorrectInformation()
        {
            const string name = "Test";
            const string path = "C:\\";
            const string fullName = path + name;

            var directoryCreated = BuildDirectoryCreator().Create(fullName);

            Assert.IsNotNull(directoryCreated);
            Assert.AreEqual(name, directoryCreated.Name);
            Assert.AreEqual(path, directoryCreated.Path);
        }

        private static DirectoryFactory BuildDirectoryCreator()
        {
            var directoryFileInfo = new StubIFileInfo
            {
                DefaultFileNameGet = () => DirectoryDefaultName
            };

            return new DirectoryFactory(new StubIFileNameDuplicateChecker { CheckNameOrGetValidIFile = file => file.Name })
            {
                DirectoryFacade = new StubIDirectoryFacade(),
                DirectoryInfo = directoryFileInfo
            };
        }
    }
}