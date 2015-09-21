using Editor.ItemEditor.Dependencies;
using FluentChecker;
using System;
using System.ComponentModel;
using System.ComponentModel.Composition;

namespace Editor.ItemEditor
{
    /// <summary>
    ///     Handle the logic to apply before the Item Editor is getting
    ///     closed.
    /// </summary>
    public class ItemEditorClosingHandler : IItemEditorClosingHandler
    {
        private readonly IItemEditorViewModel itemEditorViewModel;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ItemEditorClosingHandler" /> class.
        /// </summary>
        /// <param name="itemEditorViewModel">The item editor view model.</param>
        [ImportingConstructor]
        public ItemEditorClosingHandler(IItemEditorViewModel itemEditorViewModel)
        {
            Check.IfIsNull(itemEditorViewModel).Throw<ArgumentNullException>(() => itemEditorViewModel);

            this.itemEditorViewModel = itemEditorViewModel;
        }

        /// <summary>
        ///     Occurs when the Item Editor is being closed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="CancelEventArgs" /> instance containing the event data.</param>
        public void OnWindowClosing(object sender, CancelEventArgs e)
        {
            itemEditorViewModel.SaveItems();
        }
    }
}