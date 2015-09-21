using Editor.Badasquall.Dependencies;
using Editor.WpfCommonLibrary.Dependencies;
using System.Diagnostics.CodeAnalysis;

namespace Editor.ItemEditor.Entities
{
    /// <summary>
    ///     An Item category identifies a set of items
    ///     that share a common aspect, like the effect type or the context
    ///     during which can be used.
    /// </summary>
    public class ItemCategory : BaseViewModel, IItemCategory
    {
        private int id;
        private string name;

        /// <summary>
        ///     Gets the category identifier.
        /// </summary>
        /// <value>
        ///     The identifier.
        /// </value>
        [ExcludeFromCodeCoverage]
        public int Id
        {
            get { return id; }
            set { SetProperty(ref id, value); }
        }

        /// <summary>
        ///     Gets the category name.
        /// </summary>
        /// <value>
        ///     The name.
        /// </value>
        [ExcludeFromCodeCoverage]
        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }
    }
}