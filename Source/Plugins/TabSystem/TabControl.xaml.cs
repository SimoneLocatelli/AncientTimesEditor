using Editor.FileSystem.Dependencies.FileEntities;
using Editor.WindowShell.Dependencies;
using Editor.WindowShell.Dependencies.TabSystem;
using System.Windows;
using TabSystem;

namespace Editor.TabSystem
{
    /// <summary>
    /// Interaction logic for TabSystemWindow.xaml
    /// </summary>
    public partial class TabControl : ITabControl
    {
        private readonly TabSystemWindowViewModel viewModel;

        public UIElement Control
        {
            get { return this; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TabControl"/> class.
        /// </summary>
        /// <param name="tabFactory">The tab factory.</param>
        public TabControl(ITabFactory tabFactory)
        {
            InitializeComponent();

            DataContext = viewModel = new TabSystemWindowViewModel(tabFactory);
        }

        /// <summary>
        /// Create a new Tab and then add it to the Tab Control.
        /// </summary>
        /// <param name="file">The file which contents will be displayed in the Tab</param>
        public void CreateTab(IFile file)
        {
            viewModel.CreateTab(file);
        }

        public void DeleteTab(object sender, RoutedEventArgs e)
        {
            var selectedTab = (TabItem)TabControlElement.SelectedItem;
            viewModel.RemoveTab(selectedTab);
        }
    }
}