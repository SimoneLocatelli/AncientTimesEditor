namespace Editor.Badasquall.Dependencies
{
    /// <summary>
    ///     The Type is used to distinguish different Pokemon related entities.
    ///     Each Pokemon has at least one Type, and the same about the Moves.
    /// </summary>
    public interface IPokemonType
    {
        /// <summary>
        ///     Gets the type name.
        /// </summary>
        /// <value>
        ///     The type name.
        /// </value>
        string Name { get; }
    }
}