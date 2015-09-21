using Editor.WpfCommonLibrary.Dependencies.Menu;
using System.Collections.Generic;

namespace Editor.ProjectExplorer.Dependencies
{
    /// <summary>
    ///     Represents a single item inside the Project Explorer treeview
    /// </summary>
    public interface IProjectExplorerItem
    {
        /// <summary>
        ///     Gets or sets the children contained by the item.
        /// </summary>
        /// <value> The children. </value>
        ICollection<IProjectExplorerItem> Children { get; }

        /// <summary>
        ///     Gets the menu items that compose the Context Menu.
        /// </summary>
        /// <value> The context menu items. </value>
        IEnumerable<IMenuItem> ContextMenuItems { get; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is expanded.
        /// </summary>
        /// <value> <c> true </c> if this instance is expanded; otherwise, <c> false </c>. </value>
        bool IsExpanded { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is selected.
        /// </summary>
        /// <value> <c> true </c> if this instance is selected; otherwise, <c> false </c>. </value>
        bool IsSelected { get; set; }

        /// <summary>
        ///     Gets or sets the item name.
        /// </summary>
        /// <value> The name. </value>
        string Name { get; }

        /// <summary>
        ///     Gets the value represented by this item.
        /// </summary>
        /// <value>
        ///     The value.
        /// </value>
        object Value { get; }

        /// <summary>
        ///     Opens the value contained in the Project Explorer item displaying it in
        ///     a new View.
        /// </summary>
        void Open();
    }
}