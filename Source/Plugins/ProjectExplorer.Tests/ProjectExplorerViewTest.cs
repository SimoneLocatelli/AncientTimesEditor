using Editor.ProjectExplorer.Dependencies.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Common;

namespace Editor.ProjectExplorer.Tests
{
    [TestClass]
    public class ProjectExplorerViewTest : EditorBaseTestClass
    {
        [TestMethod]
        public void AssertViewModelIsValid()
        {
            var viewModel = new MockViewModel();
            var instance = new ProjectExplorerView(viewModel);

            Assert.AreEqual(viewModel, instance.DataContext);
        }

        [TestMethod]
        public void WhenDependenciesAreInvalidItWillFail()
        {
            TestExpectedArgumentException<ArgumentNullException>(() => new ProjectExplorerView(null),
                "projectExplorerViewModel");
        }

        private class MockViewModel : IProjectExplorerViewModel
        {
        }
    }
}