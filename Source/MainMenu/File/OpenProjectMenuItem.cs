#region Usings

using Editor.FileSystem.Dependencies.FileEntities;
using Editor.FileSystem.Dependencies.FileManagers;
using Editor.MainMenu.Dependencies;
using Editor.WindowShell.Dependencies;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Windows.Input;
using WpfCommonLibrary;

#endregion Usings

namespace MainMenu.File
{
    /// <summary>
    ///     Menu Item for the Feature "OpenProject"
    /// </summary>
    [Export(FileMenuItem.InnerItemsKey, typeof (IMenuItem))]
    public class OpenProjectMenuItem : IMenuItem
    {
        private readonly IOpenFileDialog<IProject> openFileDialog;
        private readonly IFileOpener<IProject> projectFileOpener;
        private readonly IProjectLoader projectLoader;

        /// <summary>
        ///     Gets the command associated to the Menu Item.
        /// </summary>
        /// <value> The command. </value>
        public ICommand Command
        {
            get
            {
                return new Command(o =>
                {
                    var selectedFile = openFileDialog.ShowSelectFileDialog().FirstOrDefault();

                    if (string.IsNullOrWhiteSpace(selectedFile)) return;

                    var projectFile = projectFileOpener.Open(selectedFile);
                    projectLoader.Load(projectFile);
                });
            }
        }

        /// <summary>
        ///     Gets or sets the inner menu items contained in this instance.
        /// </summary>
        /// <value> The inner menu items. </value>
        public IEnumerable<IMenuItem> InnerMenuItems
        {
            get { return new List<IMenuItem>(); }
        }

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        /// <value> The name. </value>
        public string Name
        {
            get { return Resources.OpenProjectMenuItemHeader; }
        }

        /// <summary>
        ///     Gets or sets the priority.
        /// </summary>
        /// <value> The priority. </value>
        public int Priority
        {
            get { return 0; }
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="NewProjectMenuItem" /> class.
        /// </summary>
        /// <param name="projectFileOpener">The project file opener.</param>
        /// <param name="openFileDialog">The file selector.</param>
        /// <param name="projectLoader">The project loader.</param>
        [ImportingConstructor]
        public OpenProjectMenuItem(IFileOpener<IProject> projectFileOpener, IOpenFileDialog<IProject> openFileDialog,
            IProjectLoader projectLoader)
        {
            this.projectFileOpener = projectFileOpener;
            this.openFileDialog = openFileDialog;
            this.projectLoader = projectLoader;
        }
    }
}