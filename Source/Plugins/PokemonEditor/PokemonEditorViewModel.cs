using Editor.Badasquall.Dependencies;
using Editor.PokemonEditor.Dependencies;
using Editor.PokemonEditor.Entities;
using Editor.PokemonEditor.Properties;
using Editor.WpfCommonLibrary.Dependencies;
using FluentChecker;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Input;
using WpfCommonLibrary;

namespace Editor.PokemonEditor
{
    /// <summary>
    ///     ViewModel for the PokemonEditor
    /// </summary>
    public class PokemonEditorViewModel : BaseViewModel, IPokemonEditorViewModel
    {
        private readonly IPokemonSerializer pokemonSerializer;
        private ObservableCollection<IPokemon> pokemons;
        private ObservableCollection<IPokemonType> pokemonTypes;
        private IPokemon selectedPokemon;

        /// <summary>
        ///     Add a new Pokemon to the list
        /// </summary>
        public ICommand AddNewPokemonCommand { get; private set; }

        /// <summary>
        ///     Delete selected Pokemon from the list
        /// </summary>
        public ICommand DeletePokemonCommand { get; private set; }

        /// <summary>
        ///     Gets or sets the pokemons displayed in the Pokemon Editor List.
        /// </summary>
        /// <value> The pokemons. </value>
        public ObservableCollection<IPokemon> Pokemons
        {
            get { return pokemons; }
            private set { SetProperty(ref pokemons, value); }
        }

        /// <summary>
        ///     Gets or sets the pokemon types available in the Pokemon Editor Details View.
        /// </summary>
        /// <value>
        ///     The pokemon types.
        /// </value>
        public ObservableCollection<IPokemonType> PokemonTypes
        {
            get { return pokemonTypes; }
            private set { SetProperty(ref pokemonTypes, value); }
        }

        /// <summary>
        ///     Save the Pokemons list
        /// </summary>
        public ICommand SavePokemonCommand { get; private set; }

        /// <summary>
        ///     Gets or sets the currently selected pokemon.
        /// </summary>
        /// <value> The selected pokemon. </value>
        public IPokemon SelectedPokemon
        {
            get { return selectedPokemon; }
            set { SetProperty(ref selectedPokemon, value); }
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="PokemonEditorViewModel" /> class.
        /// </summary>
        /// <param name="pokemonRepository">The pokemon repository.</param>
        /// <param name="typeRepository">The pokemon type repository.</param>
        /// <param name="pokemonSerializer">The Pokemons serializer.</param>
        [ImportingConstructor]
        public PokemonEditorViewModel(IPokemonRepository pokemonRepository,
            IPokemonTypeRepository typeRepository,
            IPokemonSerializer pokemonSerializer)
        {
            Check.IfIsNull(pokemonRepository).Throw<ArgumentNullException>(() => pokemonRepository);
            Check.IfIsNull(typeRepository).Throw<ArgumentNullException>(() => typeRepository);

            Pokemons = new ObservableCollection<IPokemon>(pokemonRepository.SelectAll());
            PokemonTypes = new ObservableCollection<IPokemonType>(typeRepository.SelectAll());

            AddNewPokemonCommand = new Command(AddNewPokemon);
            DeletePokemonCommand = new Command(DeletePokemon, CanDeletePokemon);
            SavePokemonCommand = new Command(SavePokemon);

            this.pokemonSerializer = pokemonSerializer;
        }

        /// <summary>
        ///     Add a new Pokemon to the current list.
        /// </summary>
        public void AddNewPokemon()
        {
            const int firstPositionIndex = 0;

            Pokemons.Insert(firstPositionIndex, new Pokemon {Name = Resources.NewPokemonName});

            SelectedPokemon = Pokemons.First();
        }

        /// <summary>
        ///     Check if Pokemon list is empty or not
        /// </summary>
        /// <returns></returns>
        public bool CanDeletePokemon()
        {
            return !Check.IfIsEmpty(Pokemons);
        }

        /// <summary>
        ///     Delete selected Pokemon from the current list.
        /// </summary>
        public void DeletePokemon()
        {
            var result = MessageBox.Show(Resources.DeletePokemonConfirm, "", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                var ActualIndex = Pokemons.IndexOf(SelectedPokemon);
                if (ActualIndex == 0)
                    ActualIndex++;
                Pokemons.Remove(SelectedPokemon);

                if (!Check.IfIsEmpty(Pokemons))
                    SelectedPokemon = Pokemons[ActualIndex - 1];
            }
        }

        /// <summary>
        ///     Save pokemons list by serializing it
        /// </summary>
        public void SavePokemon()
        {
            pokemonSerializer.Serialize(Pokemons);
        }
    }
}