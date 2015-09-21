using Editor.ItemEditor.Dependencies.Fakes;
using Editor.ItemEditor.Properties;
using Editor.WindowShell.Dependencies.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows;
using Tests.Common;

namespace Editor.ItemEditor.Tests
{
    [TestClass]
    public class ItemEditorWindowFactoryTest : EditorBaseTestClass
    {
        [TestMethod]
        public void CreateWillBuildNewWindow()
        {
            var element = new UIElement();
            var itemEditorView = new StubIItemEditorView
            {
                ControlGet = () => element
            };
            var windowFactory = new StubIWindowFactory
            {
                CreateStringUIElement = (windowTitle, control) =>
                {
                    Assert.AreEqual(Resources.ProjectExplorerItemName, windowTitle);
                    Assert.AreEqual(element, control);

                    return new StubIWindow();
                }
            };

            var itemEditorWindowFactory = new ItemEditorWindowFactory(new StubIItemEditorClosingHandler(), windowFactory, itemEditorView);

            itemEditorWindowFactory.Create();
        }

        [TestMethod]
        public void WhenDependenciesAreInvalidItWillFail()
        {
            TestExpectedArgumentException<ArgumentNullException>(() => new ItemEditorWindowFactory(null, null, null), "itemEditorClosingHandler");
            TestExpectedArgumentException<ArgumentNullException>(() => new ItemEditorWindowFactory(new StubIItemEditorClosingHandler(), null, null), "windowFactory");
            TestExpectedArgumentException<ArgumentNullException>(() => new ItemEditorWindowFactory(new StubIItemEditorClosingHandler(), new StubIWindowFactory(), null), "itemEditorView");
        }

        [TestMethod]
        public void WhenIsCalledTwiceItWillReturnSameInstance()
        {
            var window = new StubIWindow
            {
                IsLoadedGet = () => true
            };
            var windowFactory = new StubIWindowFactory { CreateStringUIElement = (s, element) => window };
            var itemEditorWindowFactory = new ItemEditorWindowFactory(new StubIItemEditorClosingHandler(), windowFactory, new StubIItemEditorView());

            Assert.AreEqual(window, itemEditorWindowFactory.Create());
            Assert.AreEqual(window, itemEditorWindowFactory.Create());
        }
    }
}