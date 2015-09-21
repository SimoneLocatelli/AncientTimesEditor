using Editor.ItemEditor.Dependencies.Fakes;
using Editor.WindowShell.Dependencies.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Common;

namespace Editor.ItemEditor.Tests.MockData
{
    [TestClass]
    public class ItemEditorWindowFactoryTest : EditorBaseTestClass
    {
        [TestMethod]
        public void CreateWillCallWindowFactory()
        {
            var window = new StubIWindow();
            var windowFactory = new StubIWindowFactory
            {
                CreateStringUIElement = (s, element) => window
            };

            var instance = new ItemEditorWindowFactory(new StubIItemEditorClosingHandler(), windowFactory,
                new StubIItemEditorView());

            Assert.AreEqual(window, instance.Create());
        }

        [TestMethod]
        public void WhenDependenciesAreInvalidItWillFail()
        {
            TestExpectedArgumentException<ArgumentNullException>(() => new ItemEditorWindowFactory(null, null, null),
                "itemEditorClosingHandler");
            TestExpectedArgumentException<ArgumentNullException>(
                () => new ItemEditorWindowFactory(new StubIItemEditorClosingHandler(), null, null),
                "windowFactory");
            TestExpectedArgumentException<ArgumentNullException>(
                () => new ItemEditorWindowFactory(new StubIItemEditorClosingHandler(), new StubIWindowFactory(), null),
                "itemEditorView");
        }
    }
}