using Editor.WindowShell.Dependencies;
using Editor.WindowShell.Dialogs;
using Editor.WpfCommonLibrary.Dependencies;
using FluentChecker;
using System;
using System.ComponentModel.Composition;
using System.Windows.Input;
using WpfCommonLibrary;

namespace Editor.CommonControls
{
    public class ImageImporterViewModel : BaseViewModel, IImageImporterViewModel
    {
        private ICommand browseImage;
        private string imagePath;

        public delegate void imagePathChangedHandler(string newPath);

        public event imagePathChangedHandler imagePathChanged;

        private OpenFileDialogCreator openFileDialogCreator;

        public ICommand BrowseImage
        {
            get { return browseImage; }
            set
            {
                Check.IfIsNull(value).Throw<ArgumentNullException>(() => BrowseImage);
                SetProperty(ref browseImage, value);
            }
        }

        public string ImagePath
        {
            get { return imagePath; }
            set
            {
                Check.IfIsNullOrWhiteSpace(value).Throw<ArgumentNullException>(() => ImagePath);
                SetProperty(ref imagePath, value);
                imagePathChanged(imagePath);
            }
        }

        private void BrowseImageMethod(OpenFileDialogCreator openFileCreator)
        {
            var dialog = openFileCreator.Open("The image to load", "png");
            dialog.ShowDialog();
            if (!Check.IfIsNullOrWhiteSpace(dialog.FileName))
                ImagePath = dialog.FileName;
        }

        public ImageImporterViewModel()
        {
            openFileDialogCreator = new OpenFileDialogCreator();
            BrowseImage = new Command(() => BrowseImageMethod(openFileDialogCreator));
        }
    }
}