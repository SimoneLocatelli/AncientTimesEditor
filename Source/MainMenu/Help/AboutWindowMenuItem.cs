using Editor.MainMenu.Dependencies;
using Editor.WindowShell.Dependencies;
using MainMenu.Properties;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Windows.Input;
using WpfCommonLibrary;

namespace MainMenu.Help
{
    /// <summary>
    ///     Menu Item that allow to open the About Window
    /// </summary>
    [Export(HelpMenuItem.HelpMenuItemChildrenKey, typeof(IMenuItem))]
    public class AboutWindowMenuItem : IMenuItem
    {
        private readonly ICommand command;

        /// <summary>
        ///     Gets the command associated to the Menu Item.
        /// </summary>
        /// <value> The command. </value>
        public ICommand Command
        {
            get { return command; }
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
            get { return Resources.HelpMenuAboutItemHeader; }
        }

        /// <summary>
        ///     Gets or sets the priority.
        /// </summary>
        /// <value> The priority. </value>
        public int Priority
        {
            get { return Settings.Default.MenuItemLastPriority; }
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="AboutWindowMenuItem" /> class.
        /// </summary>
        /// <param name="exportFactory">The export factory.</param>
        [ImportingConstructor]
        public AboutWindowMenuItem(ExportFactory<IAboutWindow> exportFactory)
        {
            command = new Command(o => exportFactory.CreateExport().Value.ShowDialog());
        }
    }
}