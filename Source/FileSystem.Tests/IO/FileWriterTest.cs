using Editor.FileSystem.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO.Fakes;
using Tests.Common;

namespace Editor.FileSystem.Tests.IO
{
    /// <summary>
    ///     These Tests are more like Integration Test 'cause they
    ///     actually make assert on files created on disk.
    ///     They seems reliable, consider to swith to a different way to
    ///     make these tests if they are not really predicatble.
    /// </summary>
    [TestClass]
    public class FileWriterTest : EditorBaseTestClass
    {
        private const string FileContents = "Contents";
        private const string FilePath = "C:\\MyPath";

        [TestMethod]
        public void WhenContentsInvalidItWillFail()
        {
            const string parameterName = "contents";

            TestExpectedArgumentException<ArgumentNullException>(
                () => SetupClass().Write(null, ""), parameterName);
        }

        [TestMethod]
        public void WhenPathIsInvalidItWillFail()
        {
            const string parameterName = "filePath";
            TestExpectedArgumentException<ArgumentException>(
                () => SetupClass().Write(FileContents, null),
                parameterName);
            TestExpectedArgumentException<ArgumentException>(
                () => SetupClass().Write(FileContents, ""),
                parameterName);
            TestExpectedArgumentException<ArgumentException>(
                () => SetupClass().Write(FileContents, " "),
                parameterName);
        }

        [TestMethod]
        public void WhenWriteItWillCallWriteAllTextMethod()
        {
            TestWithShims(() =>
            {
                var hasBeenCalled = true;

                ShimFile.WriteAllTextStringString = (path, contents) =>
                {
                    hasBeenCalled = true;
                    Assert.AreEqual(FilePath, path);
                    Assert.AreEqual(FileContents, contents);
                };

                SetupClass().Write(FileContents, FilePath);
                Assert.IsTrue(hasBeenCalled);
            });
        }

        private static FileWriter SetupClass()
        {
            return new FileWriter();
        }
    }
}