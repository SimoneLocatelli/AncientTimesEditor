using Editor.WpfCommonLibrary.Dependencies;
using System.Windows;
using System.Windows.Media;

namespace Editor.DockSystem.Dependencies
{
    public abstract class BaseDockTab : BaseViewModel, IDockTab
    {
        private UIElement control;
        private ImageSource icon;
        private bool isActive;
        private bool isSelected;
        private bool isVisible;
        private string title;

        public string ContentId
        {
            get { return GetType().ToString(); }
        }

        public UIElement Control
        {
            get { return control; }
            protected set { SetProperty(ref control, value); }
        }

        public virtual ImageSource Icon
        {
            get { return icon; }
            set { SetProperty(ref icon, value); }
        }

        public bool IsActive
        {
            get { return isActive; }
            set { SetProperty(ref isActive, value); }
        }

        public bool IsSelected
        {
            get { return isSelected; }
            set { SetProperty(ref isSelected, value); }
        }

        public bool IsVisible
        {
            get { return isVisible; }
            set { SetProperty(ref isVisible, value); }
        }

        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        protected BaseDockTab()
        {
            IsVisible = true;
        }
    }
}