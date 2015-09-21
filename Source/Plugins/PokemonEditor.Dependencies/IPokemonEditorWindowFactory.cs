using Editor.WindowShell.Dependencies;
using System.ComponentModel.Composition;

namespace Editor.PokemonEditor.Dependencies
{
    /// <summary>
    ///     Factory class that creates new windows o display the Pokemon Editor
    /// </summary>
    [InheritedExport]
    public interface IPokemonEditorWindowFactory
    {
        /// <summary>
        ///     Creates a new Window containing the <see cref="IPokemonEditorView" />
        /// </summary>
        /// <returns></returns>
        IWindow Create();
    }
}