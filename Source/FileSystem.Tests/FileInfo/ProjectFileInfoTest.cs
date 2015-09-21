using Editor.FileSystem.FileInfo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Common;

namespace Editor.FileSystem.Tests.FileInfo
{
    [TestClass]
    public class ProjectFileInfoTest : EditorBaseTestClass
    {
        [TestMethod]
        public void WhenInitializedParameterLessItWillContainDefaultValues()
        {
            var instance = new ProjectFileInfo();
            Assert.AreEqual("Project", instance.DefaultFileName);
            Assert.AreEqual("Game Project", instance.Description);
            Assert.AreEqual("atp", instance.Extension);
        }
    }
}