using Editor.MainMenu.Dependencies;
using FluentChecker;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace MainMenu
{
    /// <summary>
    ///     Simple implementation of the <see cref="IMenuItem" /> interface
    /// </summary>
    internal class SimpleMenuItem : IMenuItem
    {
        private readonly ICommand command;
        private readonly string name;
        private readonly int priority;

        /// <summary>
        ///     Gets the command associated to the Menu Item.
        /// </summary>
        /// <value> The command. </value>
        public ICommand Command
        {
            get { return command; }
        }

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
        public string Name
        {
            get { return name; }
        }

        /// <summary>
        ///     Gets or sets the priority.
        /// </summary>
        /// <value> The priority. </value>
        public int Priority
        {
            get { return priority; }
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="SimpleMenuItem" /> class.
        /// </summary>
        /// <param name="name"> The name. </param>
        /// <param name="priority"> The priority. </param>
        /// <param name="command"> The command. </param>
        public SimpleMenuItem(string name, int priority, ICommand command)
        {
            Check.IfIsNullOrWhiteSpace(name).Throw<ArgumentException>(() => name);

            this.name = name;
            this.priority = priority;
            this.command = command;
        }
    }
}