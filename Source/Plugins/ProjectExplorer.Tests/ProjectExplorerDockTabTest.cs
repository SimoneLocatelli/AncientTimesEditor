using Editor.ProjectExplorer.Dependencies.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Common;

namespace Editor.ProjectExplorer.Tests
{
    [TestClass]
    public class ProjectExplorerDockTabTest : EditorBaseTestClass
    {
        [TestMethod]
        public void AssertControl()
        {
            Assert.IsNotNull(SetupClass().Control);
        }

        [TestMethod]
        public void AssertTitle()
        {
            Assert.AreEqual(Resources.ProjectExplorerHeader, SetupClass().Title);
        }

        [TestMethod]
        public void WhenDependenciesAreInvalidItWillFail()
        {
            TestExpectedArgumentException<ArgumentNullException>(() => new ProjectExplorerDockTab(null), "projectExplorerView");
        }

        private static ProjectExplorerDockTab SetupClass()
        {
            return new ProjectExplorerDockTab(new StubIProjectExplorerView());
        }
    }
}