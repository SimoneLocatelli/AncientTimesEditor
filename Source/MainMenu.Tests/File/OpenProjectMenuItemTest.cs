using Editor.FileSystem.Dependencies.FileEntities;
using Editor.FileSystem.Dependencies.FileManagers.Fakes;
using Editor.WindowShell.Dependencies.Fakes;
using MainMenu.File;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Tests.Common;

namespace MainMenu.Tests.File
{
    [TestClass]
    public class OpenProjectMenuItemTest : EditorBaseTestClass
    {
        public OpenProjectMenuItem SetupClass()
        {
            return new OpenProjectMenuItem(new StubIFileOpener<IProject>(), new StubIOpenFileDialog<IProject>(),
                new StubIProjectLoader());
        }

        [TestMethod]
        public void WhenCorrectlyInitializedWillStoreInputValues()
        {
            var menuItem = SetupClass();

            Assert.IsNotNull(menuItem.Command);
            Assert.AreEqual(0, menuItem.Priority);
            Assert.AreEqual(0, menuItem.InnerMenuItems.Count());
            Assert.IsFalse(string.IsNullOrWhiteSpace(menuItem.Name));
        }
    }
}