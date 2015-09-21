using Editor.ProjectExplorer.Dependencies;
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
    public class ProjectExplorerItemTest : EditorBaseTestClass
    {
        private const string FileName = "Test";

        private readonly MockObject mockObject = new MockObject(FileName);

        [TestMethod]
        public void AssertDefaultInitialization()
        {
            var projectExplorerItem = SetupClass();

            Assert.AreEqual(mockObject, projectExplorerItem.Value);
            Assert.IsTrue(projectExplorerItem.Children.SequenceEqual(new List<IProjectExplorerItem>()));
            Assert.IsTrue(projectExplorerItem.ContextMenuItems.SequenceEqual(new List<IMenuItem>()));
            Assert.IsFalse(projectExplorerItem.IsExpanded);
            Assert.IsFalse(projectExplorerItem.IsSelected);
            Assert.AreEqual(projectExplorerItem.Name, FileName);
        }

        [TestMethod]
        public void WhenContextMenuIsValidItWillBeStored()
        {
            var menuItemsCollection = new List<IMenuItem>
            {
                new StubIMenuItem(),
                new StubIMenuItem(),
                new StubIMenuItem(),
                new StubIMenuItem()
            };

            var contextMenu = new StubIContextMenu
            {
                ItemsGet = () => menuItemsCollection
            };
            var projectExplorerItem = SetupClass(contextMenu);

            Assert.IsTrue(projectExplorerItem.ContextMenuItems.SequenceEqual(menuItemsCollection));
        }

        [TestMethod]
        public void WhenFileIsNullItWillFail()
        {
            TestExpectedArgumentException<ArgumentNullException>(
                () => new ProjectExplorerItem(default(object),
                    default(IContextMenu)), "itemValue");
        }

        private ProjectExplorerItem SetupClass(IContextMenu contextMenu = default(IContextMenu))
        {
            return new ProjectExplorerItem(mockObject, contextMenu);
        }

        private class MockObject
        {
            public string Value { get; set; }

            public MockObject(string value)
            {
                Value = value;
            }

            public override string ToString()
            {
                return Value;
            }
        }
    }
}