using Editor.PluginsTester.Dependencies;
using Editor.WpfCommonLibrary.Dependencies;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Windows;

namespace Editor.PluginsTester
{
    /// <summary>
    ///     ViewModel for the PluginTester MainWindow
    /// </summary>
    [Export]
    public class PluginsTesterMainWindowViewModel : BaseViewModel
    {
        private ObservableCollection<IPluginTestable> plugins;
        private IPluginTestable selectedPlugin;

        /// <summary>
        ///     Gets or sets the loaded plugins displayed in the Window.
        /// </summary>
        /// <value>
        ///     The loaded plugins.
        /// </value>
        public ObservableCollection<IPluginTestable> Plugins
        {
            get
            {
                return plugins;
            }
            private set
            {
                SetProperty(ref plugins, value);
                SelectedPlugin = Plugins.FirstOrDefault();
            }
        }

        /// <summary>
        ///     Gets or sets the currently selected plugin.
        /// </summary>
        /// <value>
        ///     The selected plugin.
        /// </value>
        public IPluginTestable SelectedPlugin
        {
            get
            {
                return selectedPlugin;
            }
            set
            {
                SetProperty(ref selectedPlugin, value);
                Notify(() => SelectedPluginContent);
            }
        }

        /// <summary>
        ///     Gets the content of the currently selected plugin.
        /// </summary>
        /// <value>
        ///     The content of the selected plugin.
        /// </value>
        public UIElement SelectedPluginContent
        {
            get { return selectedPlugin == null ? null : selectedPlugin.Content; }
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="PluginsTesterMainWindowViewModel" /> class.
        /// </summary>
        /// <param name="plugins">The plugins to load inside the Window.</param>
        [ImportingConstructor]
        public PluginsTesterMainWindowViewModel([ImportMany] IEnumerable<IPluginTestable> plugins)
        {
            Plugins = new ObservableCollection<IPluginTestable>(plugins.OrderBy(p => p.Name));
        }
    }
}