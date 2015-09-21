using Editor.FileSystem.Dependencies.FileEntities;
using Editor.WindowShell.Dialogs;
using Editor.WindowShell.Tests.MockData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Common;

namespace Editor.WindowShell.Tests.Dialogs
{
    [TestClass]
    public class OpenFileDialogCreatorTest : EditorBaseTestClass
    {
        private const string Description = "Fake File";
        private const string ExpectedFilter = "Fake File (*.fake)|*.fake";
        private const string Extension = "fake";

        [TestMethod]
        public void WhenDescriptionIsInvalidItWillFail()
        {
            TestExpectedArgumentException<ArgumentNullException>(() => Setup().Open(null, null), "description");
        }

        [TestMethod]
        public void WhenExtensionIsInvalidItWillFail()
        {
            TestExpectedArgumentException<ArgumentException>(() => Setup().Open(string.Empty, null), "extension");
            TestExpectedArgumentException<ArgumentException>(() => Setup().Open(string.Empty, string.Empty), "extension");
            TestExpectedArgumentException<ArgumentException>(() => Setup().Open(string.Empty, "  "), "extension");
        }

        [TestMethod]
        public void WhenFileInfoIsNullItWillFail()
        {
            TestExpectedArgumentException<ArgumentNullException>(() => Setup().Open(default(IFile)), "file");
        }

        [TestMethod]
        public void WhenFileIsNullItWillFail()
        {
            TestExpectedArgumentException<ArgumentNullException>(() => Setup().Open(default(IFile)), "file");
        }

        [TestMethod]
        public void WhenFileIsValidItWillCreateOpenFileDialog()
        {
            var fileInfo = new MockFileInfo
            {
                Description = Description,
                Extension = Extension
            };

            var openFileDialog = Setup().Open(new MockFile
            {
                FileInfo = fileInfo
            });

            Assert.IsNotNull(openFileDialog);
            Assert.AreEqual(ExpectedFilter, openFileDialog.Filter);
        }

        [TestMethod]
        public void WhenParametersAreValidItWillCreateOpenFileDialog()
        {
            const string description = "Fake File";
            const string extension = "fake";

            var openFileDialog = Setup().Open(description, extension);

            Assert.IsNotNull(openFileDialog);
            Assert.AreEqual(ExpectedFilter, openFileDialog.Filter);
        }

        private static OpenFileDialogCreator Setup()
        {
            return new OpenFileDialogCreator();
        }
    }
}