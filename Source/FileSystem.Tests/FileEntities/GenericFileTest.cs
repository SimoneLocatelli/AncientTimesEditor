using Editor.FileSystem.FileEntities;
using Editor.FileSystem.FileInfo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Common;

namespace Editor.FileSystem.Tests.FileEntities
{
    [TestClass]
    public class GenericFileTest : EditorBaseTestClass
    {
        private const string FileFullPath = FilePath + @"\" + FullFileName;
        private const string FileName = @"test";
        private const string FilePath = @"C:\Test";
        private const string FullFileName = FileName + @".fake";

        public void WhenFileFullPathIsInvalidItWillFail()
        {
            const string parameterName = "fullName";

            TestExpectedArgumentException<ArgumentException>(resolver => new GenericFile(default(string)), parameterName);
            TestExpectedArgumentException<ArgumentException>(resolver => new GenericFile(string.Empty), parameterName);
            TestExpectedArgumentException<ArgumentException>(resolver => new GenericFile(" "), parameterName);
        }

        [TestMethod]
        public void WhenInitializedWithFilePathItWillBeConfigured()
        {
            Test(resolver => AssertGenericFileDefaultProperties(new GenericFile(FileFullPath)));
        }

        private static void AssertGenericFileDefaultProperties(GenericFile file)
        {
            Assert.IsInstanceOfType(file.FileInfo, typeof(GenericFileInfo));
            Assert.IsNotNull(file.FileInfo);
            Assert.AreEqual(FileName, file.Name);
            Assert.AreEqual(FullFileName, file.FullName);
            Assert.AreEqual(FilePath, file.Path);
            Assert.AreEqual(FileFullPath, file.FullPath);
        }
    }
}