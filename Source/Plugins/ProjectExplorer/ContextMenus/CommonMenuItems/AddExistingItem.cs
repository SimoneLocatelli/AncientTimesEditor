namespace Editor.ProjectExplorer.ContextMenus.CommonMenuItems
{
    ///// <summary>
    /////     The "Add Existing File" Menu Item
    ///// </summary>
    //public class AddExistingFileMenuItem : MenuItem
    //{
    //    private readonly IFilesImporter filesImporter;
    //    private readonly IOpenFileDialog<IGenericFile> openFileDialog;
    //    private readonly IProjectExplorerItemFactory projectExplorerItemFactory;

    //    /// <summary>
    //    ///     Initializes a new instance of the <see cref="MenuItem" /> class.
    //    /// </summary>
    //    public AddExistingFileMenuItem(IOpenFileDialog<IGenericFile> openFileDialog,
    //        IProjectExplorerItemFactory projectExplorerItemFactory, IFilesImporter filesImporter)
    //        : base(global::ProjectExplorer.Resources.AddExistingFileMenuItemHeader, 100)
    //    {
    //        this.openFileDialog = openFileDialog;
    //        this.projectExplorerItemFactory = projectExplorerItemFactory;
    //        this.filesImporter = filesImporter;
    //        Command = new Command(AddExistingFile);
    //    }

    //    /// <summary>
    //    ///     Selects and then adds an existing file to the input Project Explorer item.
    //    /// </summary>
    //    /// <param name="projectExplorerItem">The project explorer item.</param>
    //    public void AddExistingFile(object projectExplorerItem)
    //    {
    //        Check.IfIsNull(projectExplorerItem).Throw<ArgumentNullException>(() => projectExplorerItem);
    //        Check.IfIsNotOfType<ProjectExplorerItem>(projectExplorerItem)
    //            .Throw<ArgumentException>(
    //                ArgumentExceptionMessagesFactory.InstanceIsNotExpectedType<ProjectExplorerItem>());

    //        var projectExplorerItemCasted = (ProjectExplorerItem)projectExplorerItem;

    //        Check.IfIsNotOfType<IFileContainer>(projectExplorerItemCasted.File)
    //            .Throw<ArgumentException>(
    //                ArgumentExceptionMessagesFactory.InstanceIsNotExpectedType<IFileContainer>());

    //        var fileContainer = (IFileContainer)projectExplorerItemCasted.File;

    //        var selectedFiles = openFileDialog.ShowSelectFileDialog();

    //        if (selectedFiles == null || !selectedFiles.Any()) return;

    //        var filesImported = filesImporter.ImportFiles(selectedFiles, fileContainer.ChildrenPath);

    //        foreach (var file in filesImported)
    //        {
    //            projectExplorerItemCasted.Children.Add(projectExplorerItemFactory.Create(file));
    //        }
    //    }
    //}
}