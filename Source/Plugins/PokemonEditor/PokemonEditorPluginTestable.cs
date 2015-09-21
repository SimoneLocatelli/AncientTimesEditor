using Editor.PluginsTester.Dependencies;
using System.ComponentModel.Composition;
using System.Windows;

namespace Editor.PokemonEditor
{
    /// <summary>
    /// Plugin the allow to test the PokemonEditor.
    /// </summary>
    public class PokemonEditorPluginTestable : IPluginTestable
    {
        /// <summary>
        /// Gets the content to display in the Details view.
        /// </summary>
        /// <value>
        /// The content.
        /// </value>
        public UIElement Content { get; private set; }

        /// <summary>
        /// Gets the name of the plugin (or of the feature to test).
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name
        {
            get { return "Pokemon Editor"; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PokemonEditorPluginTestable"/> class.
        /// </summary>
        /// <param name="control">The control.</param>
        [ImportingConstructor]
        public PokemonEditorPluginTestable(PokemonEditorView control)
        {
            Content = control;
        }
    }
}