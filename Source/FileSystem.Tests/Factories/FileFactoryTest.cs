using Editor.FileSystem.Dependencies.Exceptions;
using Editor.FileSystem.Dependencies.FileEntities;
using Editor.FileSystem.Dependencies.FileEntities.Fakes;
using Editor.FileSystem.Dependencies.FileManagers;
using Editor.FileSystem.Dependencies.FileManagers.Fakes;
using Editor.FileSystem.Dependencies.Utils.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Common;

namespace Editor.FileSystem.Tests.Factories
{
    [TestClass]
    public class FileFactoryTest : EditorBaseTestClass
    {
        [TestMethod]
        public void WhenFilePathIsInvalidItWillFailToConvertToFile()
        {
            TestExpectedArgumentException<ArgumentException>(() => SetupClass().ConvertToFile(default(string)),
                "filePath");
            TestExpectedArgumentException<ArgumentException>(() => SetupClass().ConvertToFile(string.Empty), "filePath");
            TestExpectedArgumentException<ArgumentException>(() => SetupClass().ConvertToFile("  "), "filePath");
        }

        [TestMethod, ExpectedException(typeof (FileTypeNotRecognizedException))]
        public void WhenPassingNotRecognizedFileTypeItWillFail()
        {
            SetupClass().CreateFile<StubIFile>();
        }

        [TestMethod]
        public void WhenPassingProjectFileTypeItWillCreateInstance()
        {
            var file = SetupClass().CreateFile<IProject>();

            Assert.IsNotNull(file);
            Assert.IsInstanceOfType(file, typeof (IProject));
        }

        private static FileFactory SetupClass()
        {
            IFileOpener<IDirectory> directoryOpener = new StubIFileOpener<IDirectory>();
            IFileOpener<IProject> projectOpener = new StubIFileOpener<IProject>();

            return new FileFactory(ExportFactoryHelper.BuildExportFactory(directoryOpener),
                ExportFactoryHelper.BuildExportFactory(projectOpener),
                new StubIPathUtils());
        }
    }
}