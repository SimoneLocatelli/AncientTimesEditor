using Editor.MainMenu.Dependencies;
using FluentChecker;
using MainMenu.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Windows.Controls;
using System.Windows.Input;

namespace MainMenu.Help
{
    /// <summary>
    ///     Menu Item for the Help Menu Category
    /// </summary>
    [Export(typeof(HelpMenuItem))]
    public class HelpMenuItem : IMenuItem
    {
        public const string HelpMenuItemChildrenKey = "HelpMenuItemChildrenKey";
        private readonly IEnumerable<IMenuItem> innerMenuItems;

        /// <summary>
        ///     Gets the command associated to the Menu Item.
        /// </summary>
        /// <value> The command. </value>
        public ICommand Command
        {
            get { return null; }
        }

        /// <summary>
        ///     Gets or sets the inner menu items contained in this instance.
        /// </summary>
        /// <value> The inner menu items. </value>
        public IEnumerable<IMenuItem> InnerMenuItems
        {
            get { return innerMenuItems; }
        }

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        /// <value> The name. </value>
        public string Name
        {
            get { return Resources.HelpMenuItemHeader; }
        }

        /// <summary>
        ///     Gets or sets the priority.
        /// </summary>
        /// <value> The priority. </value>
        public int Priority
        {
            get { return Settings.Default.MenuItemLastPriority; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HelpMenuItem" /> class.
        /// </summary>
        /// <param name="menuItems">The menu items.</param>
        [ImportingConstructor]
        public HelpMenuItem([ImportMany(HelpMenuItemChildrenKey, typeof(IMenuItem))] IEnumerable<IMenuItem> menuItems)
        {
            Check.IfIsNull(menuItems).Throw<ArgumentNullException>(() => menuItems);

            innerMenuItems = new List<IMenuItem>(menuItems);
        }
    }
}