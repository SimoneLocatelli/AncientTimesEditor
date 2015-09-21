using System.Collections.Generic;
using System.Linq;
using Editor.Badasquall.Dependencies;

namespace Editor.PokemonEditor
{
    /// <summary>
    ///     Mock repository to access the PokemonType collection stored in memory.
    ///     This is just a temporary replacement to enable the development of the Pokemon
    ///     Editor.
    /// </summary>
    public class MockPokemonTypeRepository : IPokemonTypeRepository
    {
        private readonly List<IPokemonType> pokemonTypes = new List<IPokemonType>
        {
            new PokemonTypeModel("TestType1"),
            new PokemonTypeModel("TestType2"),
            new PokemonTypeModel("TestType3"),
            new PokemonTypeModel("TestType4")
        };

        /// <summary>
        ///     Selects all the pokemon type entities currently stored.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IPokemonType> SelectAll()
        {
            return pokemonTypes.OrderBy(type => type.Name);
        }
    }
}
