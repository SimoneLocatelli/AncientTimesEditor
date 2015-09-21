using Editor.FileSystem.Dependencies;
using Editor.FileSystem.Dependencies.FileEntities;

namespace Editor.WindowShell.Tests.MockData
{
    public class MockFile : IFile
    {
        public IFileInfo FileInfo { get; set; }

        public string FullName { get; set; }

        public string FullPath { get; set; }

        public string Name { get; set; }

        public string Path { get; set; }
    }

    public class MockFileInfo : IFileInfo
    {
        public string DefaultFileName { get; set; }

        public string Description { get; set; }

        public string Extension { get; set; }
    }
}