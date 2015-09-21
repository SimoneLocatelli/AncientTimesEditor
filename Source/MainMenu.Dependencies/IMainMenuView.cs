using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace Editor.MainMenu.Dependencies
{
    /// <summary>
    ///     Collection for <see cref="IMenuItem" /> instances.
    /// </summary>
    [InheritedExport]
    public interface IMainMenuItemsCollection : IEnumerable<IMenuItem>
    {
    }
}