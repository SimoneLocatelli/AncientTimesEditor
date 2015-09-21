using Editor.Badasquall.Dependencies;
using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace Editor.ItemEditor.Dependencies
{
    /// <summary>
    ///     The View Model for the <see cref="IItemEditorView" /> control
    /// </summary>
    [InheritedExport]
    public interface IItemEditorViewModel
    {
        /// <summary>
        ///     Gets or sets the Items stored.
        /// </summary>
        /// <value>
        ///     The items.
        /// </value>
        IEnumerable<IItem> Items { get; }

        /// <summary>
        ///     Read again the list from the default source and update the displayed list.
        /// </summary>
        void RefreshItemsList();

        /// <summary>
        ///     Saves the items currently stored on the default location.
        /// </summary>
        void SaveItems();
    }
}