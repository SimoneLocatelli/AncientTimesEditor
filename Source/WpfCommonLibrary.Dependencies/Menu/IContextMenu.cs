using System.Collections.Generic;

namespace Editor.WpfCommonLibrary.Dependencies.Menu
{
    /// <summary>
    ///     Model containing the essential information to render a Context Menu.
    /// </summary>
    public interface IContextMenu
    {
        /// <summary>
        ///     Gets the items inside the context menu.
        /// </summary>
        /// <value>
        ///     The items.
        /// </value>
        IEnumerable<IMenuItem> Items { get; }
    }
}