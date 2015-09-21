using Editor.FileSystem.Dependencies.FileEntities;
using Editor.WindowShell.Dialogs;
using Editor.WindowShell.Tests.MockData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Common;

namespace Editor.WindowShell.Tests.Dialogs
{
    [TestClass]
    public class SaveFileDialogCreatorTest : EditorBaseTestClass
    {
        private const string Description = "Fake File";
        private const string ExpectedFilter = "Fake File (*.fake)|*.fake";
        private const string Extension = "fake";

        [TestMethod]
        public void WhenDescriptionIsInvalidItWillFail()
        {
            TestExpectedArgumentException<ArgumentNullException>(() => Setup().Create(null, null), "description");
        }

        [TestMethod]
        public void WhenExtensionIsInvalidItWillFail()
        {
            TestExpectedArgumentException<ArgumentNullException>(() => Setup().Create(string.Empty, null), "extension");
            TestExpectedArgumentException<ArgumentNullException>(() => Setup().Create(string.Empty, string.Empty), "extension");
            TestExpectedArgumentException<ArgumentNullException>(() => Setup().Create(string.Empty, "  "), "extension");
        }

        [TestMethod]
        public void WhenFileInfoIsNullItWillFail()
        {
            TestExpectedArgumentException<ArgumentNullException>(() => Setup().Create(default(IFile)), "file");
        }

        [TestMethod]
        public void WhenFileIsNullItWillFail()
        {
            TestExpectedArgumentException<ArgumentNullException>(() => Setup().Create(default(IFile)), "file");
        }

        [TestMethod]
        public void WhenFileIsValidItWillCreateSaveFileDialog()
        {
            var fileInfo = new MockFileInfo
            {
                Description = Description,
                Extension = Extension
            };

            var saveFileDialog = Setup().Create(new MockFile
            {
                FileInfo = fileInfo
            });

            Assert.IsNotNull(saveFileDialog);
            Assert.AreEqual(ExpectedFilter, saveFileDialog.Filter);
        }

        [TestMethod]
        public void WhenParametersAreValidItWillCreateSaveFileDialog()
        {
            const string description = "Fake File";
            const string extension = "fake";

            var saveFileDialog = Setup().Create(description, extension);

            Assert.IsNotNull(saveFileDialog);
            Assert.AreEqual(ExpectedFilter, saveFileDialog.Filter);
        }

        private static SaveFileDialogCreator Setup()
        {
            return new SaveFileDialogCreator();
        }
    }
}