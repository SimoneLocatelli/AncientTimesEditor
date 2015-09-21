#region Usings

using Editor.FileSystem.Dependencies.Events;
using Editor.FileSystem.Dependencies.FileEntities;
using Editor.FileSystem.Dependencies.FileEntities.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Common;

#endregion Usings

namespace Editor.FileSystem.Tests
{
    /// <summary>
    ///     Contains the information for the event raised when a File has been changed
    /// </summary>
    [TestClass]
    public class FileChangedEventArgsTest : EditorBaseTestClass
    {
        [TestMethod]
        public void WhenCurrentFileIsNullWhileThePreviousIsNotItWillFail()
        {
            TestExpectedArgumentException<ArgumentNullException>(
                () => new FileChangedEventArgs(new StubIFile(), default(IFile)), "currentFile");
        }

        [TestMethod]
        public void WhenInitializedItWillStoreFileValues()
        {
            var previousFile = new StubIFile();
            var currentFile = new StubIFile();

            var fileChangedEventArgs = new FileChangedEventArgs(previousFile, currentFile);

            Assert.AreEqual(previousFile, fileChangedEventArgs.PreviousFile);
            Assert.AreEqual(currentFile, fileChangedEventArgs.CurrentFile);
        }
    }
}