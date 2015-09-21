using System.Collections.Generic;
using System.Windows.Input;

namespace Editor.WpfCommonLibrary.Dependencies.Menu
{
    /// <summary>
    ///     Model containing the essential information to render a Menu Item.
    /// </summary>
    public interface IMenuItem
    {
        /// <summary>
        ///     Gets the command associated to the Menu Item.
        /// </summary>
        /// <value> The command. </value>
        ICommand Command { get; }

        /// <summary>
        ///     Gets or sets the inner menu items contained in this instance.
        /// </summary>
        /// <value> The inner menu items. </value>
        IEnumerable<IMenuItem> InnerMenuItems { get; }

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        /// <value> The name. </value>
        string Name { get; }

        /// <summary>
        ///     Gets or sets the priority.
        /// </summary>
        /// <value> The priority. </value>
        int Priority { get; }
    }
}