using System;
using Editor.PokemonEditor.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Common;

namespace Editor.PokemonEditor.Tests
{
    [TestClass]
    public class PokemonEditorViewModelTest : EditorBaseTestClass<PokemonEditorViewModel>
    {
        [TestMethod]
        public void WhenPokemonListIsEmptyCanDeleteWillBeFalse()
        {
            Test(resolver =>
            {
                var viewModel = new PokemonEditorViewModel(new MockPokemonRepository());

                viewModel.Pokemons.Clear();

                Assert.IsFalse(viewModel.CanDeletePokemon());
            });
        }

        [TestMethod]
        public void WhenPokemonListIsNotEmptyCanDeleteWillBeTrue()
        {
            var viewModel = new PokemonEditorViewModel(new MockPokemonRepository());

            Assert.IsTrue(viewModel.CanDeletePokemon());
        }

        [TestMethod]
        public void WhenDeletePokemonItWillBeRemoved()
        {
            var viewModel = new PokemonEditorViewModel(new MockPokemonRepository());
            var SelectedPokemon = viewModel.SelectedPokemon = viewModel.Pokemons[0];

            viewModel.DeletePokemon();

            Assert.IsTrue(viewModel.Pokemons[0] != SelectedPokemon);
        }
    }
}