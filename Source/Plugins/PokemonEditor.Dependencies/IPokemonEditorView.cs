using System.ComponentModel.Composition;
using System.Windows;

namespace Editor.PokemonEditor.Dependencies
{
    /// <summary>
    ///     The Pokemon Editor View that allows to add new Pokémons or to change
    ///     the existing ones.
    /// </summary>
    [InheritedExport]
    public interface IPokemonEditorView
    {
        /// <summary>
        ///     Gets or sets the control.
        /// </summary>
        /// <value>
        ///     The control.
        /// </value>
        UIElement Control { get; }
    }
}