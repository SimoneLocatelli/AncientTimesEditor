using System.ComponentModel.Composition;

namespace Editor.PluginsTester
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    [Export]
    public partial class PluginsTesterMainWindow
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="PluginsTesterMainWindow" /> class.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        [ImportingConstructor]
        public PluginsTesterMainWindow(PluginsTesterMainWindowViewModel viewModel)
        {
            InitializeComponent();

            DataContext = viewModel;
        }
    }
}