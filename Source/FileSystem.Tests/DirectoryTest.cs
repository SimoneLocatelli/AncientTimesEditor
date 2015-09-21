namespace Dependencies.Tests.FileSystem
{
    #region Usings

    using Editor.FileSystem.FileEntities;
    using global::Tests.Common;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;

    #endregion Usings

    [TestClass]
    public class DirectoryTest : EditorBaseTestClass
    {
        [TestMethod]
        public void CreateInstanceWithNameAndPath()
        {
            Test(resolver =>
            {
                var directory = new Directory("TestDirectory", "C:\\");

                Assert.AreEqual("TestDirectory", directory.Name);
                Assert.AreEqual("TestDirectory", directory.FullName);
                Assert.AreEqual("C:\\", directory.Path);
                Assert.AreEqual("C:\\TestDirectory", directory.FullPath);
                Assert.AreEqual("C:\\TestDirectory", directory.ChildrenPath);
                Assert.AreEqual(0, directory.InnerFiles.Count);
            });
        }

        [TestMethod]
        public void CreateInstanceWithFullName()
        {
            Test(resolver =>
            {
                var directory = new Directory("C:\\TestDirectory");

                Assert.AreEqual("TestDirectory", directory.Name);
                Assert.AreEqual("TestDirectory", directory.FullName);
                Assert.AreEqual("C:\\", directory.Path);
                Assert.AreEqual("C:\\TestDirectory", directory.FullPath);
                Assert.AreEqual("C:\\TestDirectory", directory.ChildrenPath);
                Assert.AreEqual(0, directory.InnerFiles.Count);
            });
        }

        public void CreateInstanceWithInvalidName()
        {
            TestExpectedArgumentException<ArgumentException>(resolver => new Directory(null, "C:\\"), "name");
            TestExpectedArgumentException<ArgumentException>(resolver => new Directory("", "C:\\"), "name");
            TestExpectedArgumentException<ArgumentException>(resolver => new Directory("  ", "C:\\"), "name");
        }

        public void CreateInstanceWithInvalidPath()
        {
            TestExpectedArgumentException<ArgumentException>(resolver => new Directory("Test", null), "path");
            TestExpectedArgumentException<ArgumentException>(resolver => new Directory("Test", ""), "path");
            TestExpectedArgumentException<ArgumentException>(resolver => new Directory("Test", " "), "path");
        }
    }
}