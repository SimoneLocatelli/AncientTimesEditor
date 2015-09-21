using Editor.WindowShell.Dependencies;
using System.ComponentModel.Composition;

namespace Editor.PokemonEditor.Dependencies
{
    /// <summary>
    ///     A window containing the Pokémon Editor control.
    /// </summary>
    [InheritedExport]
    public interface IPokemonEditorWindow : IWindow
    {
    }
}