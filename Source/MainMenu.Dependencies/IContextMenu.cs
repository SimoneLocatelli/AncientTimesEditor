using System.Collections.Generic;

namespace Editor.MainMenu.Dependencies
{
    /// <summary>
    ///     Describes a context menu for UI element.
    /// </summary>
    public interface IContextMenu
    {
        /// <summary>
        ///     Gets the items contained inside the context menu.
        /// </summary>
        /// <value>
        ///     The items.
        /// </value>
        IEnumerable<IMenuItem> Items { get; }
    }
}