using Editor.Badasquall.Dependencies;
using FluentChecker;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Xml.Serialization;

namespace Editor.ItemEditor.Serializers
{
    /// <summary>
    ///     Represents a collection of <see cref="SerializableItemCollection" /> instance.
    /// </summary>
    [Serializable, XmlRoot("Items")]
    public class SerializableItemCollection : List<SerializableItem>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="SerializableItemCollection" /> class.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <exception cref="NotImplementedException"></exception>
        public SerializableItemCollection(IEnumerable<IItem> collection)
            : this(ConvertToSerializableItems(collection))
        {
        }

        private SerializableItemCollection(IEnumerable<SerializableItem> convertToSerializableItems)
            : base(convertToSerializableItems)
        {
        }

        [ExcludeFromCodeCoverage]
        private SerializableItemCollection()
        {
            // Required to enable .Net Xml serialization
        }

        private static IEnumerable<SerializableItem> ConvertToSerializableItems(IEnumerable<IItem> collection)
        {
            Check.IfIsNull(collection).Throw<ArgumentNullException>(() => collection);
            return collection.Select(i => new SerializableItem(i));
        }
    }
}