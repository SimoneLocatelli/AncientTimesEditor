using Editor.FileSystem.FileInfo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Common;

namespace Editor.FileSystem.Tests.FileInfo
{
    [TestClass]
    public class GenericFileInfoTest : EditorBaseTestClass
    {
        [TestMethod]
        public void WhenInitializedParameterLessItWillContainDefaultValues()
        {
            Test(resolver =>
            {
                const string extension = "Test";
                var anyFileInfo = new GenericFileInfo(extension);

                Assert.AreEqual(string.Empty, anyFileInfo.DefaultFileName);
                Assert.AreEqual(string.Empty, anyFileInfo.Description);
                Assert.AreEqual(extension, anyFileInfo.Extension);
            });
        }
    }
}