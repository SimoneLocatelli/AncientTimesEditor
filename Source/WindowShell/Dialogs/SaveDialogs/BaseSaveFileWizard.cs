using Editor.FileSystem.Dependencies.FileEntities;
using Editor.FileSystem.Dependencies.FileManagers;
using Editor.WindowShell.Dependencies;
using FluentChecker;
using System;
using System.ComponentModel.Composition;

namespace Editor.WindowShell.Dialogs.SaveDialogs
{
    public abstract class BaseSaveFileWizard<TFile> : ISaveFileWizard<TFile> where TFile : IFile
    {
        private readonly IFileFactory<TFile> fileCreator;
        private readonly ISaveFileWizard saveFileWizard;

        [ImportingConstructor]
        protected BaseSaveFileWizard(IFileFactory<TFile> fileCreator, ISaveFileWizard saveFileWizard)
        {
            Check.IfIsNull(fileCreator).Throw<ArgumentNullException>(() => fileCreator);
            Check.IfIsNull(saveFileWizard).Throw<ArgumentNullException>(() => saveFileWizard);

            this.fileCreator = fileCreator;
            this.saveFileWizard = saveFileWizard;
        }

        public TFile Save()
        {
            return saveFileWizard.Save(fileCreator);
        }
    }
}