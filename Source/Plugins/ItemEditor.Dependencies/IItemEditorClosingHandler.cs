using System.ComponentModel;
using System.ComponentModel.Composition;

namespace Editor.ItemEditor.Dependencies
{
    /// <summary>
    ///     Handle the logic to apply before the Item Editor is getting
    ///     closed.
    /// </summary>
    [InheritedExport]
    public interface IItemEditorClosingHandler
    {
        /// <summary>
        ///     Occurs when the Item Editor is being closed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="CancelEventArgs" /> instance containing the event data.</param>
        void OnWindowClosing(object sender, CancelEventArgs e);
    }
}