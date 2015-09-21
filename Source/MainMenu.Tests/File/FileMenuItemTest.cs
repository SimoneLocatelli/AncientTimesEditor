using Editor.MainMenu.Dependencies;
using MainMenu.File;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Tests.Common;

namespace MainMenu.Tests.File
{
    [TestClass]
    public class FileMenuItemTest : EditorBaseTestClass
    {
        [TestMethod]
        public void WhenCorrectlyInitializedWillStoreInputValues()
        {
            var menuItem = SetupClass();

            Assert.IsNull(menuItem.Command);
            Assert.AreEqual(0, menuItem.Priority);
            Assert.IsFalse(string.IsNullOrWhiteSpace(menuItem.Name));
        }

        private static FileMenuItem SetupClass()
        {
            return new FileMenuItem(new List<IMenuItem>());
        }
    }
}