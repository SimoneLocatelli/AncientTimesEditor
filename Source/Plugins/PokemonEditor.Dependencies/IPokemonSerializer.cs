using Editor.Badasquall.Dependencies;
using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace Editor.PokemonEditor.Dependencies
{
    /// <summary>
    ///     The serializer for pokemons list
    /// </summary>
    [InheritedExport]
    public interface IPokemonSerializer
    {
        /// <summary>
        ///     The serialize method
        /// </summary>
        void Serialize(IEnumerable<IPokemon> pokemons);
    }
}