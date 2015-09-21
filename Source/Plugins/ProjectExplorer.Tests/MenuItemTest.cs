using Editor.ProjectExplorer.ContextMenus;
using Editor.ProjectExplorer.Tests.MockData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Windows.Input;
using Tests.Common;

namespace Editor.ProjectExplorer.Tests
{
    [TestClass]
    public class MenuItemTest : EditorBaseTestClass
    {
        [TestMethod]
        public void AssertDefaultInitialization()
        {
            const string name = "Name";
            const int priority = 2;
            var command = new MockICommand();

            var menuItem = new MenuItem(name, priority, command);

            Assert.AreEqual(name, menuItem.Name);
            Assert.AreEqual(priority, menuItem.Priority);
            Assert.AreEqual(command, menuItem.Command);
            Assert.IsFalse(menuItem.InnerMenuItems.Any());
        }

        [TestMethod]
        public void WhenNameIsInvalidItWillFail()
        {
            Action<string> assertNameAction =
                name =>
                    TestExpectedArgumentException<ArgumentException>(() => new MenuItem(name, 0, default(ICommand)),
                        "name");

            assertNameAction(null);
            assertNameAction(string.Empty);
            assertNameAction("   ");
        }
    }
}