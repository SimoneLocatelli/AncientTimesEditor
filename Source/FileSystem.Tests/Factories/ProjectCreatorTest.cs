using Editor.FileSystem.Creators;
using Editor.FileSystem.Dependencies.FileEntities;
using Editor.FileSystem.Dependencies.FileEntities.Fakes;
using Editor.FileSystem.Dependencies.FileManagers;
using Editor.FileSystem.Dependencies.FileManagers.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Common;

namespace Editor.FileSystem.Tests.Factories
{
    [TestClass]
    public class ProjectCreatorTest : EditorBaseTestClass
    {
        public ProjectFactory BuildProjectCreator(IProjectSerializer projectSerializer = null,
            IProjectLoader projectLoader = null)
        {
            projectSerializer = projectSerializer ?? new StubIProjectSerializer();
            projectLoader = projectLoader ?? new StubIProjectLoader();

            return new ProjectFactory(projectSerializer, projectLoader);
        }

        [TestMethod]
        public void WhenCreateFileItWillReturnCreatedFileInfo()
        {
            var inputFile = new StubIProject();
            var fileCreated = BuildProjectCreator().Create(inputFile);

            Assert.AreEqual(fileCreated, inputFile);
        }

        [TestMethod]
        public void WhenCreateProjectItWillLoadedIt()
        {
            var projectLoadHasBeenCalled = false;
            var projectLoader = new StubIProjectLoader
            {
                LoadIProject = project => projectLoadHasBeenCalled = true
            };

            BuildProjectCreator(projectLoader: projectLoader).Create(new StubIProject());

            Assert.IsTrue(projectLoadHasBeenCalled);
        }

        public void WhenDepenciesAreInvalidItWillFailToInitialize()
        {
            TestExpectedArgumentException<ArgumentNullException>(
                () => new ProjectFactory(default(IProjectSerializer), default(IProjectLoader)),
                "projectSerializer");

            TestExpectedArgumentException<ArgumentNullException>(
                () => new ProjectFactory(new StubIProjectSerializer(), default(IProjectLoader)),
                "projectLoader");
        }

        [TestMethod]
        public void WhenFileIsInvalidItWillFailToCreateIt()
        {
            TestExpectedArgumentException<ArgumentNullException>(() => BuildProjectCreator().Create(default(IProject)),
                "file");
        }

        [TestMethod]
        public void WhenFullNameIsInvalidItWillFailToCreate()
        {
            TestExpectedArgumentException<ArgumentException>(() => BuildProjectCreator().Create(default(string)),
                "fullName");
            TestExpectedArgumentException<ArgumentException>(() => BuildProjectCreator().Create(string.Empty),
                "fullName");
            TestExpectedArgumentException<ArgumentException>(() => BuildProjectCreator().Create("   "), "fullName");
        }

        [TestMethod]
        public void WhenFullNameIsValidItWillCreateFile()
        {
            const string name = "Test";
            const string path = "C:\\";
            const string fullName = path + name;
            var fileCreated = BuildProjectCreator().Create(fullName);

            Assert.IsNotNull(fileCreated);
            Assert.AreEqual(name, fileCreated.Name);
            Assert.AreEqual(path, fileCreated.Path);
        }
    }
}