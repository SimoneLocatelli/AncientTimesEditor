#region Usings

using Editor.MainMenu.Dependencies;
using FluentChecker;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Windows.Input;

#endregion Usings

namespace MainMenu.File
{
    /// <summary>
    ///     The "New" menu item
    /// </summary>
    [Export(FileMenuItem.InnerItemsKey, typeof (IMenuItem))]
    public class NewMenuItem : IMenuItem
    {
        /// <summary>
        ///     This key can be used as identifier to retrieve all the menu items that will populate the
        ///     inner items collection
        /// </summary>
        public const string InnerItemsKey = "NewMenuItemInnerItemsKey";

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
            get { return Resources.NewMenuItemHeader; }
        }

        /// <summary>
        ///     Gets or sets the priority.
        /// </summary>
        /// <value> The priority. </value>
        public int Priority
        {
            get { return 0; }
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="NewMenuItem" /> class.
        /// </summary>
        /// <param name="newMenuItem"> The new menu item. </param>
        [ImportingConstructor]
        public NewMenuItem([ImportMany(InnerItemsKey, typeof (IMenuItem))] IEnumerable<IMenuItem> menuItems)
        {
            Check.IfIsNull(menuItems).Throw<ArgumentNullException>(() => menuItems);

            innerMenuItems = menuItems.ToList();
        }
    }
}