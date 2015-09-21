using Editor.PokemonEditor.Dependencies;
using Editor.PokemonEditor.Properties;
using Editor.ProjectExplorer.Dependencies;
using Editor.WpfCommonLibrary.Dependencies;
using Editor.WpfCommonLibrary.Dependencies.Menu;
using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace Editor.PokemonEditor
{
    /// <summary>
    ///     Project Explorer Item that allows to communicate with the
    ///     Pokémon Editor.
    /// </summary>
    [Export(ImportConstants.FixedProjectExplorerItemKey, typeof (IProjectExplorerItem))]
    public class PokemonEditorProjectExplorerItem : BaseViewModel, IProjectExplorerItem
    {
        private readonly IPokemonEditorWindowFactory pokemonEditorWindowFactory;
        private bool isExpanded;
        private bool isSelected;

        /// <summary>
        ///     Gets or sets the children contained by the item.
        /// </summary>
        /// <value>
        ///     The children.
        /// </value>
        public ICollection<IProjectExplorerItem> Children
        {
            get { return null; }
        }

        /// <summary>
        ///     Gets the menu items that compose the Context Menu.
        /// </summary>
        /// <value>
        ///     The context menu items.
        /// </value>
        public IEnumerable<IMenuItem> ContextMenuItems
        {
            get { return null; }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is expanded.
        /// </summary>
        /// <value>
        ///     <c> true </c> if this instance is expanded; otherwise, <c> false </c>.
        /// </value>
        public bool IsExpanded
        {
            get { return isExpanded; }
            set { SetProperty(ref isExpanded, value); }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is selected.
        /// </summary>
        /// <value>
        ///     <c> true </c> if this instance is selected; otherwise, <c> false </c>.
        /// </value>
        public bool IsSelected
        {
            get { return isSelected; }
            set { SetProperty(ref isSelected, value); }
        }

        /// <summary>
        ///     Gets or sets the item name.
        /// </summary>
        /// <value>
        ///     The name.
        /// </value>
        public string Name
        {
            get { return Resources.ProjectExplorerItemName; }
        }

        /// <summary>
        ///     Gets the value represented by this item.
        /// </summary>
        /// <value>
        ///     The value.
        /// </value>
        public object Value
        {
            get { return null; }
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="PokemonEditorProjectExplorerItem" /> class.
        /// </summary>
        /// <param name="pokemonEditorWindowFactory">The pokemon editor window.</param>
        [ImportingConstructor]
        public PokemonEditorProjectExplorerItem(IPokemonEditorWindowFactory pokemonEditorWindowFactory)
        {
            this.pokemonEditorWindowFactory = pokemonEditorWindowFactory;
        }

        /// <summary>
        ///     Opens the value contained in the Project Explorer item displaying it in
        ///     a new View.
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        public void Open()
        {
            pokemonEditorWindowFactory.Create().Show();
        }
    }
}