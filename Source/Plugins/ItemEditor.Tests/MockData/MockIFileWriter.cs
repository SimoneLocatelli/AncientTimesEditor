using Editor.FileSystem.Dependencies.FileManagers;

namespace Editor.ItemEditor.Tests.MockData
{
    public class MockIFileWriter : IFileWriter
    {
        public string Contents { get; private set; }

        public void Write(string contents, string filePath)
        {
            Contents = Contents ?? string.Empty;

            Contents += contents;
        }
    }
}