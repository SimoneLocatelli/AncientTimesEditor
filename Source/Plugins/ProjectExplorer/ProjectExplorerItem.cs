using Editor.ProjectExplorer.Dependencies;
using Editor.WpfCommonLibrary.Dependencies;
using Editor.WpfCommonLibrary.Dependencies.Menu;
using FluentChecker;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;

namespace Editor.ProjectExplorer
{
    /// <summary>
    ///     Represents a single item inside the Project Explorer treeview
    /// </summary>
    public class ProjectExplorerItem : BaseViewModel, IProjectExplorerItem
    {
        private readonly ObservableCollection<IProjectExplorerItem> children;
        private readonly ObservableCollection<IMenuItem> contextMenuItems;
        private readonly object itemValue;
        private bool isExpanded;
        private bool isSelected;

        /// <summary>
        ///     Gets or sets the children contained by the item.
        /// </summary>
        /// <itemValue> The children. </itemValue>
        public ICollection<IProjectExplorerItem> Children
        {
            get { return children; }
        }

        /// <summary>
        ///     Gets the menu items that compose the Context Menu.
        /// </summary>
        /// <itemValue> The context menu items. </itemValue>
        public IEnumerable<IMenuItem> ContextMenuItems
        {
            get { return contextMenuItems; }
        }

        /// <summary>
        ///     Gets or sets a itemValue indicating whether this instance is expanded.
        /// </summary>
        /// <itemValue> <c> true </c> if this instance is expanded; otherwise, <c> false </c>. </itemValue>
        public bool IsExpanded
        {
            get { return isExpanded; }
            [ExcludeFromCodeCoverage] set { SetProperty(ref isExpanded, value); }
        }

        /// <summary>
        ///     Gets or sets a itemValue indicating whether this instance is selected.
        /// </summary>
        /// <itemValue> <c> true </c> if this instance is selected; otherwise, <c> false </c>. </itemValue>
        public bool IsSelected
        {
            get { return isSelected; }
            [ExcludeFromCodeCoverage] set { SetProperty(ref isSelected, value); }
        }

        /// <summary>
        ///     Gets or sets the item name.
        /// </summary>
        /// <itemValue> The name. </itemValue>
        public virtual string Name
        {
            get { return Value.ToString(); }
        }

        /// <summary>
        ///     Gets the itemValue represented by this item.
        /// </summary>
        /// <itemValue>
        ///     The itemValue.
        /// </itemValue>
        public object Value
        {
            get { return itemValue; }
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ProjectExplorerItem" /> class.
        /// </summary>
        /// <param name="itemValue">The itemValue rappresented by this item.</param>
        /// <param name="contextMenu">The context menu.</param>
        public ProjectExplorerItem(object itemValue, IContextMenu contextMenu)
        {
            Check.IfIsNull(itemValue).Throw<ArgumentNullException>(() => itemValue);

            this.itemValue = itemValue;
            var ctxMenuItems = contextMenu == null ? new List<IMenuItem>() : contextMenu.Items;
            contextMenuItems = new ObservableCollection<IMenuItem>(ctxMenuItems);
            children = new ObservableCollection<IProjectExplorerItem>();
        }

        /// <summary>
        ///     Opens the value contained in the Project Explorer item displaying it in
        ///     a new View.
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        public void Open()
        {
            throw new NotImplementedException();
        }
    }
}