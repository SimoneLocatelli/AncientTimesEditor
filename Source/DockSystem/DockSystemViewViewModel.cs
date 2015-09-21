using Editor.DockSystem.Dependencies;
using Editor.WpfCommonLibrary.Dependencies;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;

namespace Editor.DockSystem
{
    public class DockSystemViewViewModel : BaseViewModel, IDockSystemViewViewModel
    {
        private object activeDocument;
        private ObservableCollection<DocumentTab> documents = new ObservableCollection<DocumentTab>();
        private ObservableCollection<ToolTab> tools = new ObservableCollection<ToolTab>();

        public object ActiveDocument
        {
            get { return activeDocument; }
            set { SetProperty(ref activeDocument, value); }
        }

        public ObservableCollection<DocumentTab> Documents
        {
            get { return documents; }
            set { SetProperty(ref documents, value); }
        }

        public ObservableCollection<ToolTab> Tools
        {
            get { return tools; }
            set { SetProperty(ref tools, value); }
        }

        [ImportingConstructor]
        public DockSystemViewViewModel(
            [ImportMany(ImportsConstants.DockSystemTools)] IEnumerable<IDockTab> toolsImported)
        {
            foreach (var tool in toolsImported)
            {
                tools.Add(new ToolTab(tool));
            }
        }
    }
}