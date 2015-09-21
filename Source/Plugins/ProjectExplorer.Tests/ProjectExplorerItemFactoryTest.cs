using Editor.FileSystem.Dependencies.FileEntities;
using Editor.FileSystem.Dependencies.FileEntities.Fakes;
using Editor.ProjectExplorer.Dependencies;
using Editor.ProjectExplorer.Dependencies.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Common;

namespace Editor.ProjectExplorer.Tests
{
    [TestClass]
    public class ProjectExplorerItemFactoryTest : EditorBaseTestClass
    {
        [TestMethod]
        public void WhenDependenciesAreInvalidItWillFail()
        {
            TestExpectedArgumentException<ArgumentNullException>(() =>
                new ProjectExplorerItemFactory(default(IProjectExplorerContextMenuFactory)),
                "projectExplorerContextMenuFactory");
        }

        [TestMethod]
        public void WhenPassingInvalidFileItWillCreateProjectExplorerItem()
        {
            TestExpectedArgumentException<ArgumentNullException>(() => SetupClass().Create(default(IFile)), "file");
        }

        [TestMethod]
        public void WhenPassingValidFileItWillCreateProjectExplorerItem()
        {
            var file = new StubIFile();
            var projectExplorerItem = SetupClass().Create(file);

            Assert.IsNotNull(projectExplorerItem);
            Assert.AreEqual(file, projectExplorerItem.Value);
        }

        private static ProjectExplorerItemFactory SetupClass()
        {
            return new ProjectExplorerItemFactory(new StubIProjectExplorerContextMenuFactory());
        }
    }
}