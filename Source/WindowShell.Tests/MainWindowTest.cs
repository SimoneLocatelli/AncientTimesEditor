using Editor.Logging.Dependencies.Fakes;
using Editor.WpfCommonLibrary.Dependencies.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Common;

namespace Editor.WindowShell.Tests
{
    [TestClass]
    public class MainWindowTest : EditorBaseTestClass
    {
        public void AssertContentsRegionNameConstValue()
        {
            using (ShimsContext.Create())
            {
                Assert.AreEqual("Contents", MainWindow.ContentsRegionNameConst);
            }
        }

        [TestMethod]
        public void WhenDependenciesAreInvalidItWillFail()
        {
            TestExpectedArgumentException<ArgumentNullException>(() => new MainWindow(null, null, null), "bindingErrorListener");

            TestExpectedArgumentException<ArgumentNullException>(() => new MainWindow(new StubIBindingErrorListener(), null, null), "logger");

            TestExpectedArgumentException<ArgumentNullException>(() => new MainWindow(new StubIBindingErrorListener(),
                new StubIEditorLogger(), null), "startupWindow");
        }
    }
}