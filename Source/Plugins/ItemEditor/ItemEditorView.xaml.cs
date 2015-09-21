using Editor.CommonControls.Dependencies;
using Editor.ItemEditor.Dependencies;
using FluentChecker;
using System;
using System.ComponentModel.Composition;
using System.Diagnostics.CodeAnalysis;
using System.Windows;

namespace Editor.ItemEditor
{
    /// <summary>
    ///     Interaction logic for ItemEditorView.xaml
    /// </summary>
    public partial class ItemEditorView : IItemEditorView
    {
        /// <summary>
        ///     Gets or sets the Item Editor User Control.
        /// </summary>
        /// <value>
        ///     The control.
        /// </value>
        public UIElement Control
        {
            get { return this; }
        }

        [ExcludeFromCodeCoverage]
        private IItemEditorViewModel ViewModel
        {
            get { return (IItemEditorViewModel)DataContext; }
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ItemEditorView" /> class.
        /// </summary>
        [ImportingConstructor]
        public ItemEditorView(IItemEditorViewModel itemEditorViewModel)
        {
            InitializeComponent();

            //Check.IfIsNull(itemEditorViewModel).Throw<ArgumentNullException>(() => itemEditorViewModel);
            //Check.IfIsNull(imageImporterView).Throw<ArgumentNullException>(() => imageImporterView);
            //Check.IfIsNull(imageImporterView.Control).Throw<ArgumentNullException>(() => imageImporterView.Control);
            //Detail.Content = imageImporterView.Control;

            DataContext = itemEditorViewModel;
        }

        /// <summary>
        ///     Requests to load and update the Items collection.
        /// </summary>
        public void RefreshItems()
        {
            ViewModel.RefreshItemsList();
        }
    }
}