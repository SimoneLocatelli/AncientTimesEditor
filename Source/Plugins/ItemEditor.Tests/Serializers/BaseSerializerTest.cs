using Editor.FileSystem.Dependencies.Facades.Fakes;
using Editor.FileSystem.Dependencies.FileEntities;
using Editor.FileSystem.Dependencies.FileEntities.Fakes;
using Editor.FileSystem.Dependencies.FileManagers.Fakes;
using Editor.ItemEditor.Serializers;
using Editor.Logging.Dependencies.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using Tests.Common;

namespace Editor.ItemEditor.Tests.Serializers
{
    [TestClass]
    public class BaseSerializerTest : EditorBaseTestClass
    {
        [TestMethod]
        public void AssertDefaultFileName()
        {
            Assert.AreEqual("Items.xml", BaseSerializerExposer.ItemsSerializedFileNameExposer);
        }

        [TestMethod]
        public void WhenProjectIsNotNullItWillReturnDefaultPath()
        {
            var defaultPath = new BaseSerializerExposer(new StubIProject
            {
                PathGet = () => "C:\\"
            }).GetDefaultLocationExposer();

            Assert.AreEqual(@"C:\Items.xml", defaultPath);
        }

        [TestMethod]
        public void WhenProjectIsNullItWillFail()
        {
            TestExpectedException<InvalidOperationException>(() => new BaseSerializerExposer().GetDefaultLocationExposer(),
                "Operation not allowed. No project has been loaded.");
        }

        private class BaseSerializerExposer : BaseSerializer
        {
            public const string ItemsSerializedFileNameExposer = ItemsSerializedFileName;

            public BaseSerializerExposer(IProject project = null)
                : base(new StubIPathFacade
                {
                    CombineStringString = (path1, path2) => Path.Combine(path1, path2)
                }, new StubIEditorLogger(), new StubIProjectLoader
                {
                    CurrentProjectGet = () => project
                })
            {
            }

            public string GetDefaultLocationExposer()
            {
                return GetDefaultLocation();
            }
        }
    }
}