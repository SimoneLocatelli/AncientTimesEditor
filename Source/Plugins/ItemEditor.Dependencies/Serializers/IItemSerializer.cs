using Editor.Badasquall.Dependencies;
using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace Editor.ItemEditor.Dependencies.Serializers
{
    /// <summary>
    ///     Serializator for the <see cref="IItem" /> entity
    /// </summary>
    [InheritedExport]
    public interface IItemSerializer
    {
        /// <summary>
        ///     Serializes the specified item in the default location.
        /// </summary>
        /// <param name="items">The item.</param>
        void Serialize(IEnumerable<IItem> items);
    }
}