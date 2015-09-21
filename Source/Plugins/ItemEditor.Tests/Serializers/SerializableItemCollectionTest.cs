using Editor.Badasquall.Dependencies;
using Editor.Badasquall.Dependencies.Fakes;
using Editor.ItemEditor.Serializers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Tests.Common;

namespace Editor.ItemEditor.Tests.Serializers
{
    [TestClass]
    public class SerializableItemCollectionTest : EditorBaseTestClass
    {
        [TestMethod]
        public void WhenItemCollectionIsNullItWillFail()
        {
            TestExpectedArgumentException<ArgumentNullException>(
                () => new SerializableItemCollection(default(IEnumerable<IItem>)), "collection");
        }

        [TestMethod]
        public void WhenItemCollectionIsValidItWillInitializeCollection()
        {
            var items = new List<IItem>
            {
                new StubIItem(),
                new StubIItem(),
                new StubIItem(),
                new StubIItem(),
                new StubIItem(),
            };

            var collection = new SerializableItemCollection(items);

            Assert.AreEqual(items.Count, collection.Count);
        }
    }
}