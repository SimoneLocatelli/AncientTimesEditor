using Editor.FileSystem.Dependencies.FileManagers;
using Editor.FileSystem.Dependencies.FileManagers.Fakes;
using Editor.WindowShell.Dependencies;
using Editor.WindowShell.Dependencies.Fakes;
using Editor.WindowShell.Dialogs.SaveDialogs;
using Editor.WindowShell.Tests.MockData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Common;

namespace Editor.WindowShell.Tests.Dialogs.SaveDialogs
{
    [TestClass]
    public class SaveFileWizardTest : EditorBaseTestClass
    {
        [TestMethod]
        public void WhenDependenciesAreInvalidItWillFail()
        {
            TestExpectedArgumentException<ArgumentNullException>(() => new SaveFileWizard(null, null), "saveFileDialogCreator");
            TestExpectedArgumentException<ArgumentNullException>(() => new SaveFileWizard(new StubISaveFileDialogCreator(), null), "fileFactory");
        }

        [TestMethod]
        public void WhenFileCreatorIsInvalidItWillFail()
        {
            TestExpectedArgumentException<ArgumentNullException>(() => Setup().Save(default(IFileFactory<MockFile>)), "fileCreator");
        }

        [TestMethod]
        public void WhenFileIsNotSelectedItWillReturnDefaultTypeValue()
        {
            var saveFileDialog = new StubISaveFileDialog
            {
                FileNameGet = () => null
            };
            var file = new MockFile();

            var fileCreator = new StubIFileFactory<MockFile>
            {
                CreateString = s => file
            };

            var fileResult = Setup(saveFileDialog).Save(fileCreator);

            Assert.AreEqual(default(MockFile), fileResult);
        }

        [TestMethod]
        public void WhenFileIsSelectedItWillCreateIt()
        {
            const string fileName = "fileName";
            var saveFileDialog = new StubISaveFileDialog
            {
                FileNameGet = () => fileName
            };
            var file = new MockFile();

            var fileCreator = new StubIFileFactory<MockFile>
            {
                CreateString = s => file
            };

            var fileResult = Setup(saveFileDialog).Save(fileCreator);

            Assert.AreEqual(file, fileResult);
        }

        private SaveFileWizard Setup(ISaveFileDialog saveFileDialog = null)
        {
            var saveFileDialogCreator = new StubISaveFileDialogCreator
            {
                CreateIFile = file => saveFileDialog
            };

            var fileFactory = new StubIFileFactory();

            return new SaveFileWizard(saveFileDialogCreator, fileFactory);
        }
    }
}