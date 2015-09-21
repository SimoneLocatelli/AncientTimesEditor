using Editor.WpfCommonLibrary.Dependencies;
using Editor.WpfCommonLibrary.Dependencies.Menu;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Editor.ProjectExplorer.ContextMenus.CommonMenuItems
{
    /// <summary>
    ///     The context menu for a generic file type.
    /// </summary>
    public class GenericFileContextMenu : BaseViewModel, IContextMenu
    {
        private readonly ICollection<IMenuItem> items = new ObservableCollection<IMenuItem>();

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
    }
}