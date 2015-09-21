using Editor.FileSystem.FileEntities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Common;

namespace Editor.FileSystem.Tests.FileEntities
{
    [TestClass]
    public class DirectoryTest : EditorBaseTestClass
    {
        private const int DefaultInnerFilesCount = 0;
        private const string DirectoryFullPath = DirectoryLocation + DirectoryName;
        private const string DirectoryLocation = "C:\\";
        private const string DirectoryName = "TestDirectory";

        [TestMethod]
        public void WhenInitializedWithFullPathItWillContainCorrectInformation()
        {
            AssertDirectoryIsCorrectlyInitialized(new Directory("C:\\TestDirectory"));
        }

        [TestMethod]
        public void WhenInitializedWithInvalidNameItWillFail()
        {
            const string parameterName = "name";

            TestExpectedArgumentException<ArgumentException>(() => new Directory(null, DirectoryLocation),
                parameterName);
            TestExpectedArgumentException<ArgumentException>(() => new Directory("", DirectoryLocation),
                parameterName);
            TestExpectedArgumentException<ArgumentException>(() => new Directory("  ", DirectoryLocation),
                parameterName);
        }

        [TestMethod]
        public void WhenInitializedWithInvalidPathItWillFail()
        {
            const string parameterName = "path";

            TestExpectedArgumentException<ArgumentException>(() => new Directory(DirectoryName, null),
                parameterName);
            TestExpectedArgumentException<ArgumentException>(() => new Directory(DirectoryName, ""), parameterName);
            TestExpectedArgumentException<ArgumentException>(() => new Directory(DirectoryName, " "),
                parameterName);
        }

        [TestMethod]
        public void WhenInitializedWithNameAndPathItWillContainCorrectInformation()
        {
            AssertDirectoryIsCorrectlyInitialized(new Directory("TestDirectory", "C:\\"));
        }

        private static void AssertDirectoryIsCorrectlyInitialized(Directory directory)
        {
            Assert.AreEqual(DirectoryName, directory.Name);
            Assert.AreEqual(DirectoryName, directory.FullName);
            Assert.AreEqual(DirectoryLocation, directory.Path);
            Assert.AreEqual(DirectoryFullPath, directory.FullPath);
            Assert.AreEqual(DirectoryFullPath, directory.ChildrenPath);
            Assert.AreEqual(DefaultInnerFilesCount, directory.InnerFiles.Count);
        }
    }
}