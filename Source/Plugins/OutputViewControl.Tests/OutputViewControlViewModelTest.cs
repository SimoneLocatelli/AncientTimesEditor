using Editor.Logging.Dependencies.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OutputView;
using System;
using System.Fakes;
using Tests.Common;

namespace Editor.OutputView.Tests
{
    [TestClass]
    public class OutputViewControlViewModelTest : EditorBaseTestClass
    {
        [TestMethod]
        public void WhenAMessageIsLoggedCategoriesWillBecomeEnabled()
        {
            var viewModel = SetupClass();

            Assert.IsFalse(viewModel.AreCategoriesEnabled);
            Assert.IsNull(viewModel.SelectedCategory);

            viewModel.Log("TestCategory", "Test");

            Assert.IsTrue(viewModel.AreCategoriesEnabled);
            Assert.AreEqual("TestCategory", viewModel.SelectedCategory);
        }

        [TestMethod]
        public void WhenClearLogItWillBeEmpty()
        {
            var viewModel = SetupClass();

            Assert.AreEqual(string.Empty, viewModel.CurrentLog);

            viewModel.Log("TestCategory", "Test");

            Assert.IsFalse(string.IsNullOrWhiteSpace(viewModel.CurrentLog));

            viewModel.ClearLog();

            Assert.AreEqual(string.Empty, viewModel.CurrentLog);
        }

        [TestMethod]
        public void WhenInstantiatedItWillHaveDefaultValues()
        {
            var viewModel = SetupClass();

            Assert.AreEqual(string.Empty, viewModel.CurrentLog);
            Assert.IsFalse(viewModel.IsLogCleanable);
            Assert.IsFalse(viewModel.AreCategoriesEnabled);
        }

        [TestMethod]
        public void WhenLogMessageCurrentLogWillBeUpdated()
        {
            TestWithShims(() =>
            {
                ShimDateTime.NowGet = () => new DateTime(2015, 1, 1, 12, 0, 0, 0);

                var viewModel = SetupClass();

                Assert.AreEqual(string.Empty, viewModel.CurrentLog);
                viewModel.Log("TestCategory", "Test");
                Assert.AreEqual("12:00:00:000 - Test\n", viewModel.CurrentLog);
            });
        }

        private OutputViewControlViewModel SetupClass()
        {
            return new OutputViewControlViewModel(new StubIEditorLogger());
        }
    }
}