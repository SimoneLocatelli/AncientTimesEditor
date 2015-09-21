using Editor.Badasquall.Dependencies;
using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace Editor.ItemEditor.Dependencies.Serializers
{
    /// <summary>
    ///     Deserializator for the <see cref="IItem" /> entity.
    /// </summary>
    [InheritedExport]
    public interface IItemDeserializer
    {
        /// <summary>
        ///     Deserializes the items read from the default location.
        /// </summary>
        /// <returns></returns>
        IEnumerable<IItem> Deserialize();
    }
}