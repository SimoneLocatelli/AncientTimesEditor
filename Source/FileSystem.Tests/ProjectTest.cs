namespace Dependencies.Tests.FileSystem
{
    #region Usings

    using Editor.FileSystem.FileEntities;
    using global::Tests.Common;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Linq;

    #endregion Usings

    [TestClass]
    public class ProjectTest : EditorBaseTestClass
    {
        [TestMethod]
        public void CreateInstance()
        {
            Test(resolver =>
            {
                var project = new Project("Test", "C:\\");

                Assert.AreEqual("Test", project.Name);
                Assert.AreEqual("Test.atp", project.FullName);
                Assert.AreEqual("C:\\", project.Path);
                Assert.AreEqual("C:\\Test.atp", project.FullPath);
                Assert.AreEqual("C:\\", project.ChildrenPath);
                Assert.AreEqual(0, project.InnerFiles.Count);
            });
        }

        [TestMethod]
        public void CreateInstanceWithProjectAndFullPath()
        {
            Test(resolver =>
            {
                var project = new Project("Test", "C:\\");
                var childrenProject = new Project("ChildrenTest", "C:\\");
                project.InnerFiles.Add(childrenProject);

                var projectToBeTested = new Project(project, "C:\\Test2.atp");

                Assert.AreEqual("C:\\", projectToBeTested.Path);
                Assert.AreEqual("C:\\Test2.atp", projectToBeTested.FullPath);
                Assert.AreEqual("C:\\", projectToBeTested.ChildrenPath);
                Assert.AreEqual(1, projectToBeTested.InnerFiles.Count);
                Assert.AreEqual("ChildrenTest", projectToBeTested.InnerFiles.First().Name);
            });
        }

        public void CreateInstanceWithInvalidName()
        {
            TestExpectedArgumentException<ArgumentException>(resolver => new Project(default(string), "C:\\"), "name");
            TestExpectedArgumentException<ArgumentException>(resolver => new Project("", "C:\\"), "name");
            TestExpectedArgumentException<ArgumentException>(resolver => new Project("  ", "C:\\"), "name");
        }

        public void CreateInstanceWithInvalidPath()
        {
            TestExpectedArgumentException<ArgumentException>(resolver => new Project("Test", default(string)), "path");
            TestExpectedArgumentException<ArgumentException>(resolver => new Project("Test", ""), "path");
            TestExpectedArgumentException<ArgumentException>(resolver => new Project("Test", " "), "path");
        }

        public void CreateInstanceWithInvalidProject()
        {
            TestExpectedArgumentException<ArgumentException>(resolver => new Project(default(Project), "C:\\Test.atp"),
                "project");
        }
    }
}