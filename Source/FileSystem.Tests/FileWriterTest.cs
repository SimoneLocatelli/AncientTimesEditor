namespace Editor.FileSystem.Tests
{
    #region Usings

    using global::Tests.Common;
    using IO;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.IO.Fakes;

    #endregion Usings

    [TestClass]
    public class FileWriterTest : EditorBaseTestClass<FileWriter>
    {
        [TestMethod]
        public void Write()
        {
            TestWithShims(resolver =>
            {
                var hasBeenCalled = true;

                ShimFile.WriteAllTextStringString = (path, contents) =>
                {
                    hasBeenCalled = true;
                    Assert.AreEqual("path", path);
                    Assert.AreEqual("contents", contents);
                };

                ResolveClassToTest(resolver).Write("contents", "path");
                Assert.IsTrue(hasBeenCalled);
            });
        }

        [TestMethod]
        public void WriteWithContentsInvalid()
        {
            TestExpectedArgumentException<ArgumentNullException>(
                resolver => ResolveClassToTest(resolver).Write(null, ""), "contents");
        }

        [TestMethod]
        public void WriteWithPathInvalid()
        {
            TestExpectedArgumentException<ArgumentException>(
                resolver => ResolveClassToTest(resolver).Write("Test", null),
                "filePath");
            TestExpectedArgumentException<ArgumentException>(resolver => ResolveClassToTest(resolver).Write("Test", ""),
                "filePath");
            TestExpectedArgumentException<ArgumentException>(
                resolver => ResolveClassToTest(resolver).Write("Test", " "),
                "filePath");
        }
    }
}