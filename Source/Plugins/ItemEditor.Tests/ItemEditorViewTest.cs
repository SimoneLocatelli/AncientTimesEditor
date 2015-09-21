using Editor.CommonControls.Dependencies;
using Editor.CommonControls.Dependencies.Fakes;
using Editor.ItemEditor.Dependencies;
using Editor.ItemEditor.Dependencies.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Common;

namespace Editor.ItemEditor.Tests
{
    [TestClass]
    public class ItemEditorViewTest : EditorBaseTestClass
    {
        [TestMethod]
        public void ControlPropertyWillReturnSelfInstance()
        {
            var instance = SetupClass();

            Assert.AreEqual(instance, instance.Control);
        }

        [TestMethod]
        public void DataContextWillBeInputViewModel()
        {
            var viewModel = new StubIItemEditorViewModel();

            Assert.AreEqual(viewModel, SetupClass(viewModel).DataContext);
        }

        [TestMethod]
        public void WhenDependeciesAreNullItWillFail()
        {
            TestExpectedArgumentException<ArgumentNullException>(() => new ItemEditorView(null, null), "itemEditorViewModel");
            TestExpectedArgumentException<ArgumentNullException>(() => new ItemEditorView(new StubIItemEditorViewModel(), null), "imageImporterView");
        }

        [TestMethod]
        public void WhenRefreshItemsWillCallViewModel()
        {
            var hasBeenCalled = false;
            var viewModel = new StubIItemEditorViewModel
            {
                RefreshItemsList = () => hasBeenCalled = true
            };

            SetupClass(viewModel).RefreshItems();

            Assert.IsTrue(hasBeenCalled);
        }

        private static ItemEditorView SetupClass(IItemEditorViewModel itemEditorViewModel = null, IImageImporterView imageImporterView = null)
        {
            itemEditorViewModel = itemEditorViewModel ?? new StubIItemEditorViewModel();
            imageImporterView = imageImporterView ?? new StubIImageImporterView();
            return new ItemEditorView(itemEditorViewModel, imageImporterView);
        }
    }
}