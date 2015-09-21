using Editor.WindowShell.Dialogs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Win32;
using System;
using System.Linq;
using Tests.Common;

namespace Editor.WindowShell.Tests.Dialogs
{
    [TestClass]
    public class EditorSaveFileDialogTest : EditorBaseTestClass
    {
        [TestMethod]
        public void AssertFileNamesValueIsReturned()
        {
            var saveFileDialog = new SaveFileDialog();

            var editorSaveFileDialog = Setup(saveFileDialog);

            Assert.IsTrue(saveFileDialog.FileNames.SequenceEqual(editorSaveFileDialog.FileNames));
        }

        [TestMethod]
        public void AssertFileNameValueIsReturned()
        {
            var saveFileDialog = new SaveFileDialog();

            var editorSaveFileDialog = Setup(saveFileDialog);

            Assert.AreEqual(saveFileDialog.FileName, editorSaveFileDialog.FileName);
        }

        [TestMethod]
        public void AssertFilterValueIsReturned()
        {
            var saveFileDialog = new SaveFileDialog();

            var editorSaveFileDialog = Setup(saveFileDialog);

            Assert.AreEqual(saveFileDialog.Filter, editorSaveFileDialog.Filter);
        }

        [TestMethod]
        public void WhenDependenciesAreInvalidItWillFail()
        {
            TestExpectedArgumentException<ArgumentNullException>(() => new EditorSaveFileDialog(null), "saveFileDialog");
        }

        private static EditorSaveFileDialog Setup(SaveFileDialog saveFileDialog = null)
        {
            saveFileDialog = saveFileDialog ?? new SaveFileDialog();

            return new EditorSaveFileDialog(saveFileDialog);
        }
    }
}