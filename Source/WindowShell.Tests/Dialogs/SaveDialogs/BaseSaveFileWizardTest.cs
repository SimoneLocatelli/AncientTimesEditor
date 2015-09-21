using Editor.FileSystem.Dependencies.FileEntities;
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
    public class BaseSaveFileWizardTest : EditorBaseTestClass
    {
        [TestMethod]
        public void SaveWillCallSaveFileWizard()
        {
            var spySaveFileWizard = new SpySaveFileWizard();

            new BaseSaveFileWizardExposer(spySaveFileWizard).Save();

            Assert.IsTrue(spySaveFileWizard.HasSaveBeenCalled);
        }

        [TestMethod]
        public void WhenDependenciesAreInvalidItWillFail()
        {
            TestExpectedArgumentException<ArgumentNullException>(() =>
                new BaseSaveFileWizardExposer(null, null), "fileCreator");

            TestExpectedArgumentException<ArgumentNullException>(() =>
                new BaseSaveFileWizardExposer(default(ISaveFileWizard)), "saveFileWizard");
        }

        private class BaseSaveFileWizardExposer : BaseSaveFileWizard<MockFile>
        {
            public BaseSaveFileWizardExposer(IFileFactory<MockFile> fileCreator,
                ISaveFileWizard saveFileWizard)
                : base(fileCreator, saveFileWizard)
            {
            }

            public BaseSaveFileWizardExposer() :
                base(new StubIFileFactory<MockFile>(), new StubISaveFileWizard())
            {
            }

            public BaseSaveFileWizardExposer(IFileFactory<MockFile> fileCreator) :
                base(fileCreator, new StubISaveFileWizard())
            {
            }

            public BaseSaveFileWizardExposer(ISaveFileWizard saveFileWizard) :
                base(new StubIFileFactory<MockFile>(), saveFileWizard)
            {
            }
        }

        private class SpySaveFileWizard : ISaveFileWizard
        {
            public bool HasSaveBeenCalled { get; set; }

            public TFile Save<TFile>(IFileFactory<TFile> fileCreator) where TFile : IFile
            {
                HasSaveBeenCalled = true;

                return default(TFile);
            }
        }
    }
}