using Editor.FileSystem.Dependencies.FileEntities;
using Editor.FileSystem.Dependencies.FileManagers;
using Editor.ProjectExplorer.Dependencies;
using Editor.WpfCommonLibrary.Dependencies.Menu;
using FluentChecker;
using System;
using System.ComponentModel.Composition;
using Utils;
using WpfCommonLibrary;

namespace Editor.ProjectExplorer.ContextMenus.CommonMenuItems
{
    /// <summary>
    ///     A Manu Item that incorporates the "Create New Folder" functionality.
    /// </summary>
    [Export(DirectoryContextMenu.DirectoryContextMenuInnerItemsKey, typeof (IMenuItem))]
    public class NewFolderMenuItem : MenuItem
    {
        private readonly IDirectoryFactory directoryCreator;
        private readonly IProjectExplorerItemFactory projectExplorerItemFactory;

        /// <summary>
        ///     Initializes a new instance of the <see cref="NewFolderMenuItem" /> class.
        /// </summary>
        /// <param name="directoryCreator">The directory creator.</param>
        /// <param name="projectExplorerItemFactory">The project explorer item factory.</param>
        public NewFolderMenuItem(IDirectoryFactory directoryCreator,
            IProjectExplorerItemFactory projectExplorerItemFactory)
            : base(Resources.NewFolderMenuItemHeader, 0)
        {
            Check.IfIsNull(directoryCreator).Throw<ArgumentNullException>(() => directoryCreator);
            Check.IfIsNull(projectExplorerItemFactory).Throw<ArgumentNullException>(() => projectExplorerItemFactory);

            this.directoryCreator = directoryCreator;
            this.projectExplorerItemFactory = projectExplorerItemFactory;

            Command = new Command(CreateNewFolder);
        }

        /// <summary>
        ///     Creates the new folder.
        /// </summary>
        /// <param name="projectExplorerItem">The project explorer item.</param>
        private void CreateNewFolder(object projectExplorerItem)
        {
            Check.IfIsNull(projectExplorerItem).Throw<ArgumentNullException>(() => projectExplorerItem);
            Check.IfIsNotOfType<IProjectExplorerItem>(projectExplorerItem)
                .Throw<ArgumentException>(
                    ArgumentExceptionMessagesFactory.InstanceIsNotExpectedType<IProjectExplorerItem>());

            var projectExplorerItemCasted = (IProjectExplorerItem) projectExplorerItem;

            Check.IfIsNotOfType<IFileContainer>(projectExplorerItemCasted.Value)
                .Throw<ArgumentException>(
                    ArgumentExceptionMessagesFactory.InstanceIsNotExpectedType<IFileContainer>());

            var fileContainer = (IFileContainer) projectExplorerItemCasted.Value;

            var directory = directoryCreator.CreateWithDefaultName(fileContainer);

            projectExplorerItemCasted.Children.Add(projectExplorerItemFactory.Create(directory));
        }
    }
}