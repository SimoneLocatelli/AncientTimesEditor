using Editor.FileSystem.Dependencies.FileEntities;
using Editor.WindowShell.Dependencies.TabSystem;
using Editor.WpfCommonLibrary.Dependencies;
using System.Collections.ObjectModel;

namespace Editor.TabSystem
{
    public class TabSystemWindowViewModel : BaseViewModel
    {
        private readonly ITabFactory tabFactory;
        private readonly ObservableCollection<ITabItem> tabs = new ObservableCollection<ITabItem>();

        public ObservableCollection<ITabItem> Tabs
        {
            get { return tabs; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TabSystemWindowViewModel"/> class.
        /// </summary>
        /// <param name="tabFactory">The tab factory.</param>
        public TabSystemWindowViewModel(ITabFactory tabFactory)
        {
            this.tabFactory = tabFactory;
        }

        /// <summary>
        /// Create a new Tab and then add it to the Tab Control.
        /// </summary>
        /// <param name="file">The file which contents will be displayed in the Tab</param>
        public void CreateTab(IFile file)
        {
            Tabs.Add(tabFactory.Create(file));
        }

        /// <summary>
        /// Removes the tab from the current collection.
        /// </summary>
        /// <param name="tab">The tab.</param>
        public void RemoveTab(ITabItem tab)
        {
            Tabs.Remove(tab);
        }
    }
}