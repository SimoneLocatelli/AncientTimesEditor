namespace Dependencies.Tests.FileSystem
{
    #region Usings

    using global::FileSystem.Dependencies.FileInfo;
    using global::Tests.Common;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    #endregion Usings

    [TestClass]
    public class ProjectFileInfoTest : EditorBaseTestClass<ProjectFileInfo>
    {
        [TestMethod]
        public void ShouldHaveDefaultValues()
        {
            Test(resolver =>
            {
                var instance = ResolveClassToTest(resolver);
                Assert.AreEqual("Project", instance.DefaultFileName);
                Assert.AreEqual("Game Project", instance.Description);
                Assert.AreEqual("atp", instance.Extension);
            });
        }
    }
}