using System;
using Editor.WpfCommonLibrary.Dependencies;
using Editor.WpfCommonLibrary.Dependencies.Menu;
using System.Collections.Generic;
using System.Windows.Input;
using FluentChecker;

namespace Editor.ProjectExplorer.ContextMenus
{
    /// <summary>
    ///     A simple menu item implementation. It doesn't allow to contains any child.
    /// </summary>
    public class MenuItem : BaseViewModel, IMenuItem
    {
        /// <summary>
        ///     Gets the command associated to the Menu Item.
        /// </summary>
        /// <value> The command. </value>
        public ICommand Command { get; protected set; }

        /// <summary>
        ///     Gets or sets the inner menu items contained in this instance.
        /// </summary>
        /// <value> The inner menu items. </value>
        public IEnumerable<IMenuItem> InnerMenuItems
        {
            get { return new List<IMenuItem>(); }
        }

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        /// <value> The name. </value>
        public string Name { get; protected set; }

        /// <summary>
        ///     Gets or sets the priority.
        /// </summary>
        /// <value> The priority. </value>
        public int Priority { get; protected set; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="MenuItem" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="priority">The priority.</param>
        /// <param name="command">The command.</param>
        public MenuItem(string name, int priority, ICommand command)
        {
            Check.IfIsNullOrWhiteSpace(name).Throw<ArgumentException>(() => name);

            Name = name;
            Priority = priority;
            Command = command;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="MenuItem" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="priority">The priority.</param>
        protected MenuItem(string name, int priority)
            : this(name, priority, null)
        {
        }
    }
}