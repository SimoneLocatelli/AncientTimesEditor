using System.ComponentModel.Composition;
using System.Windows;

namespace Editor.ItemEditor.Dependencies
{
    /// <summary>
    ///     The Item Editor control,
    ///     that allows to manage the information about the Item entities.
    /// </summary>
    [InheritedExport]
    public interface IItemEditorView
    {
        /// <summary>
        ///     Gets or sets the Item Editor User Control.
        /// </summary>
        /// <value>
        ///     The control.
        /// </value>
        UIElement Control { get; }

        /// <summary>
        ///     Requests to load and update the Items collection.
        /// </summary>
        void RefreshItems();
    }
}