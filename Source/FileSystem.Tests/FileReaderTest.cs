namespace Editor.FileSystem.Tests
{
    #region Usings

    using global::Tests.Common;
    using IO;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.IO;

    #endregion Usings

    [TestClass]
    public class FileReaderTest : EditorBaseTestClass<FileReader>
    {
        #region Properties

        private const string TestFolder = @"C:\EditorAncientTimesTests";

        #endregion Properties

        [TestCleanup]
        public void Cleanup()
        {
            if (!Directory.Exists(TestFolder)) return;

            Directory.Delete(TestFolder, true);
        }

        [TestInitialize]
        public void Initialize()
        {
            Cleanup();

            Directory.CreateDirectory(TestFolder);
        }

        [TestMethod]
        public void Read()
        {
            Test(resolver =>
            {
                File.WriteAllText(TestFolder + "\\FileTest", @"TEST");

                var result = ResolveClassToTest(resolver).Read(TestFolder + "\\FileTest");
                Assert.IsFalse(string.IsNullOrWhiteSpace(result));
                Assert.AreEqual(result, @"TEST");

                File.Delete(TestFolder + "\\FileTest");
            });
        }

        [TestMethod]
        public void ReadWithNotExistingFile()
        {
            TestExpectedException<InvalidOperationException>(
                resolver => ResolveClassToTest(resolver).Read(TestFolder + "\\FileTest_"),
                Resources.FileReaderFileNotFoundExceptionMessage);
        }

        [TestMethod]
        public void ReadWithFilePathInvalid()
        {
            TestExpectedArgumentException<ArgumentException>(
                resolver => ResolveClassToTest(resolver).Read(null),
                "filePath");
            TestExpectedArgumentException<ArgumentException>(resolver => ResolveClassToTest(resolver).Read(""),
                "filePath");
            TestExpectedArgumentException<ArgumentException>(
                resolver => ResolveClassToTest(resolver).Read(" "),
                "filePath");
        }
    }
}