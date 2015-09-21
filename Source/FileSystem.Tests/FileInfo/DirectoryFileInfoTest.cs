using Editor.FileSystem.FileInfo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Common;

namespace Editor.FileSystem.Tests.FileInfo
{
    [TestClass]
    public class DirectoryFileInfoTest : EditorBaseTestClass
    {
        [TestMethod]
        public void WhenInitializedParameterLessItWillContainDefaultValues()
        {
            var instance = new DirectoryFileInfo();
            Assert.AreEqual("New Folder", instance.DefaultFileName);
            Assert.AreEqual("Project folder", instance.Description);
            Assert.AreEqual(string.Empty, instance.Extension);
        }
    }
}