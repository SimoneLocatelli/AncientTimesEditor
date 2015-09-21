namespace Editor.Badasquall.Dependencies
{
    /// <summary>
    ///     An item is an object in the Pokémon games which the player can pick up,
    ///     keep in their Bag, and use in some manner. They have various uses,
    ///     including healing, powering up, helping one to catch Pokémon, or to access a new area.
    /// </summary>
    public interface IItem
    {
        /// <summary>
        ///     Gets the item identifier.
        /// </summary>
        /// <value>
        ///     The identifier.
        /// </value>
        int Id { get; }

        /// <summary>
        ///     Gets the item category.
        /// </summary>
        /// <value>
        ///     The item category.
        /// </value>
        IItemCategory ItemCategory { get; }

        /// <summary>
        ///     Gets the item name.
        /// </summary>
        /// <value>
        ///     The name.
        /// </value>
        string Name { get; }
    }
}