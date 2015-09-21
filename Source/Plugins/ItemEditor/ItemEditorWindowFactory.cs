using Editor.ItemEditor.Dependencies;
using Editor.ItemEditor.Properties;
using Editor.WindowShell.Dependencies;
using FluentChecker;
using System;
using System.ComponentModel.Composition;

namespace Editor.ItemEditor
{
    /// <summary>
    ///     Factory class to create ItemEditor windows
    /// </summary>
    public class ItemEditorWindowFactory : IItemEditorWindowFactory
    {
        private readonly IItemEditorClosingHandler itemEditorClosingHandler;
        private readonly IItemEditorView itemEditorView;
        private readonly IWindowFactory windowFactory;
        private IWindow currentWindow;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ItemEditorWindowFactory" /> class.
        /// </summary>
        [ImportingConstructor]
        public ItemEditorWindowFactory(IItemEditorClosingHandler itemEditorClosingHandler, IWindowFactory windowFactory,
            IItemEditorView itemEditorView)
        {
            Check.IfIsNull(itemEditorClosingHandler).Throw<ArgumentNullException>(() => itemEditorClosingHandler);
            Check.IfIsNull(windowFactory).Throw<ArgumentNullException>(() => windowFactory);
            Check.IfIsNull(itemEditorView).Throw<ArgumentNullException>(() => itemEditorView);

            this.itemEditorClosingHandler = itemEditorClosingHandler;
            this.windowFactory = windowFactory;
            this.itemEditorView = itemEditorView;
        }

        /// <summary>
        ///     Creates a new window containing the Item Editor.
        /// </summary>
        /// <returns></returns>
        public IWindow Create()
        {
            currentWindow = (currentWindow == null || !currentWindow.IsLoaded) ? InitializeNewWindow() : currentWindow;

            return currentWindow;
        }

        private IWindow InitializeNewWindow()
        {
            var window = windowFactory.Create(Resources.ProjectExplorerItemName, itemEditorView.Control);
            window.Closing += itemEditorClosingHandler.OnWindowClosing;
            itemEditorView.RefreshItems();

            return window;
        }
    }
}