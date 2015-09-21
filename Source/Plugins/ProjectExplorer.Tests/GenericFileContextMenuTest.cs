#region Usings

using Editor.ProjectExplorer.ContextMenus.CommonMenuItems;
using Editor.WpfCommonLibrary.Dependencies.Menu;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Tests.Common;

#endregion Usings

namespace Editor.ProjectExplorer.Tests
{
    [TestClass]
    public class GenericFileContextMenuTest : EditorBaseTestClass
    {
        [TestMethod]
        public void AssertItemsCollectionIsNull()
        {
            var contextMenu = new GenericFileContextMenu();
            Assert.IsTrue(contextMenu.Items.SequenceEqual(new List<IMenuItem>()));
        }
    }
}