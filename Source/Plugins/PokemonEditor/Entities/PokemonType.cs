using Editor.Badasquall.Dependencies;
using Editor.WpfCommonLibrary.Dependencies;

namespace Editor.PokemonEditor.Entities
{
    /// <summary>
    /// The Pokemon Type 
    /// </summary>
    public class PokemonType : BaseViewModel, IPokemonType
    {
        private string name;

        /// <summary>
        /// The type name 
        /// </summary>
        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }
    }
}