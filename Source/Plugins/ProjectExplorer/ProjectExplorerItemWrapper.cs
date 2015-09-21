using Editor.ProjectExplorer.Dependencies;
using Editor.WpfCommonLibrary.Dependencies;
using Editor.WpfCommonLibrary.Dependencies.Menu;
using FluentChecker;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Input;
using WpfCommonLibrary;

namespace Editor.ProjectExplorer
{
    /// <summary>
    ///     Wrapper for the Project Explorer Item to centralize reusable code.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ProjectExplorerItemWrapper : BaseViewModel, IProjectExplorerItem
    {
        private readonly ICommand openCommand;
        private readonly IProjectExplorerItem projectExplorerItem;

        /// <summary>
        ///     Gets or sets the children contained by the item.
        /// </summary>
        /// <value>
        ///     The children.
        /// </value>
        public ICollection<IProjectExplorerItem> Children
        {
            get { return projectExplorerItem.Children; }
        }

        /// <summary>
        ///     Gets the menu items that compose the Context Menu.
        /// </summary>
        /// <value>
        ///     The context menu items.
        /// </value>
        public IEnumerable<IMenuItem> ContextMenuItems
        {
            get { return projectExplorerItem.ContextMenuItems; }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is expanded.
        /// </summary>
        /// <value>
        ///     <c> true </c> if this instance is expanded; otherwise, <c> false </c>.
        /// </value>
        public bool IsExpanded
        {
            get { return projectExplorerItem.IsExpanded; }
            set { projectExplorerItem.IsExpanded = value; }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is selected.
        /// </summary>
        /// <value>
        ///     <c> true </c> if this instance is selected; otherwise, <c> false </c>.
        /// </value>
        public bool IsSelected
        {
            get { return projectExplorerItem.IsSelected; }
            set { projectExplorerItem.IsSelected = value; }
        }

        /// <summary>
        ///     Gets or sets the item name.
        /// </summary>
        /// <value>
        ///     The name.
        /// </value>
        public string Name
        {
            get { return projectExplorerItem.Name; }
        }

        /// <summary>
        ///     Gets the command called to Open the value of this item.
        /// </summary>
        /// <value>
        ///     The open command.
        /// </value>
        public ICommand OpenCommand
        {
            get { return openCommand; }
        }

        /// <summary>
        ///     Gets the value represented by this item.
        /// </summary>
        /// <value>
        ///     The value.
        /// </value>
        public object Value
        {
            get { return projectExplorerItem.Value; }
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ProjectExplorerItemWrapper" /> class.
        /// </summary>
        /// <param name="projectExplorerItem">The project explorer item.</param>
        public ProjectExplorerItemWrapper(IProjectExplorerItem projectExplorerItem)
        {
            Check.IfIsNull(projectExplorerItem).Throw<ArgumentNullException>(() => projectExplorerItem);

            this.projectExplorerItem = projectExplorerItem;

            openCommand = new Command(Open);
        }

        /// <summary>
        ///     Opens the value contained in the Project Explorer item displaying it in
        ///     a new View.
        /// </summary>
        public void Open()
        {
            projectExplorerItem.Open();
        }
    }
}