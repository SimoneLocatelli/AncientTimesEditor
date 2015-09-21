using Editor.MainMenu.Dependencies;
using MainMenu.File;
using MainMenu.Help;
using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace MainMenu
{
    /// <summary>
    ///     Menu Item collection containing the Items to display in the Editor
    ///     Main Menu
    /// </summary>
    public class MainMenuItemsCollection : List<IMenuItem>, IMainMenuItemsCollection
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="MainMenuItemsCollection" /> class.
        /// </summary>
        /// <param name="fileMenuItem">The file menu item.</param>
        /// <param name="helpMenuItem">The help menu item.</param>
        [ImportingConstructor]
        public MainMenuItemsCollection(FileMenuItem fileMenuItem, HelpMenuItem helpMenuItem)
        {
            Add(fileMenuItem);
            Add(helpMenuItem);
        }
    }
}