using Editor.WpfCommonLibrary.Dependencies;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Tests.Common;

namespace WpfCommonLibrary.Tests
{
    [TestClass]
    public class ObservableExtensionsTest : EditorBaseTestClass
    {
        [TestMethod]
        public void WhenCollectionIsNullItWillFailToAddRange()
        {
            TestExpectedArgumentException<ArgumentNullException>(
                () => SetupClass().AddRange(default(IEnumerable<object>)), "collection");
        }

        [TestMethod]
        public void WhenCollectionIsValidItWillBeAdded()
        {
            var collection = new List<object>
            {
                new object(),
                new object(),
                new object(),
                new object(),
                new object(),
                new object()
            };

            var observableCollection = SetupClass();

            observableCollection.AddRange(collection);

            Assert.IsTrue(observableCollection.SequenceEqual(collection));
        }

        private ObservableCollection<object> SetupClass()
        {
            return new ObservableCollection<object>();
        }
    }
}