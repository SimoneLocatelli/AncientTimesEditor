using Editor.FileSystem.FileInfo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Common;

namespace Editor.FileSystem.Tests.FileInfo
{
    [TestClass]
    public class AnyFileInfoTest : EditorBaseTestClass
    {
        [TestMethod]
        public void WhenInitializedParameterLessItWillContainDefaultValues()
        {
            var anyFileInfo = new AnyFileInfo();

            Assert.AreEqual(string.Empty, anyFileInfo.DefaultFileName);
            Assert.AreEqual(Resources.EntityAnyFileDescription, anyFileInfo.Description);
            Assert.AreEqual("*", anyFileInfo.Extension);
        }
    }
}