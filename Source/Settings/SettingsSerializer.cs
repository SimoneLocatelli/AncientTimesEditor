using Editor.Application.Dependencies;
using Editor.FileSystem.Dependencies.Facades;
using Editor.FileSystem.Dependencies.FileManagers;
using Editor.Settings.Dependencies;
using System.ComponentModel.Composition;

namespace Editor.Settings
{
    public class SettingsSerializer : ISettingsSerializer
    {
        protected const string SettingsFileName = "Settings.xml";
        private static IEditorSettings currentEditorSettings;
        private readonly IApplication application;
        private readonly IFileFacade fileFacade;
        private readonly IFileReader fileReader;
        private readonly IFileWriter fileWriter;
        private readonly IPathFacade pathFacade;
        private readonly IXmlDeserializer xmlDeserializer;
        private readonly IXmlSerializer xmlSerializer;

        [ImportingConstructor]
        public SettingsSerializer(IApplication application,
            IFileFacade fileFacade,
            IPathFacade pathFacade,
            IXmlSerializer xmlSerializer, IXmlDeserializer xmlDeserializer,
            IFileWriter fileWriter, IFileReader fileReader)
        {
            this.application = application;
            this.fileFacade = fileFacade;
            this.pathFacade = pathFacade;
            this.xmlSerializer = xmlSerializer;
            this.xmlDeserializer = xmlDeserializer;
            this.fileWriter = fileWriter;
            this.fileReader = fileReader;
        }

        public IEditorSettings Read()
        {
            return currentEditorSettings ?? ReadSettingsFromFile();
        }

        public void Save()
        {
            var contents = xmlSerializer.Serialize(new EditorSettingsSerializable(currentEditorSettings));
            fileWriter.Write(contents, GetFilePath());
        }

        private string GetFilePath()
        {
            return pathFacade.Combine(application.InstallationPath, SettingsFileName);
        }

        private IEditorSettings ReadSettingsFromFile()
        {
            var filePath = GetFilePath();

            if (!fileFacade.Exists(filePath))
            {
                currentEditorSettings = new EditorSettings();
                return currentEditorSettings;
            }

            var contents = fileReader.Read(filePath);

            var editorSettingsSerializable = xmlDeserializer.Deserialize<EditorSettingsSerializable>(contents);

            currentEditorSettings = editorSettingsSerializable.ToEditorSettings();

            return currentEditorSettings;
        }
    }
}