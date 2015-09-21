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
    public class ProjectContextMenuTest : EditorBaseTestClass
    {
        [TestMethod]
        public void AssertMenuItemsKey()
        {
            Assert.AreEqual("ProjectContextMenuInnerItemsKey", ProjectContextMenu.ProjectContextMenuInnerItemsKey);
        }

        [TestMethod]
        public void WhenMenuItemsCollectionIsNullItWillFail()
        {
            TestExpectedArgumentException<ArgumentNullException>(
                () => new ProjectContextMenu(default(IEnumerable<IMenuItem>)), "menuItems");
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
            Assert.IsTrue(new ProjectContextMenu(menuItems).Items.SequenceEqual(menuItems));
        }
    }
}