namespace Editor.Badasquall.Dependencies
{
    /// <summary>
    ///     An Item category identifies a set of items
    ///     that share a common aspect, like the effect type or the context
    ///     during which can be used.
    /// </summary>
    public interface IItemCategory
    {
        /// <summary>
        ///     Gets the category identifier.
        /// </summary>
        /// <value>
        ///     The identifier.
        /// </value>
        int Id { get; }

        /// <summary>
        ///     Gets the category name.
        /// </summary>
        /// <value>
        ///     The name.
        /// </value>
        string Name { get; }
    }
}