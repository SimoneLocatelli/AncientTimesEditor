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
    ///     The context menu for the Project type.
    /// </summary>
    public class ProjectContextMenu : BaseViewModel, IContextMenu
    {
        /// <summary>
        ///     Key to identify all the Inner Menu Items that belongs to this class.
        /// </summary>
        public const string ProjectContextMenuInnerItemsKey = "ProjectContextMenuInnerItemsKey";

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
        ///     Initializes a new instance of the <see cref="ProjectContextMenu" /> class.
        /// </summary>
        /// <param name="menuItems">The menu items.</param>
        public ProjectContextMenu(
            [ImportMany(ProjectContextMenuInnerItemsKey, typeof (IMenuItem))] IEnumerable<IMenuItem> menuItems)
        {
            Check.IfIsNull(menuItems).Throw<ArgumentNullException>(() => menuItems);

            items.AddRange(menuItems);
        }
    }
}