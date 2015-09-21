using Editor.CommonControls.Dependencies;
using System.ComponentModel.Composition;
using System.Windows;

namespace Editor.CommonControls
{
    /// <summary>
    /// Interaction logic for View.xaml
    /// </summary>
    public partial class ImageImporterView : IImageFinderView
    {
        public UIElement Control
        {
            get { return this; }
        }

        public string ImagePath
        {
            get { return (string)GetValue(ImagePathProperty); }
            set { SetValue(ImagePathProperty, value); }
        }

        public readonly static DependencyProperty ImagePathProperty = DependencyProperty.Register(
            "ImagePath",
            typeof(string),
            typeof(ImageImporterView));

        public ImageImporterView()
        {
            InitializeComponent();

            var viewModel = new ImageImporterViewModel();
            viewModel.imagePathChanged += viewModel_imagePathChanged;
            DataContext = viewModel;
        }

        private void viewModel_imagePathChanged(string newPath)
        {
            ImagePath = newPath;
        }
    }
}