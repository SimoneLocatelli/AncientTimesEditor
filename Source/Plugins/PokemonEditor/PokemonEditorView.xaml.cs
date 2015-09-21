using Editor.PokemonEditor.Dependencies;
using System.ComponentModel.Composition;
using System.Windows;

namespace Editor.PokemonEditor
{
    /// <summary>
    ///     The Pokemon Editor control
    /// </summary>
    [Export]
    public partial class PokemonEditorView : IPokemonEditorView
    {
        /// <summary>
        ///     Gets or sets the control.
        /// </summary>
        /// <value>
        ///     The control.
        /// </value>
        public UIElement Control
        {
            get { return this; }
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="PokemonEditorView" /> class.
        /// </summary>
        [ImportingConstructor]
        public PokemonEditorView(IPokemonEditorViewModel pokemonEditorViewModel)
        {
            InitializeComponent();

            DataContext = pokemonEditorViewModel;
        }
    }
}