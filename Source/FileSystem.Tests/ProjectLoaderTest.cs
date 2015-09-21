using Editor.FileSystem.FileEntities;
using Editor.Logging.Dependencies.Fakes;
using Editor.Settings.Dependencies.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Common;

namespace Editor.FileSystem.Tests
{
    [TestClass]
    public class ProjectLoaderTest : EditorBaseTestClass
    {
        private readonly Project project = new Project("Test", "C:\\");

        [TestMethod]
        public void WhenLoadsProjectItWillBeUsedAsCurrentProject()
        {
            var projectLoader = SetupClass();

            Assert.IsNull(projectLoader.CurrentProject);

            projectLoader.Load(project);

            Assert.AreEqual(project, projectLoader.CurrentProject);
        }

        [TestMethod]
        public void WhenProjectIsLoadedItWillNotify()
        {
            var projectLoader = SetupClass();

            var hasBeenCalled = false;
            projectLoader.ProjectLoaded += (sender, args) => hasBeenCalled = true;

            projectLoader.Load(project);

            Assert.IsTrue(hasBeenCalled);
        }

        private static ProjectLoader SetupClass()
        {
            return new ProjectLoader(new StubIEditorLogger(),
                new StubIObjectDumper(),
                new StubISettingsSerializer
                {
                    Read = () => new StubIEditorSettings
                    {
                        RecentProjectsGet = () => new StubIRecentProjectsCollection()
                    }
                });
        }
    }
}