using Editor.ProjectExplorer.ContextMenus;
using Editor.WpfCommonLibrary.Dependencies.Menu;
using Editor.WpfCommonLibrary.Dependencies.Menu.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Tests.Common;

namespace Editor.ProjectExplorer.Tests
{
    [TestClass]
    public class DirectoryContextMenuTest : EditorBaseTestClass
    {
        [TestMethod]
        public void AssertMenuItemsKey()
        {
            Assert.AreEqual("DirectoryContextMenuInnerItemsKey", DirectoryContextMenu.DirectoryContextMenuInnerItemsKey);
        }

        [TestMethod]
        public void WhenMenuItemsCollectionIsNullItWillFail()
        {
            TestExpectedArgumentException<ArgumentNullException>(
                () => new DirectoryContextMenu(default(IEnumerable<IMenuItem>)), "menuItems");
        }

        [TestMethod]
        public void WhenMenuItemsCollectionIsValidItWillStoreIt()
        {
            var menuItems = new List<IMenuItem>
            {
                new StubIMenuItem(),
                new StubIMenuItem(),
                new StubIMenuItem(),
            };
            Assert.IsTrue(new DirectoryContextMenu(menuItems).Items.SequenceEqual(menuItems));
        }
    }
}