using Editor.Badasquall.Dependencies;
using Editor.WpfCommonLibrary.Dependencies;

namespace Editor.PokemonEditor
{
    /// <summary>
    ///     Bindable <see cref="IPokemonType" /> implementation
    /// </summary>
    public class PokemonTypeModel : BaseViewModel, IPokemonType
    {
        private string name;

        /// <summary>
        ///     Gets the type name.
        /// </summary>
        /// <value>
        ///     The type name.
        /// </value>
        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="PokemonTypeModel" /> class.
        /// </summary>
        public PokemonTypeModel()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="PokemonTypeModel" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public PokemonTypeModel(string name)
        {
            Name = name;
        }
    }
}