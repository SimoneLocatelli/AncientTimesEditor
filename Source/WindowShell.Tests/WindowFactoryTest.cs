using Editor.WindowShell.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Common;

namespace Editor.WindowShell.Tests
{
    [TestClass]
    public class WindowFactoryTest : EditorBaseTestClass
    {
        [TestMethod]
        public void WhenTitleIsInvalidItWillFail()
        {
            using (ShimsContext.Create())
            {
                TestExpectedArgumentException<ArgumentNullException>(() => Setup().Create(null, null), "title");
            }
        }

        [TestMethod]
        public void WhenViewIsInvalidItWillFail()
        {
            using (ShimsContext.Create())
            {
                TestExpectedArgumentException<ArgumentNullException>(() => Setup().Create(string.Empty, null), "view");
            }
        }

        private WindowFactory Setup()
        {
            ShimEmptyWindow.AllInstances.InitializeComponent = window => { };

            return new WindowFactory();
        }
    }
}