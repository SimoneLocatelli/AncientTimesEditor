using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Input.Fakes;
using Tests.Common;

namespace MainMenu.Tests
{
    [TestClass]
    public class SimpleMenuItemTest : EditorBaseTestClass
    {
        [TestMethod]
        public void WhenCorrectlyInitializedWillStoreInputValues()
        {
            var command = new StubICommand();
            var simpleMenuItem = new SimpleMenuItem("Test", 1, command);

            Assert.AreEqual("Test", simpleMenuItem.Name);
            Assert.AreEqual(1, simpleMenuItem.Priority);
            Assert.AreEqual(command, simpleMenuItem.Command);
        }

        public void WhenNameIsInvalidItWillFail()
        {
            Action<string> assertIsFailing =
                name =>
                    TestExpectedArgumentException<ArgumentException>(
                        () => new SimpleMenuItem(name, 1, new StubICommand()), "name");

            assertIsFailing(default(string));
            assertIsFailing(string.Empty);
            assertIsFailing("  ");
        }
    }
}