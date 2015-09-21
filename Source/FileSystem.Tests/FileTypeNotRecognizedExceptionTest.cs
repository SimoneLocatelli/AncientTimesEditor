using Editor.FileSystem.Dependencies.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Common;

namespace Editor.FileSystem.Tests
{
    [TestClass]
    public class FileTypeNotRecognizedExceptionTest : EditorBaseTestClass
    {
        [TestMethod]
        public void WhenTypeIsInvalidItWillFail()
        {
            TestExpectedArgumentException<ArgumentNullException>(
                () => new FileTypeNotRecognizedException(default(Type)), "fileType");
        }

        [TestMethod]
        public void WhenTypeIsValidItWillInitializeMessage()
        {
            var exception = new FileTypeNotRecognizedException(typeof(MockObject));
            Assert.AreEqual("The file type [Editor.FileSystem.Tests.MockObject] has not been recognized",
                exception.Message);
        }
    }

    internal class MockObject
    {
    }
}