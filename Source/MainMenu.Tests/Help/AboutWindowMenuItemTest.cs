using Editor.WindowShell.Dependencies;
using Editor.WindowShell.Dependencies.Fakes;
using MainMenu.Help;
using MainMenu.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Tests.Common;

namespace MainMenu.Tests.Help
{
    [TestClass]
    public class AboutWindowMenuItemTest : EditorBaseTestClass
    {
        public AboutWindowMenuItem SetupClass(IAboutWindow aboutWindow = default(IAboutWindow))
        {
            aboutWindow = aboutWindow ?? new StubIAboutWindow();

            return new AboutWindowMenuItem(ExportFactoryHelper.BuildExportFactory(aboutWindow));
        }

        [TestMethod]
        public void WhenCorrectlyInitializedWillStoreInputValues()
        {
            var instance = SetupClass();

            Assert.IsNotNull(instance.Command);
            Assert.IsFalse(string.IsNullOrWhiteSpace(instance.Name));
            Assert.AreEqual(Settings.Default.MenuItemLastPriority, instance.Priority);
            Assert.AreEqual(0, instance.InnerMenuItems.Count());
        }

        [TestMethod]
        public void WhenIsExecutedItWillCallAboutWindow()
        {
            var hasBeenCalled = false;

            var instance = SetupClass(new StubIAboutWindow
            {
                ShowDialog = () => hasBeenCalled = true
            });

            instance.Command.Execute(default(object));

            Assert.IsTrue(hasBeenCalled);
        }
    }
}