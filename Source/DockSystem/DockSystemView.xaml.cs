using Editor.DockSystem.Dependencies;
using System.ComponentModel.Composition;

namespace Editor.DockSystem
{
    /// <summary>
    ///     Interaction logic for UserControl1.xaml
    /// </summary>
    [Export(typeof(DockSystemView))]
    public partial class DockSystemView : IDockSystemView
    {
        [ImportingConstructor]
        public DockSystemView(IDockSystemViewViewModel dockSystemViewViewModel)
        {
            InitializeComponent();

            DataContext = dockSystemViewViewModel;
        }
    }
}