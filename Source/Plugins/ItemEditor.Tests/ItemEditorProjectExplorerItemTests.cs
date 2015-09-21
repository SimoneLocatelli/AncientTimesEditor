using Editor.ItemEditor.Dependencies.Fakes;
using Editor.ItemEditor.Properties;
using Editor.ItemEditor.Tests.MockData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Common;

namespace Editor.ItemEditor.Tests
{
    [TestClass]
    public class ItemEditorProjectExplorerItemTests : EditorBaseTestClass
    {
        [TestMethod]
        public void AssertDefaultValues()
        {
            var instance = new ItemEditorProjectExplorerItem(new StubIItemEditorWindowFactory());

            Assert.IsNull(instance.Children);
            Assert.IsNull(instance.ContextMenuItems);
            Assert.IsFalse(instance.IsExpanded);
            Assert.IsFalse(instance.IsSelected);
            Assert.AreEqual(Resources.ProjectExplorerItemName, instance.Name);
            Assert.IsNull(instance.Value);
        }

        [TestMethod]
        public void WhenDependenciesAreInvalidItWillFail()
        {
            TestExpectedArgumentException<ArgumentNullException>(
                () => new ItemEditorProjectExplorerItem(null), "itemEditorWindowFactory");
        }

        [TestMethod]
        public void WhenOpenIsCalledItWillShowWindow()
        {
            var spyWindow = new SpyWindow();

            var instance = new ItemEditorProjectExplorerItem(new StubIItemEditorWindowFactory
            {
                Create = () => spyWindow
            });

            instance.Open();

            Assert.IsTrue(spyWindow.ShowHasBeenCalled);
        }
    }
}