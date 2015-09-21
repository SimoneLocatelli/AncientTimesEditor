using Editor.Badasquall.Dependencies;
using Editor.FileSystem.Dependencies.Facades;
using Editor.FileSystem.Dependencies.FileManagers;
using Editor.ItemEditor.Dependencies.Serializers;
using Editor.ItemEditor.Properties;
using Editor.Logging.Dependencies;
using FluentChecker;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace Editor.ItemEditor.Serializers
{
    /// <summary>
    ///     Serializator for the <see cref="IItem" /> entity
    /// </summary>
    public class ItemSerializer : BaseSerializer, IItemSerializer
    {
        private readonly IFileWriter fileWriter;
        private readonly IXmlSerializer xmlSerializer;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ItemSerializer" /> class.
        /// </summary>
        /// <param name="pathFacade">The path facade.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="projectLoader">The project loader.</param>
        /// <param name="xmlSerializer">The XML serializator.</param>
        /// <param name="fileWriter">The file writer.</param>
        [ImportingConstructor]
        public ItemSerializer(IPathFacade pathFacade, IEditorLogger logger, IProjectLoader projectLoader,
            IXmlSerializer xmlSerializer,
            IFileWriter fileWriter)
            : base(pathFacade, logger, projectLoader)
        {
            Check.IfIsNull(xmlSerializer).Throw<ArgumentNullException>(() => xmlSerializer);
            Check.IfIsNull(fileWriter).Throw<ArgumentNullException>(() => fileWriter);

            this.xmlSerializer = xmlSerializer;
            this.fileWriter = fileWriter;
        }

        /// <summary>
        ///     Serializes the specified item in the default location.
        /// </summary>
        /// <param name="items">The items to serialize.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void Serialize(IEnumerable<IItem> items)
        {
            Check.IfIsNull(items).Throw<ArgumentNullException>(() => items);

            if (!IsProjectLoaded) return;

            var serializableItem = new SerializableItemCollection(items);

            var serializableItemToString = xmlSerializer.Serialize(serializableItem);

            Logger.Log(Resources.ItemEditorLoggerCategory, "Serialized Items: {0}", serializableItemToString);

            fileWriter.Write(serializableItemToString, GetDefaultLocation());
        }
    }
}