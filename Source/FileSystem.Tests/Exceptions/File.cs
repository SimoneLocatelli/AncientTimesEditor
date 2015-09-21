#region Usings

using Editor.FileSystem.Dependencies.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Common;

#endregion Usings

namespace Editor.FileSystem.Tests.Exceptions
{
    [TestClass]
    public class File : EditorBaseTestClass
    {
        [TestMethod]
        public void WhenFullPathIsInvalidItWillFail()
        {
            TestExpectedArgumentException<ArgumentException>(() => new FileNotImportableException(default(string)),
                "fileFullPath");
            TestExpectedArgumentException<ArgumentException>(() => new FileNotImportableException(string.Empty),
                "fileFullPath");
            TestExpectedArgumentException<ArgumentException>(() => new FileNotImportableException("  "), "fileFullPath");
        }

        [TestMethod]
        public void WhenFullPathIsValidItWillInitializeException()
        {
            var exception = new FileNotImportableException("fullPath");

            Assert.IsFalse(string.IsNullOrWhiteSpace(exception.Message));
        }
    }
}