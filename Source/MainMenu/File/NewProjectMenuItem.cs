#region Usings

using Editor.FileSystem.Dependencies.FileEntities;
using Editor.MainMenu.Dependencies;
using Editor.WindowShell.Dependencies;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Windows.Input;
using WpfCommonLibrary;

#endregion Usings

namespace MainMenu.File
{
    /// <summary>
    ///     The "New Project" menu item
    /// </summary>
    [Export(NewMenuItem.InnerItemsKey, typeof (IMenuItem))]
    public class NewProjectMenuItem : IMenuItem
    {
        private readonly ISaveFileWizard<IProject> projectSaveFileWizard;

        /// <summary>
        ///     Gets the command associated to the Menu Item.
        /// </summary>
        /// <value> The command. </value>
        public ICommand Command
        {
            get { return new Command(o => projectSaveFileWizard.Save()); }
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
            get { return Resources.NewProjectMenuItemHeader; }
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
        /// <param name="projectSaveFileWizard">The project save file wizard.</param>
        [ImportingConstructor]
        public NewProjectMenuItem(ISaveFileWizard<IProject> projectSaveFileWizard)
        {
            this.projectSaveFileWizard = projectSaveFileWizard;
        }
    }
}