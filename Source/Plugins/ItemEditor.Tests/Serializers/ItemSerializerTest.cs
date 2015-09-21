using Editor.Badasquall.Dependencies;
using Editor.FileSystem.Dependencies.Facades.Fakes;
using Editor.FileSystem.Dependencies.FileEntities.Fakes;
using Editor.FileSystem.Dependencies.FileManagers;
using Editor.FileSystem.Dependencies.FileManagers.Fakes;
using Editor.ItemEditor.Serializers;
using Editor.ItemEditor.Tests.MockData;
using Editor.Logging.Dependencies.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Windows.Documents;
using Tests.Common;

namespace Editor.ItemEditor.Tests.Serializers
{
    [TestClass]
    public class ItemSerializerTest : EditorBaseTestClass
    {
        [TestMethod]
        public void WhenDependenciesAreInvalidItWillFail()
        {
            Action<Func<ItemSerializer>, string> assertAction = (createSerializer, s) => TestExpectedArgumentException<ArgumentNullException>(() => createSerializer(), s);
            assertAction(() => new ItemSerializer(null, null, null, null, null), "pathFacade");
            assertAction(() => new ItemSerializer(new StubIPathFacade(), null, null, null, null), "logger");
            assertAction(() => new ItemSerializer(new StubIPathFacade(), new StubIEditorLogger(), null, null, null), "projectLoader");
            assertAction(() => new ItemSerializer(new StubIPathFacade(), new StubIEditorLogger(), new StubIProjectLoader(), null, null), "xmlSerializer");
            assertAction(() => new ItemSerializer(new StubIPathFacade(), new StubIEditorLogger(), new StubIProjectLoader(), new StubIXmlSerializer(), null), "fileWriter");
        }

        [TestMethod]
        public void WhenProjectIsLoadedWillSerialize()
        {
            var project = new StubIProject { PathGet = () => @"C:\\" };
            var projectLoader = new StubIProjectLoader { CurrentProjectGet = () => project };
            var spyIXmlSerializer = new SpyIXmlSerializer();
            SetupClass(projectLoader: projectLoader, xmlSerializer: spyIXmlSerializer).Serialize(new List<IItem>());

            Assert.IsTrue(spyIXmlSerializer.SerializeHasBeenCalled);
        }

        [TestMethod]
        public void WhenProjectIsNotLoadedWillNotSerialize()
        {
            var spyIXmlSerializer = new SpyIXmlSerializer();
            SetupClass(xmlSerializer: spyIXmlSerializer).Serialize(new List<IItem>());

            Assert.IsFalse(spyIXmlSerializer.SerializeHasBeenCalled);
        }

        [TestMethod]
        public void WhenSerializeInvalidCollectionItWillFail()
        {
            TestExpectedArgumentException<ArgumentNullException>(() => SetupClass().Serialize(null), "items");
        }

        private static ItemSerializer SetupClass(IProjectLoader projectLoader = null, IXmlSerializer xmlSerializer = null)
        {
            projectLoader = projectLoader ?? new StubIProjectLoader();
            xmlSerializer = xmlSerializer ?? new StubIXmlSerializer();

            return new ItemSerializer(new StubIPathFacade(), new StubIEditorLogger(), projectLoader, xmlSerializer, new StubIFileWriter());
        }
    }
}