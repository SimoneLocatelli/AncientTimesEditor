using Editor.WindowShell.Dialogs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Win32;
using System;
using System.Linq;
using Tests.Common;

namespace Editor.WindowShell.Tests.Dialogs
{
    [TestClass]
    public class EditorOpenFileDialogTest : EditorBaseTestClass
    {
        [TestMethod]
        public void AssertFileNamesValueIsReturned()
        {
            var openFileDialog = new OpenFileDialog();

            var editorOpenFileDialog = Setup(openFileDialog);

            Assert.IsTrue(openFileDialog.FileNames.SequenceEqual(editorOpenFileDialog.FileNames));
        }

        [TestMethod]
        public void AssertFileNameValueIsReturned()
        {
            var openFileDialog = new OpenFileDialog();

            var editorOpenFileDialog = Setup(openFileDialog);

            Assert.AreEqual(openFileDialog.FileName, editorOpenFileDialog.FileName);
        }

        [TestMethod]
        public void AssertFilterValueIsReturned()
        {
            var openFileDialog = new OpenFileDialog();

            var editorOpenFileDialog = Setup(openFileDialog);

            Assert.AreEqual(openFileDialog.Filter, editorOpenFileDialog.Filter);
        }

        [TestMethod]
        public void AssertMultiselectStoreValueInDialog()
        {
            var openFileDialog = new OpenFileDialog();

            var editorOpenFileDialog = Setup(openFileDialog);

            // Testing default value

            Assert.IsFalse(editorOpenFileDialog.Multiselect);
            Assert.IsFalse(openFileDialog.Multiselect);

            // Testing set value from .Net dialog

            openFileDialog.Multiselect = true;

            Assert.IsTrue(editorOpenFileDialog.Multiselect);
            Assert.IsTrue(openFileDialog.Multiselect);

            // Testing set value from editor dialog

            editorOpenFileDialog.Multiselect = false;

            Assert.IsFalse(editorOpenFileDialog.Multiselect);
            Assert.IsFalse(openFileDialog.Multiselect);
        }

        [TestMethod]
        public void WhenDependenciesAreInvalidItWillFail()
        {
            TestExpectedArgumentException<ArgumentNullException>(() => new EditorOpenFileDialog(null), "openFileDialog");
        }

        private static EditorOpenFileDialog Setup(OpenFileDialog openFileDialog = null)
        {
            openFileDialog = openFileDialog ?? new OpenFileDialog();

            return new EditorOpenFileDialog(openFileDialog);
        }
    }
}