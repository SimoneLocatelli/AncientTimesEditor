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
using System.IO;
using System.Linq;

namespace Editor.ItemEditor.Serializers
{
    /// <summary>
    ///     Deserializator for the <see cref="IItem" /> entity.
    /// </summary>
    public class ItemDeserializer : BaseSerializer, IItemDeserializer
    {
        private readonly IFileReader fileReader;
        private readonly IObjectDumper objectDumper;
        private readonly IXmlDeserializer xmlDeserializer;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ItemSerializer" /> class.
        /// </summary>
        /// <param name="pathFacade">The path facade.</param>
        /// <param name="objectDumper">The object dumper.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="projectLoader">The project loader.</param>
        /// <param name="xmlDeserializer">The XML deserializer.</param>
        /// <param name="fileReader">The file reader.</param>
        [ImportingConstructor]
        public ItemDeserializer(IPathFacade pathFacade,
            IEditorLogger logger,
            IProjectLoader projectLoader,
            IObjectDumper objectDumper,
            IXmlDeserializer xmlDeserializer,
            IFileReader fileReader)
            : base(pathFacade, logger, projectLoader)
        {
            Check.IfIsNull(objectDumper).Throw<ArgumentNullException>(() => objectDumper);
            Check.IfIsNull(xmlDeserializer).Throw<ArgumentNullException>(() => xmlDeserializer);
            Check.IfIsNull(fileReader).Throw<ArgumentNullException>(() => fileReader);

            this.objectDumper = objectDumper;
            this.xmlDeserializer = xmlDeserializer;
            this.fileReader = fileReader;
        }

        /// <summary>
        ///     Deserializes the items read from the default location.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IItem> Deserialize()
        {
            if (!IsProjectLoaded) return new List<IItem>();

            var filePath = GetDefaultLocation();

            if (!File.Exists(filePath)) return new List<IItem>();

            var fileContents = fileReader.Read(filePath);

            var serializableItems = xmlDeserializer.Deserialize<SerializableItemCollection>(fileContents);

            var items = serializableItems.Select(i => i.ToIItem()).ToList();

            Logger.Log(Resources.ItemEditorLoggerCategory, "Serialized Items: {0}", objectDumper.Dump(items));

            return items;
        }
    }
}