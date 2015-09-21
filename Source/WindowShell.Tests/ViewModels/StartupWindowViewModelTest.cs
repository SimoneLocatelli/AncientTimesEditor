using Editor.FileSystem.Dependencies.FileEntities;
using Editor.FileSystem.Dependencies.FileManagers;
using Editor.FileSystem.Dependencies.FileManagers.Fakes;
using Editor.Settings.Dependencies;
using Editor.Settings.Dependencies.Fakes;
using Editor.WindowShell.Tests.MockData;
using Editor.WindowShell.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using Tests.Common;

namespace Editor.WindowShell.Tests.ViewModels
{
    [TestClass]
    public class StartupWindowViewModelTest : EditorBaseTestClass
    {
        private readonly IRecentProjectsCollection recentProjects = new MockRecentProjectsCollection
        {
            new StubIRecentProject(),
            new StubIRecentProject(),
            new StubIRecentProject(),
        };

        public StartupWindowViewModel Setup(ISettingsSerializer settingsSerializer = null, IProjectLoader projectLoader = null, IFileOpener<IProject> fileOpener = null)
        {
            projectLoader = projectLoader ?? new StubIProjectLoader();
            fileOpener = fileOpener ?? new StubIFileOpener<IProject>();

            settingsSerializer = settingsSerializer ?? new StubISettingsSerializer
            {
                Read = () => new StubIEditorSettings
                {
                    RecentProjectsGet = () => recentProjects
                }
            };

            return new StartupWindowViewModel(settingsSerializer, projectLoader, fileOpener);
            ;
        }

        [TestMethod]
        public void WhenDependenciesAreInvalidItWillFail()
        {
            TestExpectedArgumentException<ArgumentNullException>(() => new StartupWindowViewModel(null, null, null), "settingsSerializer");
            TestExpectedArgumentException<ArgumentNullException>(() => new StartupWindowViewModel(new StubISettingsSerializer(), null, null), "projectLoader");
            TestExpectedArgumentException<ArgumentNullException>(() => new StartupWindowViewModel(new StubISettingsSerializer(), new StubIProjectLoader(), null), "projectOpener");
        }

        [TestMethod]
        public void WhenInitializedWillReadRecentProjectsList()
        {
            var viewModel = Setup();

            var result = viewModel.RecentProjects;

            Assert.IsTrue(result.SequenceEqual(recentProjects));
        }

        [TestMethod]
        public void WhenSelectedProjectIsNullWindowsWillBeStillVisible()
        {
            var spyWindow = new SpyWindow();
            var viewModel = Setup();
            viewModel.SelectedProject = null;
            viewModel.ParentWindow = spyWindow;
            viewModel.OpenSelectedProject();

            Assert.IsFalse(spyWindow.HasClosedBeenCalled);
        }

        [TestMethod]
        public void WhenSelectedProjectIsValidItWillBeLoaded()
        {
            var spyWindow = new SpyWindow();
            var spyProjectLoader = new SpyProjectLoader();
            var viewModel = Setup(projectLoader: spyProjectLoader);
            viewModel.ParentWindow = spyWindow;

            // After the value has been set we expect it opens the project
            viewModel.SelectedProject = new StubIRecentProject();

            Assert.IsTrue(spyWindow.HasClosedBeenCalled);
            Assert.IsTrue(spyProjectLoader.HasLoadBeenCalled);
        }
    }
}