using Editor.FileSystem.Dependencies.Facades.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Common;

namespace Editor.FileSystem.Tests
{
    [TestClass]
    public class PathUtilsTest : EditorBaseTestClass
    {
        private const string Extension = "myExtension";
        private const string FileName = "Test";
        private const string FullName = FileName + "." + Extension;

        [TestMethod]
        public void WhenFilePathItWillFailToExtractExtension()
        {
            var pathUtils = Setup();

            TestExpectedArgumentException<ArgumentException>(() => pathUtils.GetExtensionWithoutStartingDot(default(string)), "filePath");
            TestExpectedArgumentException<ArgumentException>(() => pathUtils.GetExtensionWithoutStartingDot(string.Empty), "filePath");
            TestExpectedArgumentException<ArgumentException>(() => pathUtils.GetExtensionWithoutStartingDot("   "), "filePath");
        }

        [TestMethod]
        public void WhenItContainsExtensionItWillReturnIt()
        {
            Assert.AreEqual(Extension, Setup().GetExtensionWithoutStartingDot(FullName));
        }

        [TestMethod]
        public void WhenItDoesntContainExtensionItWillReturnEmpty()
        {
            Assert.AreEqual(string.Empty, Setup().GetExtensionWithoutStartingDot(FileName));
        }

        private static PathUtils Setup()
        {
            return new PathUtils(new StubIPathFacade
            {
                GetFileNameWithoutExtensionString = s => FileName,
                GetExtensionString = s => s == FileName ? string.Empty : Extension
            });
        }
    }
}