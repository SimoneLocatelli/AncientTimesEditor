using Editor.FileSystem.Dependencies.FileEntities.Fakes;
using Editor.FileSystem.Dependencies.FileManagers;
using Editor.FileSystem.Dependencies.FileManagers.Fakes;
using Editor.ProjectExplorer.ContextMenus.CommonMenuItems;
using Editor.ProjectExplorer.Dependencies;
using Editor.ProjectExplorer.Dependencies.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Tests.Common;

namespace Editor.ProjectExplorer.Tests
{
    [TestClass]
    public class NewFolderMenuItemTest : EditorBaseTestClass
    {
        [TestMethod]
        public void WhenDependenciesAreInvalidItWillFail()
        {
            TestExpectedArgumentException<ArgumentNullException>(
                () => new NewFolderMenuItem(default(IDirectoryFactory),
                    default(IProjectExplorerItemFactory)), "directoryCreator");

            TestExpectedArgumentException<ArgumentNullException>(
                () => new NewFolderMenuItem(new StubIDirectoryFactory(),
                    default(IProjectExplorerItemFactory)), "projectExplorerItemFactory");
        }

        [TestMethod]
        public void WhenEverythingIsValidItWillAddNewFolder()
        {
            var children = new List<IProjectExplorerItem>();

            var projectExplorerItem = new StubIProjectExplorerItem
            {
                ValueGet = () => new StubIFileContainer(),
                ChildrenGet = () => children
            };
            SetupClass().Command.Execute(projectExplorerItem);

            Assert.AreEqual(1, projectExplorerItem.ChildrenGet().Count);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void WhenFileWrappedIsNotFileContainerItWillFail()
        {
            var projectExplorerItem = new StubIProjectExplorerItem
            {
                ValueGet = () => new StubIFile()
            };

            ExecuteCommand(projectExplorerItem);
        }

        [TestMethod]
        public void WhenInitializedCommandWillHaveValue()
        {
            Assert.IsNotNull(SetupClass().Command);
        }

        [TestMethod]
        public void WhenProjectExplorerItemIsInvalidItWillFail()
        {
            TestExpectedArgumentException<ArgumentException>(() => ExecuteCommand(null), "projectExplorerItem");
        }

        private static void ExecuteCommand(StubIProjectExplorerItem projectExplorerItem)
        {
            SetupClass().Command.Execute(projectExplorerItem);
        }

        private static NewFolderMenuItem SetupClass()
        {
            var directoryFactory = new StubIDirectoryFactory
            {
                CreateWithDefaultNameIFileContainer = container => new StubIDirectory()
            };
            var projectExplorerItemFactory = new StubIProjectExplorerItemFactory
            {
                CreateIFile = file => new StubIProjectExplorerItem()
            };

            return new NewFolderMenuItem(directoryFactory, projectExplorerItemFactory);
        }
    }
}