using Editor.Badasquall.Dependencies;
using Editor.WpfCommonLibrary.Dependencies;
using System.Diagnostics.CodeAnalysis;

namespace Editor.ItemEditor.Entities
{
    /// <summary>
    ///     An item is an object in the Pokémon games which the player can pick up,
    ///     keep in their Bag, and use in some manner. They have various uses,
    ///     including healing, powering up, helping one to catch Pokémon, or to access a new area.
    /// </summary>
    public class Item : BaseViewModel, IItem
    {
        private int id;
        private IItemCategory itemCategory;
        private string name;

        /// <summary>
        ///     Gets the item identifier.
        /// </summary>
        /// <value>
        ///     The identifier.
        /// </value>
        [ExcludeFromCodeCoverage]
        public int Id
        {
            get { return id; }
            set { SetProperty(ref id, value); }
        }

        /// <summary>
        ///     Gets the item category.
        /// </summary>
        /// <value>
        ///     The item category.
        /// </value>
        [ExcludeFromCodeCoverage]
        public IItemCategory ItemCategory
        {
            get { return itemCategory; }
            set { SetProperty(ref itemCategory, value); }
        }

        /// <summary>
        ///     Gets the item name.
        /// </summary>
        /// <value>
        ///     The name.
        /// </value>
        [ExcludeFromCodeCoverage]
        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Item" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public Item(string name)
        {
            Name = name;
        }
    }
}