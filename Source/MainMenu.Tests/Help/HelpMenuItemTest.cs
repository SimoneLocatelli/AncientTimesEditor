using Editor.MainMenu.Dependencies;
using Editor.MainMenu.Dependencies.Fakes;
using MainMenu.Help;
using MainMenu.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Tests.Common;

namespace MainMenu.Tests.Help
{
    [TestClass]
    public class HelpMenuItemTest : EditorBaseTestClass
    {
        [TestMethod]
        public void WhenCorrectlyInitializedWillStoreInputValues()
        {
            var items = new List<IMenuItem>
            {
                new StubIMenuItem()
            };

            var instance = new HelpMenuItem(items);

            Assert.IsNull(instance.Command);
            Assert.IsFalse(string.IsNullOrWhiteSpace(instance.Name));
            Assert.AreEqual(Settings.Default.MenuItemLastPriority, instance.Priority);
            Assert.IsTrue(items.SequenceEqual(instance.InnerMenuItems));
        }
    }
}