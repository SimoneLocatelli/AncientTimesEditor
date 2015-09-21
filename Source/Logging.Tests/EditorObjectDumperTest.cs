#region Usings

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Common;

#endregion Usings

namespace Editor.Logging.Tests
{
    [TestClass]
    public class EditorObjectDumperTest : EditorBaseTestClass
    {
        [TestMethod]
        public void WhenValueIsNotNullItWillWork()
        {
            Assert.IsNotNull(SetupClass().Dump(new object()));
        }

        [TestMethod]
        public void WhenValueIsNullItWillWork()
        {
            Assert.IsNotNull(SetupClass().Dump(null));
        }

        private static EditorObjectDumper SetupClass()
        {
            return new EditorObjectDumper();
        }
    }
}