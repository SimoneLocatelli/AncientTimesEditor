using Editor.FileSystem.Dependencies.Facades.Fakes;
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
    public class FileReaderTest : EditorBaseTestClass
    {
        private const string Contents = @"TestContents";
        private const string FileName = "FileTest";
        private const string FilePath = TestFolder + FileName;
        private const string TestFolder = @"C:\EditorAncientTimesTests\";

        [TestMethod]
        public void Read()
        {
            var fileReader = new FileReader
            {
                FileFacade = new StubIFileFacade
                {
                    ExistsString = s => true,
                    OpenTextString = s => new StubStreamReader(s)
                    {
                        ReadToEnd01 = () => Contents
                    }
                }
            };

            var result = fileReader.Read(FilePath);

            Assert.AreEqual(result, Contents);
        }

        [TestMethod]
        public void WhenFileDoesntExistItWillFail()
        {
            var fileReader = new FileReader
            {
                FileFacade = new StubIFileFacade
                {
                    ExistsString = s => false
                }
            };

            TestExpectedException<InvalidOperationException>(
                () => fileReader.Read(FilePath),
                Resources.FileReaderFileNotFoundExceptionMessage);
        }

        [TestMethod]
        public void WhenFilePathToReadIsInvalidItWillFail()
        {
            const string parameterName = "filePath";

            TestExpectedArgumentException<ArgumentException>(
                () => new FileReader().Read(null),
                parameterName);
            TestExpectedArgumentException<ArgumentException>(() => new FileReader().Read(""),
                parameterName);
            TestExpectedArgumentException<ArgumentException>(
                () => new FileReader().Read(" "),
                parameterName);
        }
    }
}