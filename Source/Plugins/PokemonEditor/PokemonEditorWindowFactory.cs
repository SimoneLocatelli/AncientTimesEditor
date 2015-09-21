using Editor.PokemonEditor.Dependencies;
using Editor.PokemonEditor.Properties;
using Editor.WindowShell.Dependencies;
using FluentChecker;
using System;
using System.ComponentModel.Composition;

namespace Editor.PokemonEditor
{
    /// <summary>
    ///     Factory class that creates new windows o display the Pokemon Editor
    /// </summary>
    public class PokemonEditorWindowFactory : IPokemonEditorWindowFactory
    {
        private readonly ExportFactory<IPokemonEditorView> pokemonEditorViewFactory;
        private readonly IWindowFactory windowFactory;
        private IWindow currentWindow;

        /// <summary>
        ///     Initializes a new instance of the <see cref="PokemonEditorWindowFactory" /> class.
        /// </summary>
        /// <param name="windowFactory">The window factory.</param>
        /// <param name="pokemonEditorViewFactory">The pokemon editor window factory.</param>
        [ImportingConstructor]
        public PokemonEditorWindowFactory(IWindowFactory windowFactory,
            ExportFactory<IPokemonEditorView> pokemonEditorViewFactory)
        {
            Check.IfIsNull(windowFactory).Throw<ArgumentNullException>(() => windowFactory);
            this.windowFactory = windowFactory;
            this.pokemonEditorViewFactory = pokemonEditorViewFactory;
        }

        /// <summary>
        ///     Creates a new Window containing the <see cref="IPokemonEditorView" />
        /// </summary>
        /// <returns></returns>
        public IWindow Create()
        {
            if (currentWindow != null && currentWindow.IsLoaded) return currentWindow;

            var pokemonEditorView = pokemonEditorViewFactory.CreateExport().Value;

            currentWindow = windowFactory.Create(Resources.ProjectExplorerItemName, pokemonEditorView.Control);

            return currentWindow;
        }
    }
}