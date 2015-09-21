using Editor.MainMenu.Dependencies;
using MainMenu.File;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Tests.Common;

namespace MainMenu.Tests.File
{
    [TestClass]
    public class NewMenuItemTest : EditorBaseTestClass
    {
        [TestMethod]
        public NewMenuItem SetupClass()
        {
            return new NewMenuItem(new List<IMenuItem>());
        }

        [TestMethod]
        public void WhenCorrectlyInitializedWillStoreInputValues()
        {
            var menuItem = SetupClass();

            Assert.IsNull(menuItem.Command);
            Assert.AreEqual(0, menuItem.Priority);
            Assert.IsFalse(string.IsNullOrWhiteSpace(menuItem.Name));
        }
    }
}