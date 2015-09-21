using System.Collections.Generic;
using System.Linq;
using Editor.Badasquall.Dependencies;

namespace Editor.PokemonEditor.Entities
{
    /// <summary>
    ///     Mock repository to access to the Pokemon collection stored in memory.
    ///     This is just a temporary replacement to enable the development of the Pokemon
    ///     Editor.
    /// </summary>
    public class MockPokemonRepository : IPokemonRepository
    {
        private readonly List<IPokemon> pokemons = new List<IPokemon>
        {
            new Pokemon(1, "Test1")
            {
                PrimaryType = new PokemonType { Name = "TestType3" }, 
                SecondaryType = null,
                HealthPoints = 10,
                Attack = 11,
                Defense = 12,
                SpecialAttack = 13,
                SpecialDefense = 14,
                Speed = 15,
                IndividualValues = 16
            },
            new Pokemon(2, "Test2")
            {
                PrimaryType = new PokemonType { Name = "TestType1" }, 
                SecondaryType = new PokemonType { Name = "TestType2" },
                HealthPoints = 1,
                Attack = 1,
                Defense = 1,
                SpecialAttack = 1,
                SpecialDefense = 1,
                Speed = 1,
                IndividualValues = 1
            },
            new Pokemon(3, "Test3")
            {
                PrimaryType = new PokemonType { Name = "TestType4" }, 
                SecondaryType = null,
                HealthPoints = 10,
                Attack = 16,
                Defense = 12,
                SpecialAttack = 13,
                SpecialDefense = 11,
                Speed = 15,
                IndividualValues = 1
            },
            new Pokemon(4, "Test4")
            {
                PrimaryType = new PokemonType { Name = "TestType2" }, 
                SecondaryType = new PokemonType { Name = "TestType1" },
                HealthPoints = 10,
                Attack = 11,
                Defense = 17,
                SpecialAttack = 20,
                SpecialDefense = 14,
                Speed = 15,
                IndividualValues = 16
            },
            new Pokemon(5, "Test5")
            {
                PrimaryType = new PokemonType { Name = "TestType3" }, 
                SecondaryType = null,
                HealthPoints = 10,
                Attack = 11,
                Defense = 12,
                SpecialAttack = 13,
                SpecialDefense = 14,
                Speed = 15,
                IndividualValues = 16
            },
            new Pokemon(6, "Test6")
            {
                PrimaryType = new PokemonType { Name = "TestType3"},
                SecondaryType = null,
                HealthPoints = 10,
                Attack = 11,
                Defense = 12,
                SpecialAttack = 13,
                SpecialDefense = 14,
                Speed = 15,
                IndividualValues = 16
            },
        };

        /// <summary>
        ///     Selects all the pokemon entities currently stored.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IPokemon> SelectAll()
        {
            return pokemons.OrderBy(p => p.Number);
        }
    }
}