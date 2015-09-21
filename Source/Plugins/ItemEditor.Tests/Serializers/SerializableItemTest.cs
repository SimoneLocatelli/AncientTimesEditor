using Editor.Badasquall.Dependencies;
using Editor.Badasquall.Dependencies.Fakes;
using Editor.ItemEditor.Serializers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using Tests.Common;

namespace Editor.ItemEditor.Tests.Serializers
{
    [TestClass]
    public class SerializableItemTest : EditorBaseTestClass
    {
        [TestMethod]
        public void AssertExpectedItemPropertiesCount()
        {
            Assert.AreEqual(3, PropertiesNavigator.GetPublicProperties<IItem>().Count(),
                "If this test fails it means the Item interface probably has been changed so we need to update the logic to convert to and into SerializableItem");
        }

        [TestMethod]
        public void AssertToItemCopyAllProperties()
        {
            var item = new StubIItem
            {
                IdGet = () => 1,
                NameGet = () => "Test",
                ItemCategoryGet = () => new StubIItemCategory()
            };

            var convertedItem = new SerializableItem(item).ToIItem();

            Assert.IsNotNull(convertedItem);
            Assert.AreEqual(item.IdGet(), convertedItem.Id);
            Assert.AreEqual(item.NameGet(), convertedItem.Name);
            Assert.IsNotNull(item.ItemCategoryGet());
        }

        [TestMethod]
        public void AssertValuesHaveBeenCopied()
        {
            var mockItem = new MockItem();

            var serializableItem = new SerializableItem(mockItem);

            Assert.AreEqual(mockItem.Id, serializableItem.Id);
            Assert.AreEqual(mockItem.Name, serializableItem.Name);
            Assert.AreEqual(mockItem.ItemCategory, serializableItem.ItemCategory);
        }

        [TestMethod]
        public void WhenItemIsNullItWillFail()
        {
            TestExpectedArgumentException<ArgumentNullException>(() => new SerializableItem(null), "item");
        }

        private class MockItem : IItem
        {
            private readonly StubIItemCategory stubIItemCategory = new StubIItemCategory();
            private int id;
            private IItemCategory itemCategory;
            private string name;

            public int Id
            {
                get { return 1; }
            }

            public IItemCategory ItemCategory
            {
                get { return stubIItemCategory; }
            }

            public string Name
            {
                get { return "Name"; }
            }
        }
    }
}