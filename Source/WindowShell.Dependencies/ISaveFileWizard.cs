using Editor.FileSystem.Dependencies.FileEntities;
using Editor.FileSystem.Dependencies.FileManagers;

namespace Editor.WindowShell.Dependencies
{
    public interface ISaveFileWizard
    {
        TFile Save<TFile>(IFileFactory<TFile> fileCreator) where TFile : IFile;
    }

    public interface ISaveFileWizard<TFile> where TFile : IFile
    {
        TFile Save();
    }
}