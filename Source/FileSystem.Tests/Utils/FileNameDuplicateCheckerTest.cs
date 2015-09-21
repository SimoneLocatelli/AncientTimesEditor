using Editor.FileSystem.Dependencies;
using Editor.FileSystem.Dependencies.FileEntities;
using Editor.FileSystem.FileEntities;
using Editor.FileSystem.Tests.Utils.MockData;
using Editor.FileSystem.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO.Fakes;
using Tests.Common;

namespace Editor.FileSystem.Tests.Utils
{
    [TestClass]
    public class FileNameDuplicateCheckerTest : EditorBaseTestClass
    {
        [TestMethod]
        public void CheckNameOrGetValidDirectory()
        {
            TestWithShims(() =>
            {
                var directory = new Directory("Test", @"C:\");

                ShimDirectory.ExistsString = s =>
                {
                    if (s == "C:\\Test")
                    {
                        return true;
                    }
                    return s == "C:\\Test (1)";
                };

                var result = SetupClass().CheckNameOrGetValid(directory);

                Assert.AreEqual("Test (2)", result);
            });
        }

        [TestMethod]
        public void CheckNameOrGetValidDirectoryThatNotExists()
        {
            TestWithShims(() =>
            {
                var directory = new Directory("Test", @"C:\");

                ShimDirectory.ExistsString = s => false;
                var result = SetupClass().CheckNameOrGetValid(directory);

                Assert.AreEqual(directory.Name, result);
            });
        }

        [TestMethod]
        public void CheckNameOrGetValidFile()
        {
            TestWithShims(() =>
            {
                var fakeFile = new FakeFile();

                ShimFile.ExistsString = s =>
                {
                    if (s == "C:\\Test.fake")
                    {
                        return true;
                    }
                    return s == "C:\\Test (1).fake";
                };

                var result = SetupClass().CheckNameOrGetValid(fakeFile);

                Assert.AreEqual("Test (2).fake", result);
            });
        }

        [TestMethod]
        public void CheckNameOrGetValidFileThatNotExists()
        {
            TestWithShims(() =>
            {
                var fakeFile = new FakeFile();

                ShimFile.ExistsString = s => false;
                var result = SetupClass().CheckNameOrGetValid(fakeFile);

                Assert.AreEqual(fakeFile.FullName, result);
            });
        }

        [TestMethod]
        public void CheckNameOrGetValidWithNullFile()
        {
            TestExpectedArgumentException<ArgumentNullException>(
                () => SetupClass().CheckNameOrGetValid(null), "file");
        }

        private FileNameDuplicateChecker SetupClass()
        {
            return new FileNameDuplicateChecker();
        }

        private class FakeFile : IFile
        {
            /// <summary>
            ///     Gets the file information.
            /// </summary>
            /// <value> The file information. </value>
            public IFileInfo FileInfo
            {
                get { return new FakeFileInfo(); }
            }

            /// <summary>
            ///     Gets the full name, composed by the file name and its extension.
            /// </summary>
            /// <value> The full name. </value>
            public string FullName
            {
                get { return "Test.fake"; }
            }

            /// <summary>
            ///     Gets the full path, composed by the path and the full name.
            /// </summary>
            /// <value> The full path. </value>
            public string FullPath
            {
                get { return @"C:\Test.fake"; }
            }

            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value> The name. </value>
            public string Name
            {
                get { return "Test"; }
            }

            /// <summary>
            ///     Gets the path.
            /// </summary>
            /// <value> The path. </value>
            public string Path
            {
                get { return @"C:\"; }
            }
        }
    }
}