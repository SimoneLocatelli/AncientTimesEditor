namespace Editor.FileSystem.Tests
{
    #region Usings

    using FileEntities;
    using global::FileSystem.Dependencies;
    using global::FileSystem.Dependencies.FileEntities;
    using global::Tests.Common;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.IO.Fakes;
    using Utils;

    #endregion Usings

    [TestClass]
    public class FileNameDuplicateCheckerTest : EditorBaseTestClass<FileNameDuplicateChecker>
    {
        #region Classes

        private class FakeFileInfo : IFileInfo
        {
            /// <summary>
            /// Gets the default name of the file to use when a new item of this type is being created.
            /// </summary>
            /// <value> The default name of the file. </value>
            public string DefaultFileName { get; private set; }

            /// <summary>
            /// Gets the description of the file type.
            /// </summary>
            /// <value> The description. </value>
            public string Description { get; private set; }

            /// <summary>
            /// Gets the file extension.
            /// </summary>
            /// <value> The extension. </value>
            public string Extension
            {
                get { return "fake"; }
            }
        }

        private class FakeFile : IFile
        {
            /// <summary>
            /// Gets the file information.
            /// </summary>
            /// <value> The file information. </value>
            public IFileInfo FileInfo
            {
                get { return new FakeFileInfo(); }
            }

            /// <summary>
            /// Gets the full name, composed by the file name and its extension.
            /// </summary>
            /// <value> The full name. </value>
            public string FullName
            {
                get { return "Test.fake"; }
            }

            /// <summary>
            /// Gets the full path, composed by the path and the full name.
            /// </summary>
            /// <value> The full path. </value>
            public string FullPath
            {
                get { return @"C:\Test.fake"; }
            }

            /// <summary>
            /// Gets the name.
            /// </summary>
            /// <value> The name. </value>
            public string Name
            {
                get { return "Test"; }
            }

            /// <summary>
            /// Gets the path.
            /// </summary>
            /// <value> The path. </value>
            public string Path
            {
                get { return @"C:\"; }
            }
        }

        #endregion Classes

        [TestMethod]
        public void CheckNameOrGetValidWithNullFile()
        {
            TestExpectedArgumentException<ArgumentNullException>(
                resolver => ResolveClassToTest(resolver).CheckNameOrGetValid(null), "file");
        }

        [TestMethod]
        public void CheckNameOrGetValidDirectoryThatNotExists()
        {
            TestWithShims(resolver =>
            {
                var directory = new Directory("Test", @"C:\");

                ShimDirectory.ExistsString = s => false;
                var result = ResolveClassToTest(resolver).CheckNameOrGetValid(directory);

                Assert.AreEqual(directory.Name, result);
            });
        }

        [TestMethod]
        public void CheckNameOrGetValidDirectory()
        {
            TestWithShims(resolver =>
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

                var result = ResolveClassToTest(resolver).CheckNameOrGetValid(directory);

                Assert.AreEqual("Test (2)", result);
            });
        }

        [TestMethod]
        public void CheckNameOrGetValidFile()
        {
            TestWithShims(resolver =>
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

                var result = ResolveClassToTest(resolver).CheckNameOrGetValid(fakeFile);

                Assert.AreEqual("Test (2).fake", result);
            });
        }

        [TestMethod]
        public void CheckNameOrGetValidFileThatNotExists()
        {
            TestWithShims(resolver =>
            {
                var fakeFile = new FakeFile();

                ShimFile.ExistsString = s => false;
                var result = ResolveClassToTest(resolver).CheckNameOrGetValid(fakeFile);

                Assert.AreEqual(fakeFile.FullName, result);
            });
        }
    }
}