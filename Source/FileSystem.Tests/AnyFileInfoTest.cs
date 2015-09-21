namespace Editor.FileSystem.Tests
{
    #region Usings

    using global::FileSystem.Dependencies.FileInfo;
    using global::Tests.Common;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    #endregion Usings

    [TestClass]
    public class AnyFileInfoTest : EditorBaseTestClass
    {
        [TestMethod]
        public void ShouldHaveDefaultValues()
        {
            Test(resolver =>
            {
                var anyFileInfo = new AnyFileInfo();

                Assert.AreEqual(string.Empty, anyFileInfo.DefaultFileName);
                Assert.AreEqual(Resources.EntityAnyFileDescription, anyFileInfo.Description);
                Assert.AreEqual("*", anyFileInfo.Extension);
            });
        }
    }
}