using Editor.ItemEditor.Dependencies.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Common;

namespace Editor.ItemEditor.Tests
{
    [TestClass]
    public class ItemEditorClosingHandlerTest : EditorBaseTestClass
    {
        [TestMethod]
        public void WhenClosingItWillSaveItems()
        {
            var hasBeenCalled = false;
            var itemEditorViewModel = new StubIItemEditorViewModel
            {
                SaveItems = () => hasBeenCalled = true
            };

            var itemEditorClosingHandler = new ItemEditorClosingHandler(itemEditorViewModel);

            itemEditorClosingHandler.OnWindowClosing(null, null);

            Assert.IsTrue(hasBeenCalled);
        }

        [TestMethod]
        public void WhenDependenciesAreInvalidItWillFail()
        {
            TestExpectedArgumentException<ArgumentNullException>(() => new ItemEditorClosingHandler(null),
                "itemEditorViewModel");
        }
    }
}