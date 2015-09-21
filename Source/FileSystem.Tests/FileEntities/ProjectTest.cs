using Editor.FileSystem.Dependencies.FileEntities;
using Editor.FileSystem.Dependencies.FileEntities.Fakes;
using Editor.FileSystem.FileEntities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Tests.Common;

namespace Editor.FileSystem.Tests.FileEntities
{
    [TestClass]
    public class ProjectTest : EditorBaseTestClass
    {
        private const int DefaultInnerFilesCount = 0;
        private const string ProjectFullPath = ProjectLocation + ProjectNameWithExtension;
        private const string ProjectLocation = "C:\\";
        private const string ProjectName = "TestProject";
        private const string ProjectNameWithExtension = ProjectName + ".atp";

        [TestMethod]
        public void WhenInitializedWithFullNameItWillBeInitalized()
        {
            TestProjectProperties(new Project(ProjectFullPath));
        }

        [TestMethod]
        public void WhenInitializedWithInvalidNameItWillFail()
        {
            const string parameterName = "name";

            TestExpectedArgumentException<ArgumentException>(() => new Project(default(string), ProjectLocation),
                parameterName);
            TestExpectedArgumentException<ArgumentException>(() => new Project("", ProjectLocation), parameterName);
            TestExpectedArgumentException<ArgumentException>(() => new Project("  ", ProjectLocation),
                parameterName);
        }

        [TestMethod]
        public void WhenInitializedWithInvalidPathItWillFail()
        {
            const string parameterName = "path";

            TestExpectedArgumentException<ArgumentException>(() => new Project(ProjectName, default(string)),
                parameterName);
            TestExpectedArgumentException<ArgumentException>(() => new Project(ProjectName, ""), parameterName);
            TestExpectedArgumentException<ArgumentException>(() => new Project(ProjectName, " "), parameterName);
        }

        [TestMethod]
        public void WhenInitializedWithInvalidProjectItWillFail()
        {
            TestExpectedArgumentException<ArgumentException>(() => new Project(default(Project), ProjectFullPath),
                "project");
        }

        [TestMethod]
        public void WhenInitializedWithItWillBeInitalized()
        {
            var innerFiles = new List<IFile> { new StubIFile() };

            var project = new Project(new StubIProject
            {
                InnerFilesGet = () => innerFiles
            }, ProjectFullPath);

            TestProjectProperties(project, 1);
            Assert.IsTrue(project.InnerFiles.SequenceEqual(innerFiles));
        }

        [TestMethod]
        public void WhenInitializedWithNameAndPathShouldCorrectlyConfigured()
        {
            TestProjectProperties(new Project(ProjectName, ProjectLocation));
        }

        [TestMethod]
        public void WhenInnerFileIsAddedItWillBeContainedInside()
        {
            var project = new Project(ProjectFullPath);
            var childrenProject = new Project("C:\\ChildrenTest");
            project.InnerFiles.Add(childrenProject);

            Assert.AreEqual("ChildrenTest", project.InnerFiles.First().Name);
        }

        private static void TestProjectProperties(Project project, int innerFilesCount = DefaultInnerFilesCount)
        {
            Assert.AreEqual(ProjectName, project.Name);
            Assert.AreEqual(ProjectNameWithExtension, project.FullName);
            Assert.AreEqual(ProjectLocation, project.Path);
            Assert.AreEqual(ProjectFullPath, project.FullPath);
            Assert.AreEqual("C:\\", project.ChildrenPath);
            Assert.AreEqual(innerFilesCount, project.InnerFiles.Count);
        }
    }
}