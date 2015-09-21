using Editor.Logging.Dependencies;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Common;

namespace Editor.Logging.Tests
{
    [TestClass]
    public class LogFormatterTest : EditorBaseTestClass
    {
        [TestMethod]
        public void WhenCategoryIsInvalidWillFail()
        {
            TestExpectedArgumentException<ArgumentNullException>(() => SetupLogFormatter().Format(null, null),
                "category");
        }

        [TestMethod]
        public void WhenInputValuesAreValidTheyWillBeFormatted()
        {
            const string expectedValue = "Category - Message\n";

            var actualValue = SetupLogFormatter().Format("Category", "Message");

            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void WhenMessageIsInvalidWillFail()
        {
            TestExpectedArgumentException<ArgumentNullException>(() => SetupLogFormatter().Format("", null), "message");
        }

        private static ILogFormatter SetupLogFormatter()
        {
            var logFormatter = new LogFormatter();
            return logFormatter;
        }
    }
}