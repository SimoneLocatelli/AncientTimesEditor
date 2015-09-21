#region Usings

using Editor.Logging.Dependencies.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;
using Tests.Common;

#endregion Usings

namespace Editor.Logging.Tests
{
    [TestClass]
    public class MemoryLoggerTest : EditorBaseTestClass
    {
        private const string Category = "LogCategory";
        private const string Message = "LogMessage";

        [TestMethod]
        public void AssertIsNotifiedWhenNewMessageIsLogged()
        {
            var logger = SetupMemoryLogger();
            var hasBeenCalled = false;

            logger.MessageLogged += (sender, args) => hasBeenCalled = true;

            logger.Log(Category, Message);

            Assert.IsTrue(hasBeenCalled);
        }

        [TestMethod]
        public void LogWithParams()
        {
            const string messageWithPlaceHolders = "{0}{1}";
            const string placeholder1 = "placeholder1";
            const string placeholder2 = "placeholder2";
            const string expectedResult = Category + " - " + placeholder1 + placeholder2 + "\n";

            var memoryLogger = SetupMemoryLogger();
            memoryLogger.Log(Category, messageWithPlaceHolders, placeholder1, placeholder2);
            Assert.AreEqual(expectedResult, memoryLogger.RetrieveLog());
        }

        public MemoryLogger SetupMemoryLogger()
        {
            return new MemoryLogger(new StubILogFormatter
            {
                FormatStringString = (category, message) =>
                    string.Format(CultureInfo.CurrentCulture, "{0} - {1}\n", category, message)
            });
        }

        [TestMethod]
        public void WhenLogFormatterIsInvalidInitializationWillFail()
        {
            TestExpectedArgumentException<ArgumentNullException>(() => new MemoryLogger(null), "logFormatter");
        }

        [TestMethod]
        public void WhenLoggedMessageItWillBeAddedToCurrentLog()
        {
            const string expectedLog = Category + " - " + Message + "\n";

            var logger = SetupMemoryLogger();

            logger.Log(Category, Message);

            Assert.AreEqual(expectedLog, logger.RetrieveLog());
        }

        [TestMethod]
        public void WhenLoggedTwoMessagesTheyWillBeAppended()
        {
            var expectedLog = Category + " - " + Message + "\n";
            expectedLog = expectedLog + expectedLog;

            var logger = SetupMemoryLogger();

            logger.Log(Category, Message);
            logger.Log(Category, Message);

            Assert.AreEqual(expectedLog, logger.RetrieveLog());
        }

        [TestMethod]
        public void WhenLoggerCreatedLogWillBeEmpty()
        {
            Assert.AreEqual(string.Empty, SetupMemoryLogger().RetrieveLog());
        }

        [TestMethod]
        public void WhenLoggingInvalidCategoryItWillFail()
        {
            TestExpectedArgumentException<ArgumentException>(() => SetupMemoryLogger().Log(null, null), "category");
            TestExpectedArgumentException<ArgumentException>(() => SetupMemoryLogger().Log(string.Empty, null),
                "category");
        }

        [TestMethod]
        public void WhenLoggingInvalidMessageItWillFail()
        {
            TestExpectedArgumentException<ArgumentException>(() => SetupMemoryLogger().Log("Category", null),
                "message");
        }
    }
}