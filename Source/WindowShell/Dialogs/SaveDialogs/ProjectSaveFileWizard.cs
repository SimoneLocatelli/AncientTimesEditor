using Editor.FileSystem.Dependencies.FileEntities;
using Editor.FileSystem.Dependencies.FileManagers;
using Editor.WindowShell.Dependencies;
using System.ComponentModel.Composition;
using System.Diagnostics.CodeAnalysis;

namespace Editor.WindowShell.Dialogs.SaveDialogs
{
    [Export(typeof (ISaveFileWizard<IProject>))]
    public class ProjectSaveFileWizard : BaseSaveFileWizard<IProject>
    {
        [ImportingConstructor, ExcludeFromCodeCoverage]
        public ProjectSaveFileWizard(IFileFactory<IProject> fileCreator, ISaveFileWizard saveFileWizard)
            : base(fileCreator, saveFileWizard)
        {
        }
    }
}