using System.ComponentModel.Composition;

namespace MainMenu
{
    /// <summary>
    ///     Interaction logic for MainMenuView.xaml
    /// </summary>
    [Export(typeof(MainMenuView))]
    public partial class MainMenuView
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="MainMenuView" /> class.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        [ImportingConstructor]
        public MainMenuView(MainMenuViewViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}