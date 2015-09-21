using Editor.FileSystem.Dependencies.FileManagers;

namespace Editor.ItemEditor.Tests.MockData
{
    internal class SpyIXmlSerializer : IXmlSerializer
    {
        public bool SerializeHasBeenCalled { get; private set; }

        public string Serialize(object serializable)
        {
            SerializeHasBeenCalled = true;

            return "Test";
        }
    }
}