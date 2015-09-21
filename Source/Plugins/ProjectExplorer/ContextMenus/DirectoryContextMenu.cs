#region Usings

using Editor.WpfCommonLibrary.Dependencies;
using Editor.WpfCommonLibrary.Dependencies.Menu;
using FluentChecker;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;

#endregion Usings

namespace Editor.ProjectExplorer.ContextMenus
{
    /// <summary>
    ///     The context menu for a Directory type
    /// </summary>
    public class DirectoryContextMenu : BaseViewModel, IContextMenu
    {
        /// <summary>
        ///     Key to identify all the Inner Menu Items that belongs to this class.
        /// </summary>
        public const string DirectoryContextMenuInnerItemsKey = "DirectoryContextMenuInnerItemsKey";

        private readonly ObservableCollection<IMenuItem> items = new ObservableCollection<IMenuItem>();

        /// <summary>
        ///     Gets the items contained inside the context menu.
        /// </summary>
        /// <value>
        ///     The items.
        /// </value>
        public IEnumerable<IMenuItem> Items
        {
            get { return items; }
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="DirectoryContextMenu" /> class.
        /// </summary>
        /// <param name="menuItems">The menu items.</param>
        public DirectoryContextMenu(
            [ImportMany(DirectoryContextMenuInnerItemsKey, typeof (IMenuItem))] IEnumerable<IMenuItem> menuItems)
        {
            Check.IfIsNull(menuItems).Throw<ArgumentNullException>(() => menuItems);

            items.AddRange(menuItems);
        }
    }
}