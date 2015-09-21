using Editor.FileSystem.Dependencies.FileEntities;
using Editor.WindowShell.Dependencies.Fakes;
using MainMenu.File;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Common;

namespace MainMenu.Tests.File
{
    [TestClass]
    public class NewProjectMenuItemTest : EditorBaseTestClass
    {
        [TestMethod]
        public void WhenCorrectlyInitializedWillStoreInputValues()
        {
            var menuItem = SetupClass();

            Assert.IsNotNull(menuItem.Command);
            Assert.AreEqual(0, menuItem.Priority);
            Assert.IsFalse(string.IsNullOrWhiteSpace(menuItem.Name));
        }

        private NewProjectMenuItem SetupClass()
        {
            return new NewProjectMenuItem(new StubISaveFileWizard<IProject>());
        }
    }
}