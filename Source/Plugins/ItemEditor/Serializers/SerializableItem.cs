using Editor.Badasquall.Dependencies;
using Editor.ItemEditor.Entities;
using FluentChecker;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;

namespace Editor.ItemEditor.Serializers
{
    /// <summary>
    ///     Wraps an <see cref="IItem" /> to allow the serialization of its contents
    /// </summary>
    [Serializable, XmlRoot("Item")]
    public class SerializableItem
    {
        /// <summary>
        ///     Gets or sets the item identifier.
        /// </summary>
        /// <value>
        ///     The identifier.
        /// </value>
        [XmlAttribute]
        public int Id { get; set; }

        /// <summary>
        ///     Gets or sets the item category.
        /// </summary>
        /// <value>
        ///     The item category.
        /// </value>
        [XmlIgnore]
        public IItemCategory ItemCategory { get; set; }

        /// <summary>
        ///     Gets or sets the item name.
        /// </summary>
        /// <value>
        ///     The name.
        /// </value>
        [XmlAttribute]
        public string Name { get; set; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="SerializableItem" /> class.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public SerializableItem(IItem item)
        {
            Check.IfIsNull(item).Throw<ArgumentNullException>(() => item);

            Id = item.Id;
            Name = item.Name;
            ItemCategory = item.ItemCategory;
        }

        [ExcludeFromCodeCoverage]
        private SerializableItem()
        {
            // The .Net Serializator requires an empty constructor
        }

        /// <summary>
        ///     Converts this instance into an <see cref="IItem" /> object.
        /// </summary>
        /// <returns></returns>
        public IItem ToIItem()
        {
            return new Item(Name)
            {
                Id = Id,
                ItemCategory = ItemCategory
            };
        }
    }
}