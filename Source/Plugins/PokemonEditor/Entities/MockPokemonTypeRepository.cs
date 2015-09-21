using System.Collections.Generic;
using System.Linq;
using Editor.Badasquall.Dependencies;

namespace Editor.PokemonEditor.Entities
{
    /// <summary>
    ///     Mock repository to access to the PokemonType collection stored in memory.
    ///     This is just a temporary replacement to enable the development of the Pokemon
    ///     Editor.
    /// </summary>

    public class MockPokemonTypeRepository : IPokemonTypeRepository
    {
        private readonly List<IPokemonType> pokemonTypes = new List<IPokemonType>
        {
            new PokemonType { Name = "TestType1" },
            new PokemonType { Name = "TestType2" },
            new PokemonType { Name = "TestType3" },
            new PokemonType { Name = "TestType4" }
        };

        /// <summary>
        /// Selects all the pokemon types available.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IPokemonType> SelectAll()
        {
            return pokemonTypes.OrderBy(type => type.Name);
        }
    }
}
