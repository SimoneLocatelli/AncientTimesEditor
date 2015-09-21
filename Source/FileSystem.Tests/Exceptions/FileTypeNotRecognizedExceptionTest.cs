#region Usings

using Editor.FileSystem.Dependencies.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Common;

#endregion Usings

namespace Editor.FileSystem.Tests.Exceptions
{
    [TestClass]
    public class FileTypeNotRecognizedExceptionTest : EditorBaseTestClass
    {
        [TestMethod]
        public void WhenInitializedItWillContainExceptionMessage()
        {
            var message = new FileTypeNotRecognizedException(GetType()).Message;

            Assert.IsNotNull(message);
        }

        [TestMethod]
        public void WhenPassingInvalidTypeItWillFail()
        {
            TestExpectedArgumentException<ArgumentNullException>(
                () => new FileTypeNotRecognizedException(default(Type)), "fileType");
        }
    }
}