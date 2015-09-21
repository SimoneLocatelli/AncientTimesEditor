#region Usings

using Editor.FileSystem.Dependencies.Events;
using Editor.FileSystem.Dependencies.FileEntities;
using Editor.FileSystem.Dependencies.FileEntities.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Common;

#endregion Usings

namespace Editor.FileSystem.Tests.Events
{
    [TestClass]
    public class ProjectLoadedEventArgsTest : EditorBaseTestClass
    {
        [TestMethod]
        public void WhenProjectIsInvalidItWillFail()
        {
            TestExpectedArgumentException<ArgumentNullException>(() => new ProjectLoadedEventArgs(default(IProject)),
                "project");
        }

        [TestMethod]
        public void WhenProjectIsValidItWillBeStored()
        {
            var project = new StubIProject();
            var actualProject = new ProjectLoadedEventArgs(project).Project;

            Assert.AreEqual(project, actualProject);
        }
    }
}