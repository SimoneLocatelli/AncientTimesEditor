namespace Editor.FileSystem.Tests
{
    #region Usings

    using global::FileSystem.Dependencies.FileInfo;
    using global::Tests.Common;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    #endregion Usings

    [TestClass]
    public class GenericFileInfoTest : EditorBaseTestClass
    {
        [TestMethod]
        public void CreateInstance()
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