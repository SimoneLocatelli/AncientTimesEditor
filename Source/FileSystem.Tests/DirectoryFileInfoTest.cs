namespace Dependencies.Tests.FileSystem
{
    #region Usings

    using global::FileSystem.Dependencies.FileInfo;
    using global::Tests.Common;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    #endregion Usings

    [TestClass]
    public class DirectoryFileInfoTest : EditorBaseTestClass<DirectoryFileInfo>
    {
        [TestMethod]
        public void ShouldHaveDefaultValues()
        {
            Test(resolver =>
            {
                var instance = ResolveClassToTest(resolver);
                Assert.AreEqual("New Folder", instance.DefaultFileName);
                Assert.AreEqual("Project folder", instance.Description);
                Assert.AreEqual(string.Empty, instance.Extension);
            });
        }
    }
}