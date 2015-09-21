using Editor.Badasquall.Dependencies;
using Editor.Badasquall.Dependencies.Fakes;
using Editor.FileSystem.Dependencies.Facades;
using Editor.FileSystem.Dependencies.Facades.Fakes;
using Editor.FileSystem.Dependencies.FileEntities.Fakes;
using Editor.FileSystem.Dependencies.FileManagers;
using Editor.FileSystem.Dependencies.FileManagers.Fakes;
using Editor.ItemEditor.Serializers;
using Editor.Logging.Dependencies;
using Editor.Logging.Dependencies.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Tests.Common;

namespace Editor.ItemEditor.Tests.Serializers
{
    [TestClass]
    public class ItemDeserializerTest : EditorBaseTestClass
    {
        [TestMethod]
        public void WhenDependenciesAreInvalidItWillFail()
        {
            Action<Action, string> assert = TestExpectedArgumentException<ArgumentNullException>;
            var pathFacade = new StubIPathFacade();
            var objectDumper = new StubIObjectDumper();
            var editorLogger = new StubIEditorLogger();
            var projectLoader = new StubIProjectLoader();
            var xmlDeserializer = new StubIXmlDeserializer();

            assert(() => SetupClass(), "pathFacade");
            assert(() => SetupClass(pathFacade), "logger");
            assert(() => SetupClass(pathFacade, editorLogger), "projectLoader");
            assert(() => SetupClass(pathFacade, editorLogger, projectLoader), "objectDumper");
            assert(() => SetupClass(pathFacade, editorLogger, projectLoader, objectDumper), "xmlDeserializer");
            assert(() => SetupClass(pathFacade, editorLogger, projectLoader, objectDumper, xmlDeserializer), "fileReader");
        }

        [TestMethod]
        public void WhenProjectIsLoadedWillReturnItemsCollection()
        {
            var project = new StubIProject();
            var projectLoader = new StubIProjectLoader
            {
                CurrentProjectGet = () => project
            };

            var itemsCollection = new List<IItem> {new StubIItem()};
            var serializableItemCollection = new SerializableItemCollection(itemsCollection);

            var xmlDeserializer = new StubIXmlDeserializer();
            xmlDeserializer.DeserializeOf1String(s => serializableItemCollection);

            var deserializedCollection = SetupClassWithDefaults(projectLoader, xmlDeserializer).Deserialize();

            Assert.AreEqual(itemsCollection.Count, deserializedCollection.Count());
        }

        [TestMethod]
        public void WhenProjectIsNotLoadedWillReturnEmptyList()
        {
            var deserializedCollection = SetupClassWithDefaults().Deserialize();

            Assert.AreEqual(0, deserializedCollection.Count());
        }

        private static ItemDeserializer SetupClass(IPathFacade pathFacade = null,
            IEditorLogger logger = null,
            IProjectLoader projectLoader = null,
            IObjectDumper objectDumper = null,
            IXmlDeserializer xmlDeserializer = null,
            IFileReader fileReader = null)
        {
            return
                new
                    ItemDeserializer(pathFacade, logger, projectLoader, objectDumper, xmlDeserializer, fileReader);
        }

        private static ItemDeserializer SetupClassWithDefaults(IProjectLoader projectLoader = null,
            IXmlDeserializer xmlDeserializer = null)
        {
            projectLoader = projectLoader ?? new StubIProjectLoader();
            xmlDeserializer = xmlDeserializer ?? new StubIXmlDeserializer();

            return SetupClass(new StubIPathFacade(),
                new StubIEditorLogger(),
                projectLoader,
                new StubIObjectDumper(),
                xmlDeserializer,
                new StubIFileReader());
        }
    }
}