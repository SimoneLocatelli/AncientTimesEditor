using Editor.MainMenu.Dependencies;
using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace MainMenu
{
    /// <summary>
    ///     ViewModel for the MainMenu view.
    /// </summary>
    [Export(typeof(MainMenuViewViewModel))]
    public class MainMenuViewViewModel
    {
        /// <summary>
        /// Gets the main menu items collection.
        /// </summary>
        /// <value>
        /// The main menu items collection.
        /// </value>
        public IMainMenuItemsCollection MainMenuItemsCollection { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MainMenuViewViewModel"/> class.
        /// </summary>
        /// <param name="mainMenuItemsCollection">The main menu items collection.</param>
        [ImportingConstructor]
        public MainMenuViewViewModel(IMainMenuItemsCollection mainMenuItemsCollection)
        {
            MainMenuItemsCollection = mainMenuItemsCollection;
        }
    }
}