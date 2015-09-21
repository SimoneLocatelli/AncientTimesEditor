using Editor.FileSystem.Dependencies.FileEntities.Fakes;
using Editor.FileSystem.Dependencies.FileManagers;
using Editor.FileSystem.Dependencies.FileManagers.Fakes;
using Editor.ProjectExplorer.Dependencies;
using Editor.ProjectExplorer.Dependencies.Fakes;
using Editor.ProjectExplorer.Tests.MockData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Tests.Common;

namespace Editor.ProjectExplorer.Tests
{
    [TestClass]
    public class ProjectExplorerViewModelTest : EditorBaseTestClass
    {
        [TestMethod]
        public void AssertItWillAttachToProjectLoad()
        {
            var projectLoaderSpy = new SpyIProjectLoader();

            SetupClass(projectLoader: projectLoaderSpy);

            Assert.AreEqual(1, projectLoaderSpy.AttachedListeners.Count());
        }

        [TestMethod]
        public void WhenDependenciesAreNullItWillFail()
        {
            TestExpectedArgumentException<ArgumentNullException>(
                () => new ProjectExplorerViewModel(null, null, null), "fixedProjectExplorerItems");

            TestExpectedArgumentException<ArgumentNullException>(
                () => new ProjectExplorerViewModel(new List<IProjectExplorerItem>(), null, null), "projectLoader");

            TestExpectedArgumentException<ArgumentNullException>(
                () => new ProjectExplorerViewModel(
                    new List<IProjectExplorerItem>(),
                    new StubIProjectLoader(), null), "projectExplorerItemFactory");
        }

        [TestMethod]
        public void WhenNewProjectIsLoadedItWillBeAddedToTheViewModel()
        {
            var spyIProjectLoader = new SpyIProjectLoader();
            var stubProject = new StubIProject();
            var projectExplorerItemFactory = new StubIProjectExplorerItemFactory
            {
                CreateIFile = value => new ProjectExplorerItem(value, null)
            };

            var viewModel = SetupClass(projectLoader: spyIProjectLoader,
                projectExplorerItemFactory: projectExplorerItemFactory);

            spyIProjectLoader.RaiseProjectLoadedEvent(stubProject);

            Assert.AreEqual(1, viewModel.Items.Count());
        }

        private static ProjectExplorerViewModel SetupClass(
            IEnumerable<IProjectExplorerItem> fixedItems = null,
            IProjectLoader projectLoader = null,
            IProjectExplorerItemFactory projectExplorerItemFactory = null)
        {
            fixedItems = fixedItems ?? new List<IProjectExplorerItem>();
            projectLoader = projectLoader ?? new StubIProjectLoader();
            projectExplorerItemFactory = projectExplorerItemFactory ??
                                         new StubIProjectExplorerItemFactory();

            return new ProjectExplorerViewModel(fixedItems, projectLoader, projectExplorerItemFactory);
        }
    }
}