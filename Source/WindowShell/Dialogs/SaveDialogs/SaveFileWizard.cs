using Editor.FileSystem.Dependencies.FileEntities;
using Editor.FileSystem.Dependencies.FileManagers;
using Editor.WindowShell.Dependencies;
using FluentChecker;
using System;
using System.ComponentModel.Composition;

namespace Editor.WindowShell.Dialogs.SaveDialogs
{
    [Export(typeof (ISaveFileWizard))]
    public class SaveFileWizard : ISaveFileWizard
    {
        private readonly IFileFactory fileFactory;
        private readonly ISaveFileDialogCreator saveFileDialogCreator;

        [ImportingConstructor]
        public SaveFileWizard(ISaveFileDialogCreator saveFileDialogCreator,
            IFileFactory fileFactory)
        {
            Check.IfIsNull(saveFileDialogCreator).Throw<ArgumentNullException>(() => saveFileDialogCreator);
            Check.IfIsNull(fileFactory).Throw<ArgumentNullException>(() => fileFactory);

            this.saveFileDialogCreator = saveFileDialogCreator;
            this.fileFactory = fileFactory;
        }

        public virtual TFile Save<TFile>(IFileFactory<TFile> fileCreator) where TFile : IFile
        {
            Check.IfIsNull(fileCreator).Throw<ArgumentNullException>(() => fileCreator);

            var saveFileDialog = saveFileDialogCreator.Create(fileFactory.CreateFile<TFile>());

            saveFileDialog.ShowDialog();

            var fileName = saveFileDialog.FileName;

            return string.IsNullOrWhiteSpace(fileName) ? default(TFile) : fileCreator.Create(fileName);
        }
    }
}