using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Common;

namespace WpfCommonLibrary.Tests
{
    [TestClass]
    public class CommandTest : EditorBaseTestClass
    {
        [TestMethod]
        public void CheckInitializationWhenInitializedWithAction()
        {
            Action<object> execute = o => { };

            var command = new Command(o => { });

            Assert.IsNull(command.CanExecuteFunc);
        }

        [TestMethod]
        public void WhenCallingExecuteItWillCallExecuteAction()
        {
            var hasBeenCalled = false;

            new Command(o => { hasBeenCalled = true; }).Execute(null);

            Assert.IsTrue(hasBeenCalled);
        }

        [TestMethod]
        public void WhenCanExecuteActionReturnFalseItWillReturnFalseCheckingCanExecute()
        {
            Assert.IsFalse(new Command(o => { }, o => false).CanExecute(null));
        }

        [TestMethod]
        public void WhenCanExecuteIsNullItWillReturnTrue()
        {
            Assert.IsTrue(new Command(o => { }).CanExecute(null));
        }

        public void WhenExecuteActionIsInvalidItWillFail()
        {
            TestExpectedArgumentException<ArgumentNullException>(() => new Command(default(Action)),
                "executeAction");
            TestExpectedArgumentException<ArgumentNullException>(() => new Command(default(Action<object>)),
                "executeAction");
        }
    }
}