namespace Editor.FileSystem.Tests
{
    #region Usings

    using global::FileSystem.Dependencies.FileEntities;
    using global::FileSystem.Dependencies.FileInfo;
    using global::Tests.Common;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;

    #endregion Usings

    [TestClass]
    public class GenericFileTest : EditorBaseTestClass
    {
        [TestMethod]
        public void CreateInstance()
        {
            Test(resolver =>
            {
                const string filePath = @"C:\Test\test.fake";
                var anyFileInfo = new GenericFile(filePath);

                Assert.IsInstanceOfType(anyFileInfo.FileInfo, typeof (GenericFileInfo));
                Assert.IsNotNull(anyFileInfo.FileInfo);
                Assert.AreEqual("test", anyFileInfo.Name);
                Assert.AreEqual("test.fake", anyFileInfo.FullName);
                Assert.AreEqual(@"C:\Test", anyFileInfo.Path);
                Assert.AreEqual(filePath, anyFileInfo.FullPath);
            });
        }

        public void CreateInstanceWithInvalidPath()
        {
            TestExpectedArgumentException<ArgumentException>(
                resolver => { var anyFileInfo = new GenericFile(default(string)); }, "fullName");

            TestExpectedArgumentException<ArgumentException>(
                resolver => { var anyFileInfo = new GenericFile(string.Empty); }, "fullName");

            TestExpectedArgumentException<ArgumentException>(resolver => { var anyFileInfo = new GenericFile("  "); },
                "fullName");
        }
    }
}