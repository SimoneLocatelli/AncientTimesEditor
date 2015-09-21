namespace Editor.FileSystem
{
    //[Export(typeof(IFilesImporter))]
    //public class FilesImporter : IFilesImporter
    //{
    //    private readonly IEditorLogger editorLogger;
    //    private readonly IFileFactory fileFactory;
    //    private readonly IFileLocationManager fileLocationManager;

    //    public FilesImporter(IFileLocationManager fileLocationManager, IFileFactory fileFactory,
    //        IEditorLogger editorLogger)
    //    {
    //        this.fileLocationManager = fileLocationManager;
    //        this.fileFactory = fileFactory;
    //        this.editorLogger = editorLogger;
    //    }

    //    public IEnumerable<IFile> ImportFiles(IEnumerable<string> filesToImport, string destination)
    //    {
    //        Check.IfIsNull(filesToImport).Throw<ArgumentNullException>(() => filesToImport);
    //        Check.IfIsNullOrWhiteSpace(destination).Throw<ArgumentNullException>(() => destination);

    //        return filesToImport.Select(selectedFile => ImportFile(selectedFile, destination)).Where(f => f != null);
    //    }

    //    private bool FileAlreadyExists(string filePath)
    //    {
    //        return fileLocationManager.Exists(filePath);
    //    }

    //    private IFile ImportFile(string filePath, string destination)
    //    {
    //        var editorFile = fileFactory.ConvertToFile(filePath);

    //        //var genericFile = editorFile as GenericFile;

    //        //if (genericFile == null)
    //        //{
    //        //    LogFileTypeNotSupported(editorFile);
    //        //    return null;
    //        //}

    //        var fileDestination = fileLocationManager.Combine(destination, editorFile.FullName);

    //        if (FileAlreadyExists(fileDestination))
    //        {
    //            LogAlreadyExistingFile(editorFile);
    //            return null;
    //        }

    //        fileLocationManager.Copy(filePath, fileDestination);

    //        return editorFile;
    //    }

    //    private void LogAlreadyExistingFile(IFile file)
    //    {
    //        editorLogger.Log(Resources.LogCategory, string.Format(CultureInfo.CurrentCulture,
    //            Resources.FileImporterLogMessageFileAlreadyExists, file.FullName));
    //    }

    //    private void LogFileTypeNotSupported(IFile file)
    //    {
    //        editorLogger.Log(Resources.LogCategory, string.Format(CultureInfo.CurrentCulture,
    //            Resources.FileImporterLogMessageFileTypeNotSupported, file.FullName));
    //    }
    //}
}