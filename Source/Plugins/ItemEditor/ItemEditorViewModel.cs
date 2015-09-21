using Editor.Badasquall.Dependencies;
using Editor.ItemEditor.Dependencies;
using Editor.ItemEditor.Dependencies.Serializers;
using Editor.ItemEditor.Entities;
using Editor.ItemEditor.Properties;
using Editor.WpfCommonLibrary.Dependencies;
using FluentChecker;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Windows.Input;
using WpfCommonLibrary;

namespace Editor.ItemEditor
{
    /// <summary>
    ///     The View Model for the <see cref="IItemEditorView" /> control
    /// </summary>
    public class ItemEditorViewModel : BaseViewModel, IItemEditorViewModel
    {
        private readonly IItemDeserializer itemDeserializer;

        private readonly IItemSerializer itemSerializer;

        private ObservableCollection<IItem> items;

        private IItem selectedItem;

        private string imagePath;

        /// <summary>
        ///     Gets the command to execute the operation "Add new Item".
        /// </summary>
        /// <value>
        ///     The add new item command.
        /// </value>
        public ICommand AddNewItemCommand { get; private set; }

        /// <summary>
        ///     Gets or sets the Items stored.
        /// </summary>
        /// <value>
        ///     The items.
        /// </value>
        public IEnumerable<IItem> Items
        {
            get { return items; }
            set
            {
                Check.IfIsNull(value).Throw<ArgumentNullException>(() => Items);
                SetProperty(ref items, new ObservableCollection<IItem>(value));
                SelectFirstItem();
            }
        }

        /// <summary>
        ///     Gets or sets the selected item.
        /// </summary>
        /// <value>
        ///     The selected item.
        /// </value>
        public IItem SelectedItem
        {
            get { return selectedItem; }
            set { SetProperty(ref selectedItem, value); }
        }

        /// <summary>
        /// Gets or sets the image path.
        /// </summary>
        /// <value>
        /// The image path.
        /// </value>
        public string ImagePath
        {
            get { return imagePath; }
            set { SetProperty(ref imagePath, value); }
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ItemEditorViewModel" /> class.
        /// </summary>
        /// <param name="itemSerializer">The item serializator.</param>
        /// <param name="itemDeserializer">The item deserializator.</param>
        [ImportingConstructor]
        public ItemEditorViewModel(IItemSerializer itemSerializer, IItemDeserializer itemDeserializer)
        {
            Check.IfIsNull(itemSerializer).Throw<ArgumentNullException>(() => itemSerializer);
            Check.IfIsNull(itemDeserializer).Throw<ArgumentNullException>(() => itemDeserializer);

            this.itemSerializer = itemSerializer;
            this.itemDeserializer = itemDeserializer;

            AddNewItemCommand = new Command(AddNewItem);

            RefreshItemsList();
        }

        /// <summary>
        ///     Read again the list from the default source and update the displayed list.
        /// </summary>
        public void RefreshItemsList()
        {
            Items = itemDeserializer.Deserialize();
        }

        /// <summary>
        ///     Saves the items currently stored on the default location.
        /// </summary>
        public void SaveItems()
        {
            itemSerializer.Serialize(Items);
        }

        private void AddNewItem()
        {
            items.Add(new Item(Resources.ItemDefaultName));
        }

        private void SelectFirstItem()
        {
            SelectedItem = items.FirstOrDefault();
        }
    }
}