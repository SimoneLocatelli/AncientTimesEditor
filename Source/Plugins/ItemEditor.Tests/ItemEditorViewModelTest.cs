using Editor.Badasquall.Dependencies;
using Editor.Badasquall.Dependencies.Fakes;
using Editor.ItemEditor.Dependencies.Serializers;
using Editor.ItemEditor.Dependencies.Serializers.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Tests.Common;

namespace Editor.ItemEditor.Tests
{
    [TestClass]
    public class ItemEditorViewModelTest : EditorBaseTestClass
    {
        [TestMethod]
        public void AddNewItemCommandWillAddNewItem()
        {
            var viewModel = SetupClass();

            Assert.AreEqual(0, viewModel.Items.Count());

            viewModel.AddNewItemCommand.Execute(null);

            Assert.AreEqual(1, viewModel.Items.Count());
        }

        [TestMethod]
        public void SaveItemsWillSerializeThem()
        {
            var hasBeenCalled = false;
            var serializer = new StubIItemSerializer
            {
                SerializeIEnumerableOfIItem = items => hasBeenCalled = true
            };

            SetupClass(serializer).SaveItems();

            Assert.IsTrue(hasBeenCalled);
        }

        [TestMethod]
        public void WhenInitializedItemsListWillReadFromFil()
        {
            var itemsCollection = new List<IItem>();
            var itemDeserializer = new StubIItemDeserializer
            {
                Deserialize = () => itemsCollection
            };

            Assert.IsTrue(itemsCollection.SequenceEqual(SetupClass(itemDeserializer: itemDeserializer).Items));
        }

        [TestMethod]
        public void WhenInitializedSelectedItemWillBeTheFirst()
        {
            var firstItem =
                new StubIItem {NameGet = () => "Test3"};
            var itemsCollection = new List<IItem>
            {
                firstItem,
                new StubIItem {NameGet = () => "Test1"},
                new StubIItem {NameGet = () => "Test2"}
            };

            var itemDeserializer = new StubIItemDeserializer
            {
                Deserialize = () => itemsCollection
            };

            Assert.AreEqual(firstItem, SetupClass(itemDeserializer: itemDeserializer).SelectedItem);
        }

        private static ItemEditorViewModel SetupClass(IItemSerializer itemSerializer = null,
            IItemDeserializer itemDeserializer = null)
        {
            itemSerializer = itemSerializer ?? new StubIItemSerializer();
            itemDeserializer = itemDeserializer ?? new StubIItemDeserializer
            {
                Deserialize = () => new List<IItem>()
            };

            return new ItemEditorViewModel(itemSerializer, itemDeserializer);
        }
    }
}