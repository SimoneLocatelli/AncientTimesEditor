using Editor.WindowShell.Dependencies;
using Editor.WindowShell.ViewModels;
using System.ComponentModel.Composition;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Input;

namespace Editor.WindowShell
{
    /// <summary>
    ///     Interaction logic for StartupWindow.xaml
    /// </summary>
    public partial class StartupWindow : IStartupWindow
    {
        [ExcludeFromCodeCoverage]
        public IStartupWindowViewModel ViewModel
        {
            get { return (IStartupWindowViewModel)DataContext; }
        }

        [ImportingConstructor]
        public StartupWindow(IStartupWindowViewModel startupWindowViewModel)
        {
            InitializeComponent();

            startupWindowViewModel.ParentWindow = this;

            DataContext = startupWindowViewModel;
        }

        private void OnCloseWindowButtonClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}